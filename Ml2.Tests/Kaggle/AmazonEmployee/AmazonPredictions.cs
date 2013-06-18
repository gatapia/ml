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
    private readonly Random rng = new Random(1);

    // With a small sub-sample of 500 we get 94% predictive power
    [Test] public void logistic_regression_on_small_subset()
    {
      var lines = File.ReadAllLines(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.LoadLines<AmazonTrainDataRow>(lines, 500).
          Select(a => new { a.ACTION, a.MGR_ID, a.ROLE_ROLLUP_1, a.ROLE_FAMILY }).ToArray();
      var train = new Runtime(0, rows);

      train.Classifiers.Functions.Logistic().EvaluateWithCrossValidation();
    }

    [Test] public void logistic_regression_on_small_subset_play_with_features()
    {
      var lines = File.ReadAllLines(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.LoadLines<AmazonTrainDataRow>(lines).
          Select(a => new { a.ACTION, a.MGR_ID }).ToArray();
      var train = new Runtime(0, rows);

      train.Classifiers.Functions.Logistic().
        FlushToFile("amazon-employee.model").
        EvaluateWithCrossValidation();      
    }

    [Test] public void decision_tree_experiments()
    {
      var lines = File.ReadAllLines(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.LoadLines<AmazonTrainDataRow>(lines).
          Select(a => new { a.ACTION, a.MGR_ID, a.ROLE_ROLLUP_1, a.ROLE_DEPTNAME, a.ROLE_TITLE }).ToArray();
      var train = new Runtime(0, rows);

      train.Classifiers.Trees.J48().
        FlushToFile("amazon-employee.model").
        EvaluateWithCrossValidation();

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
      var classifier = train.Classifiers.Trees.J48();

      var lines = test.Observations.Select((row, idx) =>
      {
        var prediction = rejectters.Contains(row.Row.MGR_ID) || notrepresented.Contains(row.Row.MGR_ID)
                          ? classifier.Classify(row.Instance)
                          : 1.0;
        return row.Row.ID + "," + prediction;
      }).ToList();
      lines.Insert(0, "id,ACTION");
      
      File.WriteAllLines("predict_rejecters_or_1.csv", lines);
      var rejections = lines.Count(r => r.EndsWith(",0"));
      var approvals = lines.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }

    [Test] public void j48_on_rejecters_and_random_otherwise()
    {
      var trainrows = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");
      var testrows = Runtime.Load<AmazonTestDataRow>(@"resources\kaggle\amazon-employee\test.csv");
      Console.WriteLine("Total Training Rows: " + trainrows.Length + " Total Test Rows: " + testrows.Length);

      var testmgrs = testrows.Select(a => a.MGR_ID).Distinct().ToArray();
      var trainmgrs = trainrows.Select(a => a.MGR_ID).Distinct().ToArray();
      var trainingmanagers = trainmgrs.Intersect(testmgrs).ToArray();     
      var testingmanagers_not_represented = testmgrs.Except(trainmgrs).ToArray();     

      var trainsubset = trainrows.Where(r => trainingmanagers.Contains(r.MGR_ID)).Select(r => new
      {
        r.ACTION,
        r.MGR_ID,
        r.ROLE_DEPTNAME
      }).ToArray();
      Console.WriteLine("Training Subset Created: " + trainsubset.Length);

      var classifier = new Runtime(0, trainsubset).Classifiers.Trees.J48().Build();
      Console.WriteLine("Training Classifier Created");
      var testformatted = testrows.Select(r => new { ACTION=EAction.Approved, r.MGR_ID, r.ROLE_DEPTNAME, r.ID }).ToArray();
      var testrt = new Runtime(0, testformatted);
      var lines = testrt.Observations.Select((row, idx) =>
      {
        double prediction; 
        if (testingmanagers_not_represented.Contains(Helpers.GetValue<int>(row.Row, "MGR_ID")))
        {
          prediction = rng.NextDouble() < 0.5 ? 1.0 : 0.0;
        } else
        {
          prediction = classifier.Classify(row.Instance);
        }
        return Helpers.GetValue<int>(row.Row, "ID") + "," + prediction;
      }).ToList();
      lines.Insert(0, "id,ACTION");
      
      File.WriteAllLines("predict_rejecters_or_rnd.csv", lines);
      var rejections = lines.Count(r => r.EndsWith(",0"));
      var approvals = lines.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
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