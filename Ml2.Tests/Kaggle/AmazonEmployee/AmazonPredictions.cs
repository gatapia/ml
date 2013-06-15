using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ml2.Arff;
using Ml2.Clss;
using NUnit.Framework;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{  
  [TestFixture] public class AmazonPredictions
  {    
    // With a small sub-sample of 500 we get 94% predictive power
    [Test] public void Test_logistic_regression_on_small_subset()
    {
      var lines = File.ReadAllLines(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.LoadLines<AmazonDataRow>(lines, 500).
          Select(a => new { a.ACTION, a.MGR_ID, a.ROLE_ROLLUP_1, a.ROLE_FAMILY }).ToArray();
      var train = new Runtime(0, rows);

      train.Classifiers.Logistic().Build().EvaluateWith10CrossValidateion();
    }

    [Test] public void Test_logistic_regression_on_small_subset_play_with_features()
    {
      var lines = File.ReadAllLines(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.LoadLines<AmazonDataRow>(lines).
          Select(a => new { a.ACTION, a.MGR_ID }).ToArray();
      var train = new Runtime(0, rows);

      train.Classifiers.Logistic().Build().
        FlushToFile("amazon-employee.model").
        EvaluateWith10CrossValidateion();      
    }

    [Test] public void run_predictions()
    {
      var raw = File.ReadAllLines(@"resources\kaggle\amazon-employee\test.csv");
      var testrows = Runtime.LoadLines<AmazonDataRow>(raw).
          Select(a => new { a.ACTION, a.MGR_ID }).ToArray();
      var testset = new Runtime(0, testrows);

      var classifier = BaseClassifier.Read("amazon-employee.model");
      var lines = new List<string> {"id,ACTION"};
      var instances = testset.Instances;
      for (var i = 0; i < instances.numInstances(); i++)
      {
        lines.Add((i + 1).ToString() + ',' + classifier.classifyInstance(instances.instance(i)));
      }
      File.WriteAllLines("predict.csv", lines);
    }
  }

  public class AmazonDataRow
  {
    public EAction ACTION { get; set; }
    public int RESOURCE { get; set; }
    [Nominal] public int MGR_ID { get; set; }
    [Nominal] public int ROLE_ROLLUP_1 { get; set; }
    [Nominal] public int ROLE_ROLLUP_2 { get; set; }
    [Nominal] public int ROLE_DEPTNAME { get; set; }
    [Nominal] public int ROLE_TITLE { get; set; }
    [Nominal] public int ROLE_FAMILY_DESC { get; set; }
    [Nominal] public int ROLE_FAMILY { get; set; }
    [Nominal] public int ROLE_CODE { get; set; }    
  }

  public enum EAction
  {
    Rejected = 0,
    Approved = 1
  }
}