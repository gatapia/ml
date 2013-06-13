using System;
using System.Linq;
using Ml2.Clss;
using NUnit.Framework;
using weka.classifiers;
using weka.classifiers.trees;
using Random = java.util.Random;

namespace Ml2.Tests.Kaggle.Titanic
{
  /// <summary>
  /// Random Forest with 300 trees and 7 features: 81.8182%.
  /// </summary>
  [TestFixture] public class TitanicMlPredictions
  {
    [Test] public void Build_titanic_random_forest_model() {
      var train = new Runtime<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      train.Instances.deleteStringAttributes();

      TrainImpl(train, 300, 7).Flush("titanic.model");
    }

    [Test] public void Evaluate_titanic_random_forest_model() {
      var train = new Runtime<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      train.Instances.deleteStringAttributes();

      EvalImpl(train, BaseClassifier.Read("titanic.model"));
    }

    [Test] public void Test_multiple_random_forest_args() {
      var train = new Runtime<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      train.Instances.deleteStringAttributes();

      // Success Rate: 81.8182%
      var trees = 300;
      var features = 7;
      EvalImpl(train, TrainImpl(train, 300, 7).Impl);

      /*
      for (int i = 1; i < 10; i++) {
        trees = 100 * i;
        Console.WriteLine("Trees: " + trees + " Features: " + features );
        EvalImpl(TrainImpl(trees, features).Impl);
      }      
      for (int i = 1; i < 9; i++) {
        features = i;
        var forest = TrainImpl(trees, features);
        Console.WriteLine("Trees: " + trees + " Features: " + features);
        EvalImpl(forest.Impl);
      }
       */
    }

    // 80.1347% 
    // 80.5836 % with new csv parser???
    [Test] public void Test_without_port_or_fare() {
      var train = new Runtime<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      train.Instances.deleteAttributeAt(10); // Port 
      train.Instances.deleteAttributeAt(8); // Fare
      train.Instances.deleteStringAttributes();                 

      EvalImpl(train, TrainImpl(train, 300, 7).Impl);
    }

    // 81.1448 % with original rows    
    // 80.5836 % with new parser ???
    [Test] public void Test_with_new_tot_family_attributes()
    {
      var rows = Runtime.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      object[] newrows = rows.Select(t => new {
                                  Survival = t.Survival,
                                  PassengerClass = t.PassengerClass,
                                  Sex = t.Sex,
                                  Age = t.Age,
                                  HasFamily = (t.NumParentsChildren + t.NumSiblingsOrSpouses) > 0
                                }).ToArray();
      var train = new Runtime(newrows);
      train.SetClassifierIndex(0);

      EvalImpl(train, TrainImpl(train, 300, 7).Impl);
    }

    [Test] public void Test_with_has_family()
    {
      
    }

    private BaseClassifier<T, RandomForest> TrainImpl<T>(Runtime<T> runtime, int trees, int features)  where T : new() {
      return runtime.
        Classifiers.RandomForest().
        NumTrees(trees).
        NumFeatures(features).
        Debug(true).
        Seed(1).
        Build();
    }

    private void EvalImpl<T>(Runtime<T> runtime, Classifier classifier) where T : new() {
      Evaluation evaluation = new Evaluation(runtime.Instances);
      evaluation.crossValidateModel(classifier, runtime.Instances, 10, new Random(1));
      var results = evaluation.toSummaryString();
      Console.WriteLine(results);
    }
  }
}