using NUnit.Framework;
using TR=Ml2.Tests.Kaggle.Titanic.Data.TitanicDataRow;

namespace Ml2.Tests.Kaggle.Titanic
{
  [TestFixture]
  public class TitanicCartPredictions
  {
    // 80.3591 %
    [Test]
    public void Test_logistic_regression()
    {
      var train = new Runtime<TR>(0, @"resources\kaggle\titanic\train.csv").RemoveAttributes(typeof (string));

      // train.Classifiers.
      //   SimpleCart().EvaluateWith10CrossValidation();
    }

  }
}