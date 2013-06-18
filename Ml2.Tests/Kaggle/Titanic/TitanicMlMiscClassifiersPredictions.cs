using System;
using System.IO;
using System.Linq;
using Ml2.Clss;
using NUnit.Framework;
using weka.core;
using TR=Ml2.Tests.Kaggle.Titanic.Data.TitanicDataRow;

namespace Ml2.Tests.Kaggle.Titanic
{
  [TestFixture]
  public class TitanicMlmiscClassifiersPredictions
  {
    // 80.3591 %
    [Test]
    public void Test_logistic_regression()
    {
      var train = new Runtime<TR>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof (string));

      train.Classifiers.
        Logistic().EvaluateWithCrossValidation();
    }

    // 80.3591 % ?? Even with boosting
    [Test]
    public void Test_logistic_regression_with_boosting()
    {
      var train = new Runtime<TR>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof (string));
      var classifier = train.Classifiers.Logistic();

      train.Classifiers.
        AdaBoostM1().Seed(1).Classifier(classifier).
        NumIterations(10).EvaluateWithCrossValidation();
    }

    [Test]
    public void Test_logistic_regression_with_and_without_ages()
    {
      var rows = Runtime.Load<TR>(@"resources\kaggle\titanic\train.csv");
      var withage = rows.Where(t => t.Age.HasValue).ToArray();
      var without = rows.Where(t => !t.Age.HasValue).
        Select(t => new
                      {
                        t.Survival,
                        t.PassengerClass,
                        t.Sex,
                        t.NumSiblingsOrSpouses,
                        t.NumParentsChildren,
                        t.PassengerFare,
                        t.PortOfEmbarkation
                      }).
        ToArray();

      Console.WriteLine("With ages.");
      new Runtime<TR>(0, withage).
        RemoveAttributes(typeof (string)).
        Classifiers.Logistic().EvaluateWithCrossValidation();

      Console.WriteLine("Without ages.");
      new Runtime(0, without).
        RemoveAttributes(typeof (string)).
        Classifiers.Logistic().EvaluateWithCrossValidation();
    }

    [Test]
    public void Test_creating_prediction_file()
    {
      var raw = File.ReadAllLines(@"resources\kaggle\titanic\test.csv");
      var formatted = raw.Select(l => "1," + l).ToArray();

      var testrows = Runtime.LoadLines<TR>(formatted);
      var testset = new Runtime<TR>(0, testrows).
        RemoveAttributes(typeof (string));

      var classifier = new Runtime<TR>(0, @"resources\kaggle\titanic\train.csv").
        RemoveAttributes(typeof (string)).
        Classifiers.Logistic();

      var lines = raw.Select((line, idx) => GetRow(classifier, idx, testset.Observations[idx - 1].Instance, line)).ToArray();
      File.WriteAllLines("predict.csv", lines);
    }


    private string GetRow(Logistic<TR> trained, int idx, Instance instance, string line)
    {
      var classification = idx == 0 ? "header" : trained.Classify(instance).ToString();
      return classification + "," + line;
    }
  }
}