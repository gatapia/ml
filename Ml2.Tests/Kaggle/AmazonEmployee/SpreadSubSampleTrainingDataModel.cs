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
  // ROLE ROLLUP 1 is also important: but only 81 out of 132 show rejections
  // ROLE ROLLUP 2 is also important: but only 110 out of 181 show rejections
  // ROLE DEPT NAME ALSO 271 / 453
  // ROLE TITLE: 158 / 347
  // ROLE FAMILY DESC: 388/2362
  // ROLE FAMILY: 51/71
  // ROLE CODE IS REDUNDANT
  [TestFixture] public class SpreadSubSampleTrainingDataModel
  {    
    [Test] public void build_classifier()
    {
      var rt = LoadTrainingData();      
      //var classifier = rt.Classifiers.RandomForest().
      //    MaxDepth(10).
      //    NumExecutionSlots(4).
      //    NumTrees(50).
      //    NumFeatures(2).
      //    EvaluateWith10CrossValidation();
      
      var classifier = rt.Classifiers.Logistic().        
          EvaluateWith10CrossValidation();

      var rejections = rt.Observations.Count(o => o.Row.ACTION == EAction.Rejected);
      var approvals = rt.Observations.Count(o => o.Row.ACTION == EAction.Approved);
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
      
      RunPredictions(classifier);
    }

    private Runtime<AmazonTrainDataRow> LoadTrainingData() {
      Console.WriteLine("LoadTrainingData");
      var full = new Runtime<AmazonTrainDataRow>(0, @"resources\kaggle\amazon-employee\train.csv");
      var trimmed = full.Filters.Supervised.Instance.SpreadSubsample().
          RandomSeed(1).
          DistributionSpread(1.1).
          MaxCount(0).
          RunFilter();
      Console.WriteLine("Original Rows [" + full.Instances.numInstances() + 
          "] Resampled [" + trimmed.Instances.numInstances() + "]");
      return trimmed;
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
      var testset = new Runtime(0, formatted);      
      var lines = new List<string> {"id,ACTION"};
      var instances = testset.Instances;
      for (var i = 0; i < instances.numInstances(); i++)
      {
        var instance = instances.instance(i);
        var outcome = classifier.Classify(instance).ToString();
        lines.Add((i + 1).ToString() + ',' + outcome);
      }
      File.WriteAllLines("SpreadSubSampleTrainingDataModelPredictions.csv", lines);

      var rejections = lines.Count(r => r.EndsWith(",0"));
      var approvals = lines.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }
  }
}