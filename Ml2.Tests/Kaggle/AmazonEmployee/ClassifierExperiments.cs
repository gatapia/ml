using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ml2.Arff;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using weka.classifiers;
using weka.core;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{    
  [TestFixture] public class ClassifierExperiments
  {    
    private static readonly int UNKNOWN_VALUE = Int32.MinValue;
    private static readonly int MAX_TRAINING_ROWS = 0;
    private static readonly int MAX_TEST_ROWS = 0;

    /// <summary>
    /// Full Model - D: 3, T: 10, F: 2 Success: 75.0988 %
    /// Without ROLE_FAMILY: 75.5204 %
    /// Only 5 trees: 73.5178%
    /// 5 Trees with 10 boost iterations: 75.0988 %
    /// 20 trees with 5 boost: 73.7549 %
    /// (No Boost) D:5 T:20 F:3 74.5982%
    /// D:5, NO F, T:20 71.9368 %
    /// 75.1779%
    /// With new count properties: 87.7207 %
    /// With 100 trees: 90.3821 % !!!!!!
    /// With Depth 4: 89.9341 % (Undoing)
    /// With Depth 2: 90.0132 % (Keeping 2 as its quicker but 3 is better)
    /// With 3 Features: 89.3281 % (Undoing)
    /// With 50 trees (from 100): 89.6179 % (Undoing)
    /// With 200 trees (from 100): 90.2767% (Keeping)
    /// With Depth 3 (from 2): 91.1462 % (Saved!!)
    ///     Evaluator Seed: 2 - Model has 22310 rejections and 36611 approvals
    ///     On Kaggle: 66.10822 %
    /// </summary>
    [Test] public void build_random_forest_classifier()
    {
      evaluate_classifier(c => c.Trees.RandomForest().          
          NumExecutionSlots(2).
          MaxDepth(3).
          NumFeatures(2).
          NumTrees(200));
    }

    /// <summary>
    /// Max Its: 100: 67.9315 %
    /// </summary>
    [Test] public void build_logistic_regression_classifier() {
      evaluate_classifier(c => c.Functions.Logistic().MaxIts(100));
    }

    /// <summary>
    /// 94.5718 % with:
    /// Model has 8782 rejections and 50139 approvals
    /// Highly overfitted.
    /// </summary>
    [Test] public void build_j48_classifier()
    {
      evaluate_classifier(c => c.Trees.J48());
    }

    /// <summary>
    /// K: 200 - 61.3175 %
    /// K: 100 - 62.0553 %
    /// K: 50 - 63.7945 %
    /// K: 25 - 64.5586 %
    /// K: 10 - 67.3254 %
    /// K: 5 - 70.303  %
    /// K: 4 - 70.9881 %
    /// K: 3 - 72.7273 % Predictions: 35692 rejections and 23229 approvals
    /// K: 2 - 72.6482 % 
    /// </summary>
    [Test] public void build_ibk_classifier()
    {
      evaluate_classifier(c => c.Lazy.IBk().KNN(3));
    }

    /// <summary>    
    /// Base: 52.5428 %
    /// W/SupervisedDiscretization: 93.8867 % - 12278 rejections and 46643 approvals
    /// W/KernelEstimator: 53.5968 %
    /// W/Both: 93.8076 % - 12278 rejections and 46643 approvals
    /// </summary>
    [Test] public void build_nb_classifier()
    {      
      evaluate_classifier(c => c.Bayes.NaiveBayes().
          UseKernelEstimator(true).
          UseSupervisedDiscretization(true));          
    }

    /// <summary>
    /// Too slow.
    /// </summary>
    [Test] public void build_svm_classifier()
    {
      // evaluate_classifier(c => c.SMO());       
    }

    // Model has 17633 rejections and 41288 approvals
    // On Kaggle: 0.70112
    [Test] public void ensemble_classifier() {
      var files = new [] {"NaiveBayes.model", "IbkDataModel.model", 
          "LogisticDataModel.model", "RandomForestDataModel.model"};
      var classifiers = files.Select(BaseClassifier.Read).ToArray();
      
      // No evaluation just predictions.
      RunPredictions(LoadTrainingData().ToArray(), classifiers);
    }

    private void evaluate_classifier(
          Func<Classifiers<RFCustomModel>, IBaseClassifier<RFCustomModel, Classifier>> builder) {
      var trainingrows = LoadTrainingData().ToArray();
      var rt =  new Runtime<RFCustomModel>(0, trainingrows);
      
      var classifier = builder(rt.Classifiers);

      classifier.
          FlushToFile(classifier.Impl.GetType().Name + ".model").
          EvaluateWithCrossValidation(); 
       
      RunPredictions(trainingrows, classifier.Impl);
    }
    
    [Test] public void load_model_and_run_predictions()
    {
      var model_to_load = "RandomForestDataModel.model";
      var classifier = BaseClassifier.Read(model_to_load);
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

      SetAdditionalCountInfoOn(joined, joined);

      Console.WriteLine("Trainign Data Loaded, total: " + joined.Count);
      
      // Add one row with unknown values as these are nominals and 
      // all must exist.
      joined.Add(CreateUnknownRFModel());
      return joined;
    }

    private void RunPredictions(RFCustomModel[] trainingrows, params Classifier[] classifiers)
    {
      var testrows = LoadAndMassageTestRows(trainingrows);          
      var testset = new Runtime<RFCustomModel>(0, testrows);      
      Func<double, Instance, int, string> formatter = 
          (outcome, obs, idx) => (idx + 1).ToString() + ',' + outcome;
      
      var lines = testset.GeneratePredictions(formatter, "id,ACTION", classifiers);
      
      File.WriteAllLines("EnsemblePredictions.csv", lines);

      var rejections = lines.Count(r => r.EndsWith(",0"));
      var approvals = lines.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }

    private void SetAdditionalCountInfoOn(ICollection<RFCustomModel> target, ICollection<RFCustomModel> traininset) {
      var countsreject = new Dictionary<string, IDictionary<string, int>>();
      var countsapprove = new Dictionary<string, IDictionary<string, int>>();
      var props = Helpers.GetProps(typeof(RFCustomModel)).
          Skip(1).
          Select(p => p.Name).
          Where(p => !p.EndsWith("_COUNTS")).
          ToArray();

      foreach (var r in traininset) {        
        foreach (var prop in props) {
          if (!countsreject.ContainsKey(prop)) countsreject[prop] = new Dictionary<string, int>();          
          if (!countsapprove.ContainsKey(prop)) countsapprove[prop] = new Dictionary<string, int>();          

          var val = Helpers.GetValue<int>(r, prop);
          var key = val.ToString();          

          if (countsreject[prop].ContainsKey(key)) continue;

          var withval = Helpers.RowsWherePropIsValue(traininset, prop, val).ToArray();
          countsreject[prop][key] = withval.Count(r2 => r2.ACTION == EAction.Rejected);
          countsapprove[prop][key] = withval.Count(r2 => r2.ACTION == EAction.Approved);
        }
      }

      props = Helpers.GetProps(typeof(RFCustomModel)).
          Skip(1).
          Select(p => p.Name).
          Where(p => p.EndsWith("_COUNTS")).
          ToArray();

      foreach (var r in target) {
        foreach (var countprop in props) {
          var reject = countprop.EndsWith("_REJECT_COUNTS");
          var prop = countprop.Substring(0, countprop.Length - 14); 
          var val = Helpers.GetValue<int>(r, prop);
          var key = val.ToString();        
          if (!countsreject[prop].ContainsKey(key)) continue;
          var count = (reject ? countsreject : countsapprove)[prop][key];
          
          Helpers.SetValue(r, countprop, count);
        }
      }
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
      
      SetAdditionalCountInfoOn(formatted, trainingrows);
      
      return formatted;
    }

    private RFCustomModel CreateCustomModelFromTestRow(AmazonTrainDataRow r, RFCustomModel[] trainingrows) {
      var props = Helpers.GetProps(typeof(RFCustomModel)).
          Skip(1).
          Select(p => p.Name).
          Where(p => !p.EndsWith("_COUNTS")).
          ToArray();
      var cm = new RFCustomModel { ACTION = EAction.Approved };
      Array.ForEach(props, p => Helpers.SetValue(cm, p, GetNominalValueOrUnknown(r, trainingrows, p)));
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
      var props = Helpers.GetProps(typeof(RFCustomModel)).
          Select(p => p.Name).
          Where(p => !p.EndsWith("_COUNTS")).
          ToArray();
      var newm = new RFCustomModel();
      Array.ForEach(props, p => Helpers.SetValue(newm, p, Helpers.GetValue<object>(r, p)));
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
    public int RESOURCE_REJECT_COUNTS { get; set;}
    public int RESOURCE_ACCEPT_COUNTS { get; set;}
    public int MGR_ID_REJECT_COUNTS { get; set;}
    public int MGR_ID_ACCEPT_COUNTS { get; set;}
    public int ROLE_ROLLUP_1_REJECT_COUNTS { get; set;}
    public int ROLE_ROLLUP_1_ACCEPT_COUNTS { get; set;}
    public int ROLE_ROLLUP_2_REJECT_COUNTS { get; set;}
    public int ROLE_ROLLUP_2_ACCEPT_COUNTS { get; set;}
    public int ROLE_DEPTNAME_REJECT_COUNTS { get; set;}
    public int ROLE_DEPTNAME_ACCEPT_COUNTS { get; set;}
    public int ROLE_TITLE_REJECT_COUNTS { get; set;}
    public int ROLE_TITLE_ACCEPT_COUNTS { get; set;}
    public int ROLE_FAMILY_DESC_REJECT_COUNTS { get; set;}
    public int ROLE_FAMILY_DESC_ACCEPT_COUNTS { get; set;}
    // [Nominal] public int ROLE_FAMILY { get; set; } // Not needed
  }
}