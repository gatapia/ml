using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using weka.core;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{  
  [TestFixture] public class AmazonPredictions
  {    
    // With a small sub-sample of 500 we get 94% predictive power
    [Test] public void logistic_regression_on_small_subset()
    {
      var lines = File.ReadAllLines(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.LoadLines<AmazonTrainDataRow>(lines, 500).
          Select(a => new { a.ACTION, a.MGR_ID, a.ROLE_ROLLUP_1, a.ROLE_FAMILY }).ToArray();
      var train = new Runtime(0, rows);

      train.Classifiers.Logistic().EvaluateWith10CrossValidation();
    }

    [Test] public void logistic_regression_on_small_subset_play_with_features()
    {
      var lines = File.ReadAllLines(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.LoadLines<AmazonTrainDataRow>(lines).
          Select(a => new { a.ACTION, a.MGR_ID }).ToArray();
      var train = new Runtime(0, rows);

      train.Classifiers.Logistic().
        FlushToFile("amazon-employee.model").
        EvaluateWith10CrossValidation();      
    }

    [Test] public void decision_tree_experiments()
    {
      var lines = File.ReadAllLines(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.LoadLines<AmazonTrainDataRow>(lines).
          Select(a => new { a.ACTION, a.MGR_ID, a.ROLE_ROLLUP_1, a.ROLE_DEPTNAME, a.ROLE_TITLE }).ToArray();
      var train = new Runtime(0, rows);

      train.Classifiers.J48().
        FlushToFile("amazon-employee.model").
        EvaluateWith10CrossValidation();

      run_predictions();
      var predictions = File.ReadAllLines("predict.csv"); 
      var rejections = predictions.Count(r => r.EndsWith(",0"));
      var approvals = predictions.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }

    [Test] public void are_all_managers_represented()
    {
      var traindata = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");
      var trainmgrs = traindata.Select(a => a.MGR_ID).Distinct().ToArray();
      var testmgrs = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\test.csv").Select(a => a.MGR_ID).Distinct().ToArray();

      Console.WriteLine("Training Managers: " + trainmgrs.Length + " Test Managers: " + testmgrs.Length);
      var rejectters = trainmgrs.Where(m => traindata.Count(a => a.MGR_ID == m && a.ACTION == 0) > 0).ToArray();
      Console.WriteLine("Managers with rejections: " + rejectters.Count());
      var notrepresented = testmgrs.Except(trainmgrs).Count();      
      Assert.AreEqual(0, notrepresented);
    }

    [Test] public void j48_on_rejecters_and_1_otherwise()
    {
      var train = new Runtime<AmazonTrainDataRow>(0, @"resources\kaggle\amazon-employee\train.csv");
      var test = new Runtime<AmazonTestDataRow>(0, @"resources\kaggle\amazon-employee\test.csv");
      var testmgrs = test.Observations.Select(a => a.Row.MGR_ID).Distinct().ToArray();
      var trainmgrs = train.Observations.Select(a => a.Row.MGR_ID).Distinct().ToArray();
      var notrepresented = testmgrs.Except(trainmgrs);     
      var rejectters = trainmgrs.Where(m => train.Observations.Count(a => a.Row.MGR_ID == m && a.Row.ACTION == 0) > 0).ToArray();
      var classifier = train.Classifiers.J48();

      var lines = test.Observations.Select((row, idx) =>
      {
        var prediction = rejectters.Contains(row.Row.MGR_ID) || notrepresented.Contains(row.Row.MGR_ID)
                          ? classifier.Classify(row.Instance)
                          : 1;
        return row.Row.ID + "," + prediction;
      }).ToList();
      lines.Insert(0, "id,ACTION");
      
      File.WriteAllLines("predict_rejecters_or_1.csv", lines);
      var rejections = lines.Count(r => r.EndsWith(",0"));
      var approvals = lines.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }

    [Test] public void train_on_50_50_data()
    {
      var rows = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv").
          Randomize().ToArray();
      
      var rejects = rows.Where(r => r.ACTION == EAction.Rejected).ToArray();
      var approved = rows.Where(r => r.ACTION == EAction.Approved).ToArray();
      var approvedsample = approved.Take(rejects.Length);
      var sample = rejects.Concat(approvedsample).Randomize().ToArray();
      var train = new Runtime<AmazonTrainDataRow>(0, sample);

      train.Classifiers.J48().
        EvaluateWith10CrossValidation();
    }

    // Currently 50% (same as random) on test dataset.
    [Test] public void run_predictions(Func<Instance,string> impl = null)
    {
      var raw = File.ReadAllLines(@"resources\kaggle\amazon-employee\test.csv");
      var testrows = Runtime.LoadLines<AmazonTrainDataRow>(raw).
          Select(a => new { a.ACTION, a.MGR_ID }).ToArray();
      var testset = new Runtime(0, testrows);

      var classifier = BaseClassifier.Read("amazon-employee.model");
      var lines = new List<string> {"id,ACTION"};
      var instances = testset.Instances;
      for (var i = 0; i < instances.numInstances(); i++)
      {
        var instance = instances.instance(i);
        var outcome = impl == null ? classifier.classifyInstance(instance).ToString() : impl(instance);
        lines.Add((i + 1).ToString() + ',' + outcome);
      }
      File.WriteAllLines("predict.csv", lines);
    }    
  }
}