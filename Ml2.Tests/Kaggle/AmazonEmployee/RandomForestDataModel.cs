using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ml2.Arff;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using weka.classifiers;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{    
  [TestFixture] public class RandomForestDataModel
  {    
    private static readonly int UNKNOWN_VALUE = Int32.MinValue;
    private static readonly int MAX_TRAINING_ROWS = 0;
    private static readonly int MAX_TEST_ROWS = 3000;

    /// <summary>
    /// Full Model - D: 3, T: 10, F: 2 Success: 75.0988 %
    /// Without ROLE_FAMILY: 75.5204 %
    /// Only 5 trees: 73.5178%
    /// 5 Trees with 10 boost iterations: 75.0988 %
    /// 20 trees with 5 boost: 73.7549 %
    /// (No Boost) D:5 T:20 F:3 74.5982%
    /// D:5, NO F, T:20 71.9368 %
    /// 75.1779%
    /// </summary>
    [Test] public void build_classifier()
    {
      var trainingrows = LoadTrainingData().ToArray();
      var rt =  new Runtime<RFCustomModel>(0, trainingrows);
      
      var classifier = rt.Classifiers.RandomForest().          
          NumExecutionSlots(2).
          MaxDepth(3).
          NumFeatures(2).
          NumTrees(10).
          EvaluateWithCrossValidation().
          FlushToFile("RandomForestDataModel.model");
       
      RunPredictions(trainingrows, classifier.Impl);
    }

    [Test] public void load_model_and_run_predictions()
    {
      var classifier = BaseClassifier.Read("RandomForestDataModelWithBoost.model");
      RunPredictions(LoadTrainingData().ToArray(), classifier);
    }

    private ICollection<RFCustomModel> LoadTrainingData() {
      Console.WriteLine("LoadTrainingData");
      var all = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");
      var rejects = all.Where(r => r.ACTION == EAction.Rejected).ToArray();
      var approved = all.Where(r => r.ACTION == EAction.Approved).
          RandomSample(rejects.Length).ToArray();
      var joined = rejects.Concat(approved).Select(SelectAttributes).ToList();
      if (MAX_TRAINING_ROWS > 0) joined = joined.RandomSample(MAX_TRAINING_ROWS).ToList();

      Console.WriteLine("Trainign Data Loaded, total: " + joined.Count);
      
      // Add one row with unknown values as these are nominals and 
      // all must exist.
      joined.Add(CreateUnknownRFModel());
      return joined;
    }

    private void RunPredictions(RFCustomModel[] trainingrows, Classifier classifier)
    {
      var testrows = LoadAndMassageTestRows(trainingrows);    
      var testset = new Runtime<RFCustomModel>(0, testrows);      
      Func<double, Observation<RFCustomModel>, int, string> formatter = 
          (outcome, obs, idx) => (idx + 1).ToString() + ',' + outcome;
      
      var lines = testset.GeneratePredictions(classifier, formatter, "id,ACTION");
      
      File.WriteAllLines("RandomForestDataModel.csv", lines);

      var rejections = lines.Count(r => r.EndsWith(",0"));
      var approvals = lines.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }

    private static RFCustomModel CreateUnknownRFModel() {
      var props = Helpers.GetProps(typeof(RFCustomModel)).Skip(1).ToArray();
      var cm = new RFCustomModel { ACTION = EAction.Approved };
      Array.ForEach(props, p => Helpers.SetValue(cm, p.Name, UNKNOWN_VALUE));
      return cm;
    }

    private RFCustomModel[] LoadAndMassageTestRows(RFCustomModel[] trainingrows) {
      var testrows = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\test.csv");
      if (MAX_TEST_ROWS > 0) testrows = testrows.RandomSample(MAX_TEST_ROWS).ToArray();
      var formatted = testrows.Select(r => CreateCustomModelFromTestRow(r, trainingrows)).ToArray();
      return formatted;
    }

    private RFCustomModel CreateCustomModelFromTestRow(AmazonTrainDataRow r, RFCustomModel[] trainingrows) {
      var props = Helpers.GetProps(typeof(RFCustomModel)).Skip(1).ToArray();
      var cm = new RFCustomModel { ACTION = EAction.Approved };
      Array.ForEach(props, p => Helpers.SetValue(cm, p.Name, GetNominalValueOrUnknown(r, trainingrows, p.Name)));
      return cm;
    }

    private static readonly IDictionary<string, IList<int>> cached_known_values = new Dictionary<string, IList<int>>();
    private static readonly IDictionary<string, IDictionary<int, bool>> cached_known_property_values = new Dictionary<string, IDictionary<int, bool>>();

    private int GetNominalValueOrUnknown(
        AmazonTrainDataRow data, 
        IEnumerable<RFCustomModel> trainingrows, 
        string prop) {
      if (!cached_known_property_values.ContainsKey(prop)) cached_known_property_values[prop] = new Dictionary<int, bool>();
      
      var value = Helpers.GetValue<int>(data, prop);      
      if (cached_known_property_values[prop].ContainsKey(value)) return cached_known_property_values[prop][value] ? value : UNKNOWN_VALUE;
      
      if (!cached_known_values.ContainsKey(prop)) cached_known_values[prop] = trainingrows.Select(r => Helpers.GetValue<int>(r, prop)).ToList();
      cached_known_property_values[prop][value] = cached_known_values[prop].Contains(value);
      return cached_known_property_values[prop][value] ? value : UNKNOWN_VALUE;
    }

    private RFCustomModel SelectAttributes(AmazonTrainDataRow r)
    {
      // All Fields: ACTION, RESOURCE, MGR_ID, ROLE_ROLLUP_1, ROLE_ROLLUP_2, ROLE_DEPTNAME, ROLE_TITLE, ROLE_FAMILY_DESC, ROLE_FAMILY
      var props = Helpers.GetProps(typeof(RFCustomModel));
      var newm = new RFCustomModel();
      Array.ForEach(props, p => Helpers.SetValue(newm, p.Name, Helpers.GetValue<object>(r, p.Name)));
      return newm;
    }    
  }

  // Notes on excel analysis of the Amazon training data
  // MGR_ID: 818 / 4247 
  // ROLE ROLLUP 1: 81 / 132
  // ROLE ROLLUP 2: 110 / 181
  // ROLE DEPT NAME:  271 / 453
  // ROLE TITLE: 158 / 347
  // ROLE FAMILY DESC: 388 / 2362
  // ROLE FAMILY: 51/71
  // ROLE CODE IS REDUNDANT
  // Current Success Rate: 75.5204 %
  internal class RFCustomModel {
    public EAction ACTION { get; set; }
    [Nominal] public int RESOURCE { get; set; } // Needed: 1% loss if removed
    [Nominal] public int MGR_ID { get; set; } // Needed: 0.5% loss if removed
    [Nominal] public int ROLE_ROLLUP_1 { get; set; } // Needed: 1% loss if removed
    [Nominal] public int ROLE_ROLLUP_2 { get; set; } // Needed: 1.5% loss if removed
    [Nominal] public int ROLE_DEPTNAME { get; set; } // Needed: 0.5% loss if removed
    [Nominal] public int ROLE_TITLE { get; set; } // Needed: 1% loss if removed
    [Nominal] public int ROLE_FAMILY_DESC { get; set; } // Needed: 1% loss if removed
    // [Nominal] public int ROLE_FAMILY { get; set; } // Not needed
  }
}