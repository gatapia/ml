using System;
using System.Linq;
using Ml2.Tests.Kaggle.Titanic.Data;
using NUnit.Framework;
using weka.classifiers;
using Random = java.util.Random;

namespace Ml2.Tests.Kaggle.Titanic
{
  [TestFixture] public class TitanicMlmiscClassifiersPredictions
  {
    
    // 80.3591 %
    [Test] public void Test_logistic_regression() {
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof(string));

      var classifier = train.
        Classifiers.
            Logistic().
                Ridge(19).        
                Build();
      EvalImpl(train, classifier.Impl);
    }

    // 80.3591 % ?? Even with boosting
    [Test] public void Test_logistic_regression_with_boosting() {
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof(string));      

      var classifier = train.
        Classifiers.
            Logistic().
                Ridge(19);

      var booster = train.Classifiers.AdaBoostM1();
      booster.
          Seed(1).
          Classifier(classifier).
          NumIterations(10).
          Build();
      EvalImpl(train, booster.Impl);
    }

    [Test] public void Test_logistic_regression_with_and_without_ages() {
      var rows = Runtime.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
      var withage = rows.Where(t => t.Age.HasValue).ToArray();
      var without = rows.Where(t => !t.Age.HasValue).
          Select(t => new {
            t.Survival, t.PassengerClass, t.Sex, t.NumSiblingsOrSpouses, t.NumParentsChildren, t.PassengerFare, t.PortOfEmbarkation
          }).
          ToArray();
      var twith = new Runtime<TitanicDataRow>(withage, 0);
      var twithout = new Runtime(without, 0).RemoveAttributes(typeof(string));

      var classifier = twith.
        Classifiers.
            Logistic().
                Build();
      EvalImpl(twith, classifier.Impl);

      classifier = twithout.
        Classifiers.
            Logistic().
                Build();
      EvalImpl(twithout, classifier.Impl);
    }
    
    private void EvalImpl<T>(Runtime<T> runtime, Classifier classifier) where T : new() {
      Evaluation evaluation = new Evaluation(runtime.Instances);
      evaluation.crossValidateModel(classifier, runtime.Instances, 10, new Random(1));
      var results = evaluation.toSummaryString();
      Console.WriteLine(results);
    }
  }
}