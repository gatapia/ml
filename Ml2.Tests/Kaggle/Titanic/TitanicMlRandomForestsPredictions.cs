using System;
using System.Linq;
using Ml2.Clss;
using Ml2.Tests.Kaggle.Titanic.Data;
using NUnit.Framework;
using weka.classifiers.trees;

namespace Ml2.Tests.Kaggle.Titanic
{
  /// <summary>
  /// Random Forest with 300 trees and 7 features: 81.8182%.
  /// </summary>
  [TestFixture] public class TitanicMlRandomForestsPredictions
  {
    [Test] public void Build_titanic_random_forest_model() {
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv").
          RemoveAttributes(typeof(string));
      
      TrainImpl(train, 300, 7).FlushToFile("titanic.model");
    }

    [Test] public void Evaluate_titanic_random_forest_model() {
      new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv").
          RemoveAttributes(typeof(string)).
          EvaluateWith10CrossValidateion(BaseClassifier.Read("titanic.model"));
    }

    [Test] public void Test_multiple_random_forest_args() {
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof(string));

      // Success Rate: 81.8182% (300 and 7 seem to be the best values)
      TrainImpl(train, 300, 7).EvaluateWith10CrossValidation();

      /*
      for (int i = 1; i < 10; i++) {
        trees = 100 * i;
        Console.WriteLine("Trees: " + trees + " Features: " + features );
        TrainImpl(trees, features).EvaluateWith10CrossValidation();
      }      
      for (int i = 1; i < 9; i++) {
        features = i;
        var forest = TrainImpl(trees, features);
        Console.WriteLine("Trees: " + trees + " Features: " + features);
        forest.EvaluateWith10CrossValidation();
      }
       */
    }

    // 80.1347% 
    // 80.5836 % with new csv parser???
    [Test] public void Test_without_port_or_fare() {
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv").
          RemoveAttributes(typeof(string), "PortOfEmbarkation", "PassengerFare"); 

      TrainImpl(train, 300, 7).EvaluateWith10CrossValidation();
    }    

    // 81.1448 % with tot family
    // 80.5836 % with has family (binary)
    [Test] public void Test_with_new_tot_family_attributes()
    {
      var rows = Runtime.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      object[] newrows = rows.Select(t => new {
        t.Survival, t.PassengerClass, t.Sex, t.Age,
                                  TotFamily = t.NumParentsChildren.GetValueOrDefault() + 
                                    t.NumSiblingsOrSpouses.GetValueOrDefault()
                                }).ToArray();
      TrainImpl(new Runtime(0, newrows), 300, 7).EvaluateWith10CrossValidation();
    }
       

    // 78.0022 %
    [Test] public void Test_with_ticket_binned()
    {
      var rows = Runtime.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      object[] newrows = rows.Select(t => new {
        t.Survival, t.PassengerClass, t.Sex, t.Age,
                                  TotFamily = t.NumParentsChildren.GetValueOrDefault() + 
                                    t.NumSiblingsOrSpouses.GetValueOrDefault(),
                                  TicketBin = GetTicketBin(t.TicketNumber)
                                }).ToArray();
      var train = new Runtime(0, newrows);
      var newtrain = train.Filters.Unsupervised.Attribute.StringToNominal().AttributeRange(5).RunFilter();
      TrainImpl(newtrain, 300, 7).EvaluateWith10CrossValidation();
    }

    // 72.8395 %
    [Test] public void Test_with_fare_binned()
    {
      var rows = Runtime.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      object[] newrows = rows.Select(t => new {
                                  t.Survival, t.PassengerClass, t.Sex, t.Age,
                                  TotFamily = t.NumParentsChildren.GetValueOrDefault() + 
                                    t.NumSiblingsOrSpouses.GetValueOrDefault(),
                                  FareBin = GetFareBin(t.PassengerFare)
                                }).ToArray();
      var train = new Runtime(0, newrows);
      var newtrain = train.Filters.Unsupervised.Attribute.StringToNominal().AttributeRange(5).RunFilter();
      TrainImpl(newtrain, 300, 7).EvaluateWith10CrossValidation();
    }    
    
    // 79.798  %
    [Test] public void Test_with_cabin_binned()
    {
      var rows = Runtime.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      object[] newrows = rows.Select(t => new {
        t.Survival,
        t.PassengerClass,
        t.Sex,
        t.Age,
        TotFamily = t.NumParentsChildren.GetValueOrDefault() + 
            t.NumSiblingsOrSpouses.GetValueOrDefault(),
        CabinBin = GetCabinBin(t.CabinNum)
      }).ToArray();
      var train = new Runtime(0, newrows);
      var newtrain = train.Filters.Unsupervised.Attribute.StringToNominal().AttributeRange(5).RunFilter();
      TrainImpl(newtrain, 300, 7).EvaluateWith10CrossValidation();
    }

    [Test] public void Test_only_on_genders() {
      var rows = Runtime.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv").
          Where(t => t.Sex == ESex.Female).ToArray();
      var train = new Runtime(0, rows).RemoveAttributes(typeof(string));
      TrainImpl(train, 300, 7).EvaluateWith10CrossValidation();

      rows = Runtime.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv").
          Where(t => t.Sex == ESex.Male).ToArray();
      train = new Runtime(0, rows).RemoveAttributes(typeof(string));
      TrainImpl(train, 300, 7).EvaluateWith10CrossValidation();
    }

    private string GetCabinBin(string cabin) {
      return String.IsNullOrEmpty(cabin) 
          ? "Unknown" : 
          cabin[0].ToString();
    }

    private string GetTicketBin(string num) {
      var t = num.Split(' ').First();
      var bin = t.ToLower().Replace(".", String.Empty).Replace("/", String.Empty);
      int val;
      return Int32.TryParse(bin, out val) ? (val/1000).ToString() : bin;
    }

    private string GetFareBin(double? fare) {
      if (!fare.HasValue) { return "Unknown"; }
      var val = fare.Value;
      return (val / 100).ToString();
    }

    private IBaseClassifier<T, RandomForest> TrainImpl<T>(Runtime<T> runtime, int trees, int features)  where T : new() {
      return runtime.
        Classifiers.RandomForest().
        NumTrees(trees).
        NumFeatures(features).
        Debug(true).
        Seed(1);
    }    
  }
}