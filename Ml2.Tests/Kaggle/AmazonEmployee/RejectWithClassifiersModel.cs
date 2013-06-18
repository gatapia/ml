using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using weka.classifiers;
using weka.core;
using Console = System.Console;
using File = System.IO.File;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{
  /// <summary>
  /// This is a terrible model.
  /// </summary>
  [TestFixture] public class RejectWithClassifiersModel
  {
    private const int MIN_SAMPLE_FOR_PROBABILITY = 3;
    private const int MIN_SAMPLE_FOR_COMPLEX_CLASSIFIER = 100;    

    [Test] public void build_and_run_model()
    {
      var map = BuildModel();                
      RunPredictions(map);

      var predictions = File.ReadAllLines("classifier_based_model_predictions.csv"); 
      var rejections = predictions.Count(r => r.EndsWith(",0"));
      var approvals = predictions.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }
        
    private Dictionary<string, Dictionary<string, IBaseClassifier<AmazonTrainDataRow, Classifier>>> BuildModel()
    {
      var props = Helpers.GetProps(typeof(AmazonTrainDataRow)).Skip(2).ToArray();
      var all = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");
      var rejects = all.Where(r => r.ACTION == EAction.Rejected).ToArray();
      var model = props.ToDictionary(p => p.Name, p =>
      {
        var factors = rejects.Select(p.GetValue).Distinct();
        return factors.ToDictionary(v => v.ToString(),
                                      v => GetClassifierForPropAndVal(p, v, all));
      });
      return model;
    }

    private IBaseClassifier<AmazonTrainDataRow, Classifier> GetClassifierForPropAndVal(PropertyInfo p, object v, IEnumerable<AmazonTrainDataRow> all)
    {      
      var alls = GetMatches(p, v, all);      
      // If the sample size is too small for this property value then ignore.
      if (alls.Length < MIN_SAMPLE_FOR_PROBABILITY) return null;
      var rt = new Runtime<AmazonTrainDataRow>(0, alls).RemoveAttributes("RESOURCE");
      return alls.Length > MIN_SAMPLE_FOR_COMPLEX_CLASSIFIER
               ? (IBaseClassifier<AmazonTrainDataRow, Classifier>) rt.Classifiers.Trees.J48().Build()
               : rt.Classifiers.Rules.ZeroR().Build();
    }

    private AmazonTrainDataRow[] GetMatches(PropertyInfo p, object val, IEnumerable<AmazonTrainDataRow> rows)
    {
      return rows.Where(row => val.Equals(p.GetValue(row))).ToArray();
    }

    private void RunPredictions(Dictionary<string, Dictionary<string, IBaseClassifier<AmazonTrainDataRow, Classifier>>> map)
    {
      var props = Helpers.GetProps(typeof(AmazonTestDataRow)).Skip(2).ToArray();
      var test = new Runtime<AmazonTestDataRow>(0, @"resources\kaggle\amazon-employee\test.csv").
          RemoveAttributes("RESOURCE");
      var lines = test.Observations.Select((row, idx) => row.Row.ID + "," + Classify(row.Row, row.Instance, props, map)).ToList();
      
      lines.Insert(0, "id,ACTION");
      File.WriteAllLines("classifier_based_model_predictions.csv", lines);
    }

    private double Classify(AmazonTestDataRow row, Instance instance, IEnumerable<PropertyInfo> props, Dictionary<string, Dictionary<string, IBaseClassifier<AmazonTrainDataRow, Classifier>>> classifiers)
    {
      var percs = props.Select(p =>
      {
        var propvals = classifiers[p.Name];
        var val = p.GetValue(row).ToString();
        var classifier = propvals.ContainsKey(val) && propvals[val] != null ? propvals[val] : null;

        try { return classifier == null ? 1 : classifier.Classify(instance); }
        catch (IndexOutOfRangeException) { return Runtime.Random >= 0.5 ? 1 : 0; }
      });
      return percs.Average() >= 0.5 ? 1 : 0;
    }
  }
}