using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ml2.Arff;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using TT = System.Tuple<Ml2.Tests.Kaggle.AmazonEmployee.CustomModel2[], System.Collections.Generic.Dictionary<string, System.Collections.Generic.IDictionary<string, int>>>;

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
  [TestFixture] public class TrimmingTrainingDataModel
  {    
    private static readonly string[] props = { "MGR_ID", "ROLE_ROLLUP_1", "ROLE_FAMILY" };
    private const int REDUNDANT = 999999;
    private static readonly int MAX_ROWS = 1000;

    [Test] public void build_classifier()
    {
      var tt = LoadTrainingData();
      var rows = tt.Item1;
      var counts = tt.Item2;
      var training = new Runtime<CustomModel2>(0, rows);
      Console.WriteLine("Training Data Loaded");

      training.Classifiers.Trees.J48().
          EvaluateWithCrossValidation().
          FlushToFile("TrimmingTrainingDataModel.model");
      
      var predictions = RunPredictions(counts);
      var rejections = predictions.Count(r => r.EndsWith(",0"));
      var approvals = predictions.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }

    [Test] public void rerun_saved_model() {
      var tt = LoadTrainingData();
      var counts = tt.Item2;
      
      var predictions = RunPredictions(counts);

      var rejections = predictions.Count(r => r.EndsWith(",0"));
      var approvals = predictions.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }

    private TT LoadTrainingData() {
      Console.WriteLine("LoadTrainingData");

      var file = GetType().Name + "_training_rows.osl";
      // if (1==2 && File.Exists(file)) return Helpers.Deserialise<TT>(file);

      var trainingdata = GetTrainingSubset();
      var rejects = trainingdata.Where(r => r.ACTION == EAction.Rejected).ToArray();
      Console.WriteLine("Found " + trainingdata.Length + " rows, " + rejects.Length + " with rejections");
      
      var counts = new Dictionary<string, IDictionary<string, int>>();
      var newrows = new List<CustomModel2>();      
      foreach (var r in trainingdata) {
        var validrow = false;        
        foreach (var prop in props) {
          if (!counts.ContainsKey(prop)) counts[prop] = new Dictionary<string, int>();          

          var val = Helpers.GetValue<int>(r, prop);
          var key = val.ToString();          

          var rejectionsWithValCount = counts[prop].ContainsKey(key) ? 
              counts[prop][key] :
              (counts[prop][key] = Helpers.RowsWherePropIsValue(rejects, prop, val).Count());

          if (rejectionsWithValCount < 2) { 
            rejectionsWithValCount = 0;
            Helpers.SetValue(r, prop, REDUNDANT); 
          } else { validrow = true; }
          // Helpers.SetValue(r, prop + "_REJECTS", rejectionsWithValCount);
        }
        if (validrow) { newrows.Add(r);  }
      }
      var arr = newrows.ToArray();
      var result = Tuple.Create(arr, counts);
      Console.WriteLine("Training set has " + arr.Length + " rows, with " + arr.Count(r => r.ACTION == EAction.Rejected) + " rejections.");
      return Helpers.Serialise(result, file);
    }

    private List<string> RunPredictions(Dictionary<string, IDictionary<string, int>> counts)
    {
      var classifier = BaseClassifier.Read("TrimmingTrainingDataModel.model");
      var testrows = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\test.csv").
          Take(MAX_ROWS).
          Select(r => new CustomModel2(r)).
          ToArray();

      foreach (var r in testrows) {
        foreach (var prop in props) {
          var val = Helpers.GetValue<int>(r, prop);
          var key = val.ToString();          

          var rejectionsWithValCount = counts[prop].ContainsKey(key) ? counts[prop][key] : 0;
          if (rejectionsWithValCount < 2) { 
            rejectionsWithValCount = 0;
            Helpers.SetValue(r, prop, REDUNDANT); 
          }
          // Helpers.SetValue(r, prop + "_REJECTS", rejectionsWithValCount);
        }
      }      
      var testset = new Runtime(0, testrows);      
      var lines = new List<string> {"id,ACTION"};
      var instances = testset.Instances;
      for (var i = 0; i < instances.numInstances(); i++)
      {
        var instance = instances.instance(i);
        var outcome = classifier.classifyInstance(instance).ToString();
        lines.Add((i + 1).ToString() + ',' + outcome);
      }
      File.WriteAllLines("TrimmingTrainingDataModelPredictions.csv", lines);
      return lines;
    }
    
    private static CustomModel2[] GetTrainingSubset() {
      var rawrows = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");

      // var subset = rawrows.Where(r => {
      //   // Heavily prefer rejection rows.
      //   var prob = r.ACTION == EAction.Rejected ? 0.9 : 0.1;
      //   return Helpers.Random() < prob;
      // }).ToArray();

      var trainingdata = rawrows.
        Select(r => new CustomModel2(r)).
        Take(MAX_ROWS).
        ToArray();
      return trainingdata;
    }
  }

  [Serializable] public class CustomModel2
  {
    public CustomModel2() {}

    public CustomModel2(IAmazonDataRow r) {
      ACTION = r.GetAction();
      MGR_ID = r.MGR_ID;
      ROLE_ROLLUP_1 = r.ROLE_ROLLUP_1;
      ROLE_FAMILY = r.ROLE_FAMILY;
    }    

    public EAction ACTION { get; set; }
    [Nominal] public int MGR_ID { get; set; }    
    [Nominal] public int ROLE_ROLLUP_1 { get; set; }
    [Nominal] public int ROLE_FAMILY { get; set; }
    // public int MGR_ID_REJECTS { get; set; }    
    // public int ROLE_ROLLUP_1_REJECTS { get; set; }
    // public int ROLE_FAMILY_REJECTS { get; set; }
  }
}