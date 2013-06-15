﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TR=Ml2.Tests.Kaggle.Titanic.Data.TitanicDataRow;

namespace Ml2.Tests.Kaggle.Titanic
{  
  [TestFixture] public class TitanicMlmiscClassifiersPredictions
  {    
    // 80.3591 %
    [Test] public void Test_logistic_regression() {
      var train = new Runtime<TR>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof(string));

      train.Classifiers.
          Logistic().Build().EvaluateWith10CrossValidateion();
    }

    // 80.3591 % ?? Even with boosting
    [Test] public void Test_logistic_regression_with_boosting() {
      var train = new Runtime<TR>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof(string));      
      var classifier = train.Classifiers.Logistic();

      train.Classifiers.
          AdaBoostM1().Seed(1).Classifier(classifier).
              NumIterations(10).Build().EvaluateWith10CrossValidateion();
    }

    [Test] public void Test_logistic_regression_with_and_without_ages() {
      var rows = Runtime.Load<TR>(@"resources\kaggle\titanic\train.csv");
      var withage = rows.Where(t => t.Age.HasValue).ToArray();
      var without = rows.Where(t => !t.Age.HasValue).
          Select(t => new {
            t.Survival, t.PassengerClass, t.Sex, t.NumSiblingsOrSpouses, 
            t.NumParentsChildren, t.PassengerFare, t.PortOfEmbarkation
          }).
          ToArray();

      Console.WriteLine("With ages.");
      new Runtime<TR>(0, withage).
        RemoveAttributes(typeof(string)).
            Classifiers.Logistic().
                Build().
                EvaluateWith10CrossValidateion();

      Console.WriteLine("Without ages.");
      new Runtime(0, without).
          RemoveAttributes(typeof(string)).
          Classifiers.Logistic().
              Build().
              EvaluateWith10CrossValidateion();
    }

    [Test] public void Test_creating_prediction_file()
    {
      var raw = File.ReadAllLines(@"resources\kaggle\titanic\test.csv");
      var formatted = raw.Select(l => "1," + l).ToArray();

      var testrows = Runtime.LoadLines<TR>(formatted);
      var testset = new Runtime<TR>(0, testrows).
            RemoveAttributes(typeof(string));      

      var classifier = new Runtime<TR>(0, @"resources\kaggle\titanic\train.csv").
          RemoveAttributes(typeof(string)).
          Classifiers.Logistic().
              Build();

      File.WriteAllLines("predict.csv", testset.PrependClassifications(classifier, raw));
    }
  }
}