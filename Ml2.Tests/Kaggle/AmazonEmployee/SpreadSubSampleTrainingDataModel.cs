using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using weka.classifiers;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{  
  // Notes on excel analysis of the Amazon training data
  // The manager column is definately required. However only 818 (out of 4247) 
  //    or so managers with rejections.
  // ROLE ROLLUP 1: 81 / 132
  // ROLE ROLLUP 2: 110 / 181
  // ROLE DEPT NAME:  271 / 453
  // ROLE TITLE: 158 / 347
  // ROLE FAMILY DESC: 388 / 2362
  // ROLE FAMILY: 51/71
  // ROLE CODE IS REDUNDANT
  [TestFixture] public class SpreadSubSampleTrainingDataModel
  {    
    [Test] public void build_classifier()
    {
      var rt = LoadTrainingData();      
      var classifier = rt.Classifiers.RandomForest().
          MaxDepth(5).
          NumExecutionSlots(2).
          NumTrees(4).
          NumFeatures(2).
          EvaluateWith10CrossValidation();
      
      //var classifier = rt.Classifiers.J48().        
      //    EvaluateWith10CrossValidation();      
      
      RunPredictions(classifier);
    }

    private Runtime<AmazonTrainDataRow> LoadTrainingData() {
      Console.WriteLine("LoadTrainingData");
      var all = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");
      var rejects = all.Where(r => r.ACTION == EAction.Rejected).ToArray();
      var approved = all.Where(r => r.ACTION == EAction.Approved).
          RandomSample(rejects.Length).ToArray();
      var joined = rejects.Concat(approved).ToArray();
      Console.WriteLine("Trainign Data Loaded, total: " + joined.Length + " rejects: " + 
            rejects.Length + ", approved: " + approved.Length);
      return new Runtime<AmazonTrainDataRow>(0, joined);
    }

    private void RunPredictions(IBaseClassifier<AmazonTrainDataRow, Classifier> classifier)
    {
      var formatted = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\test.csv").
          Select(r => new AmazonTrainDataRow {
                          MGR_ID = r.MGR_ID, 
                          RESOURCE = r.RESOURCE, 
                          ROLE_DEPTNAME = r.ROLE_DEPTNAME, 
                          ROLE_FAMILY = r.ROLE_FAMILY, 
                          ROLE_FAMILY_DESC = r.ROLE_FAMILY_DESC, 
                          ROLE_ROLLUP_1 = r.ROLE_ROLLUP_1, 
                          ROLE_ROLLUP_2 = r.ROLE_ROLLUP_2, 
                          ROLE_TITLE = r.ROLE_TITLE
                        }).
          ToArray();    
      var testset = new Runtime<AmazonTrainDataRow>(0, formatted);      
      Func<double, Observation<AmazonTrainDataRow>, int, string> formatter = (outcome, obs, idx) => (idx + 1).ToString() + ',' + outcome;
      var lines = RunPredictionsGeneric(classifier, testset, formatter, "id,ACTION");
      File.WriteAllLines("SpreadSubSampleTrainingDataModelPredictions.csv", lines);

      var rejections = lines.Count(r => r.EndsWith(",0"));
      var approvals = lines.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }

    public static ICollection<string> RunPredictionsGeneric<T>(
        IBaseClassifier<T, Classifier> classifier, 
        Runtime<T> testset,
        Func<double, Observation<T>, int, string> outputline,
        string outheader = null) where T : new()
    {
      var outlines = new List<string>();
      if (!String.IsNullOrWhiteSpace(outheader)) outlines.Add(outheader);
      var num = testset.Observations.Length;
      for (int i = 0; i < num; i++)
      {
        var obs = testset.Observations[i];
        var outcome = classifier.Classify(obs);
        outlines.Add(outputline(outcome, obs, i));
      }
      return outlines.ToArray();
    }
  }
}