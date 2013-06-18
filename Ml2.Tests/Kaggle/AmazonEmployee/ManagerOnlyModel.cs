using System;
using System.IO;
using System.Linq;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using weka.classifiers;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{
  [TestFixture] public class ManagerOnlyModel
  {    
    [Test] public void build_and_run_model()
    {      
      var rows = LoadRows<AmazonTrainDataRow>("train.csv", null);
      Helpers.Serialise(rows, "manager_only_training_rows.osl");
      Console.WriteLine("Training Rows Saved");
      LoadRuntime<AmazonTrainDataRow>("train.csv", null).Classifiers.Trees.J48().EvaluateWithCrossValidation().FlushToFile("manager_only.model");
      load_and_run_model();
    }

    [Test] public void load_and_run_model()
    {
      var rows = Helpers.Deserialise<ManagerOnlyRow[]>("manager_only_training_rows.osl");      
      Console.WriteLine("Training Set Loaded");
      var classifier = BaseClassifier.Read("manager_only.model");
      Console.WriteLine("Classifier Loaded");
      RunPredictions(LoadRuntime<AmazonTestDataRow>("test.csv", rows), classifier);
      Console.WriteLine("Predictions Run");
      PrintPredictions();
    }

    private static Runtime<ManagerOnlyRow> LoadRuntime<T>(string file, ManagerOnlyRow[] trainingset) where T : IAmazonDataRow, new()
    {
      var rows = LoadRows<T>(file, trainingset);
      return new Runtime<ManagerOnlyRow>(0, rows);
    }

    private static ManagerOnlyRow[] LoadRows<T>(string file, ManagerOnlyRow[] trainingset) where T : IAmazonDataRow, new()
    {
      var orig = Runtime.Load<T>(@"resources\kaggle\amazon-employee\" + file).Cast<IAmazonDataRow>().ToArray();
      var rows = orig.Select(r => new ManagerOnlyRow(orig, r, trainingset)).ToArray();
      return rows;
    }

    private void RunPredictions(Runtime<ManagerOnlyRow> rt, Classifier classifier)
    {
      var lines = rt.Observations.Select((row, idx) => (idx + 1) + "," + Classify(classifier, row)).ToList();
      lines.Insert(0, "id,ACTION");
      
      File.WriteAllLines("predict_mgrs_only.csv", lines);
    }

    private double Classify(Classifier classifier, Observation<ManagerOnlyRow> row)
    {
      var r = row.Row;
      return r.IsUnknown() ? (Runtime.Random < 0.5 ? 1 : 0)
          : (r.TotalRejections()/r.TotalApprovals() < 0.05 ? 1.0 : 
              classifier.classifyInstance(row.Instance));
    }


    private static void PrintPredictions()
    {
      var predictions = File.ReadAllLines("predict_mgrs_only.csv");
      var rejections = predictions.Count(r => r.EndsWith(",0"));
      var approvals = predictions.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }
  }
}