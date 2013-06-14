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
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv");
      train.Instances.deleteStringAttributes();

      var classifier = train.
        Classifiers.
            Logistic().
                Ridge(19).        
                Build();
      EvalImpl(train, classifier.Impl);
    }

    // 80.3591 % ?? Even with boosting
    [Test] public void Test_logistic_regression_with_boosting() {
      var train = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv");
      train.Instances.deleteStringAttributes();

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

    private string GetCabinBin(string cabin) {
      if (String.IsNullOrEmpty(cabin)) { return "Unknown"; }
      return cabin[0].ToString();
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

    private void EvalImpl<T>(Runtime<T> runtime, Classifier classifier) where T : new() {
      Evaluation evaluation = new Evaluation(runtime.Instances);
      evaluation.crossValidateModel(classifier, runtime.Instances, 10, new Random(1));
      var results = evaluation.toSummaryString();
      Console.WriteLine(results);
    }
  }
}