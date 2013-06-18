using System;
using System.IO;
using System.Linq;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using weka.classifiers;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{  
  [TestFixture] public class ProportionBasedAttributesModel
  {
    private readonly Random rng = new Random(1);

    [Test] public void build_classifier()
    {
      var trainingrows = GetTrainingCustomModels();
      Console.WriteLine("Got Subset of Training Rows");
      var rt = new Runtime<CustomModel>(0, trainingrows);
      rt.Filters.SupervisedAttribute.Discretize().
          AttributeIndices("2-7").
          Bins(5).
          RunFilter();

      rt.Classifiers.Functions.Logistic().
          EvaluateWithCrossValidation().
          FlushToFile("custom_training_set_logistic.model");
    }

    private static CustomModel[] GetTrainingCustomModels()
    {
      const string file = "custom_model_training_rows.osl";
      if (File.Exists(file)) return Helpers.Deserialise<CustomModel[]>(file);

      var rows = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");
      // Training set is only rows that have some rejection proportions.
      var subset = rows.Select((r, idx) => new CustomModel(r, rows, idx)).
          Where(c => c.GetTotalRejectionProportion() > 0).ToArray();
      Helpers.Serialise(subset, file);
      return subset;
    }

    [Test] public void load_and_run_model()
    {
      var trainingrows = Runtime.Load<AmazonTrainDataRow>(@"resources\kaggle\amazon-employee\train.csv");
      var rows = Runtime.Load<AmazonTestDataRow>(@"resources\kaggle\amazon-employee\test.csv");
      var testingrows = rows.Select((r, idx) => new CustomModel(r, trainingrows, idx)).ToArray();        

      Console.WriteLine("Testing Set Loaded");
      var classifier = BaseClassifier.Read("custom_training_set_logistic.model");
      Console.WriteLine("Classifier Loaded");
      var rt = new Runtime<CustomModel>(0, testingrows);
      RunPredictions(rt, classifier);
      Console.WriteLine("Predictions Run");
      PrintPredictions();
    }
    

    private void RunPredictions(Runtime<CustomModel> rt, Classifier classifier)
    {
      var lines = rt.Observations.Select((row, idx) => (idx + 1) + "," + Classify(classifier, row)).ToList();
      lines.Insert(0, "id,ACTION");
      
      File.WriteAllLines("predict_custom_model.csv", lines);
    }

    private double Classify(Classifier classifier, Observation<CustomModel> row)
    {
      return classifier.classifyInstance(row.Instance);
    }


    private static void PrintPredictions()
    {
      var predictions = File.ReadAllLines("predict_custom_model.csv");
      var rejections = predictions.Count(r => r.EndsWith(",0"));
      var approvals = predictions.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Model has " + rejections + " rejections and " + approvals + " approvals.");
    }
  }
}