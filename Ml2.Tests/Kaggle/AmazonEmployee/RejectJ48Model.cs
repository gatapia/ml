using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using Console = System.Console;
using File = System.IO.File;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{
  [TestFixture] public class RejectJ48Model
  {
    private const int MIN_SAMPLE_FOR_PROBABILITY = 3;
    private const double MIN_PROB_FOR_MODEL = 0.02;

    private readonly Random rng = new Random(1);    
    
    [Test] public void build_and_run_model()
    {
      var rejectsperc = BuildModel();      
      RunPredictions(rejectsperc);
    }

    [Test] public void build_and_save_model()
    {
      var map = BuildModel();      
      
      using (var stream = File.Open("model.osl", FileMode.Create))
      {
        new BinaryFormatter().Serialize(stream, map);
      }
    }

    [Test] public void load_and_classify_model()
    {            
      var map = LoadSavedModel();
      Console.WriteLine(String.Join("\n", 
          map.Select(kvp => kvp.Key + ": " + String.Join(", ", 
              kvp.Value.Where(p => p.Value > 0.05).
                OrderByDescending(kvp2 => kvp2.Value).
                  Select(kvp3 => kvp3.Key + ":" + kvp3.Value)))));
      RunPredictions(map);

      var predictions = File.ReadAllLines("chance_based_model_predictions.csv"); 
      var rejections = predictions.Count(r => r.EndsWith(",0"));
      var approvals = predictions.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }
    
    private Dictionary<string, Dictionary<string, double>> LoadSavedModel()
    {
      using (var stream = File.Open("model.osl", FileMode.Open))
      {
        return new BinaryFormatter().Deserialize(stream) as Dictionary<string, Dictionary<string, double>>;
      }
    }

    private Dictionary<string, Dictionary<string, double>> BuildModel()
    {
      var props = typeof (AmazonTrainDataRow).GetProperties().Skip(2).ToArray();
      var all = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");
      var rejects = all.Where(r => r.ACTION == EAction.Rejected).ToArray();
      var model = props.ToDictionary(p => p.Name, p =>
      {
        var factors = rejects.Select(p.GetValue).Distinct();
        return factors.ToDictionary(v => v.ToString(),
                                      v => GetProbabilityOfRejection(p, v, rejects, all));
      });
      Console.WriteLine("Number of potential models: " + count);
      return model;
    }

    private int count = 0;
    // TODO: We could also try building a J48 tree for each of these rejections instead of a simple probabilty.
    private double GetProbabilityOfRejection(PropertyInfo p, object v, IEnumerable<AmazonTrainDataRow> rejects, IEnumerable<AmazonTrainDataRow> all)
    {      
      var alls = CountMatches(p, v, all);      
      // If the sample size is too small for this property value then ignore.
      if (alls < MIN_SAMPLE_FOR_PROBABILITY) return 0;      
      var rejections = CountMatches(p, v, rejects);      
      var prob = rejections/alls;      
      // Ignore very low probability events.
      if (prob < MIN_PROB_FOR_MODEL) return 0;
      count++;
      return prob;
    }

    private double CountMatches(PropertyInfo p, object val, IEnumerable<AmazonTrainDataRow> rows)
    {
      return rows.Count(row => val.Equals(p.GetValue(row)));
    }

    private void RunPredictions(IReadOnlyDictionary<string, Dictionary<string, double>> rejectsperc)
    {
      var props = typeof (AmazonTestDataRow).GetProperties().Skip(2).ToArray();
      var test = Runtime.Load<AmazonTestDataRow>(@"resources\kaggle\amazon-employee\test.csv");
      var lines = test.Select(row => row.ID + "," + Classify(row, props, rejectsperc)).ToList();
      lines.Insert(0, "id,ACTION");
      File.WriteAllLines("chance_based_model_predictions.csv", lines);
    }

    private int Classify(AmazonTestDataRow row, IEnumerable<PropertyInfo> props, IReadOnlyDictionary<string, Dictionary<string, double>> classifier)
    {      
      var percs = props.Select(p =>
      {
        var propvals = classifier[p.Name];
        var val = p.GetValue(row).ToString();                                   
        return propvals.ContainsKey(val) ? propvals[val] : 0;
      });
      return rng.NextDouble() < percs.Max() ? 0 : 1;
    }
  }
}