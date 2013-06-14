using System.Linq;
using Ml2.Tests.Kaggle.Titanic.Data;
using NUnit.Framework;

namespace Ml2.Tests.Kaggle.Titanic
{
  [TestFixture] public class TitanicMlmiscClassifiersPredictions
  {
    
    // 80.3591 %
    [Test] public void Test_logistic_regression() {
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof(string));

      train.Classifiers.
          Logistic().Build().EvaluateWith10CrossValidateion();
    }

    // 80.3591 % ?? Even with boosting
    [Test] public void Test_logistic_regression_with_boosting() {
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof(string));      

      var classifier = train.Classifiers.Logistic();

      train.Classifiers.
          AdaBoostM1().Seed(1).Classifier(classifier).NumIterations(10).Build().EvaluateWith10CrossValidateion();
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

      twith.Classifiers.
            Logistic().Build().EvaluateWith10CrossValidateion();

      twithout.Classifiers.
            Logistic().Build().EvaluateWith10CrossValidateion();
    }       
  }
}