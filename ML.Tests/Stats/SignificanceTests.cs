using ML.Stats;
using NUnit.Framework;

namespace ML.Tests.Stats
{
  [TestFixture] public class SignificanceTests
  {
    [Test] public void TestPValue() {
      var p = Significance.PValue(1046, 0.42, 0.5);
      TestHelpers.AlmostEqual(1/9000000, p);
    }

    [Test] public void TestPValueTwoSided() {
      var p = Significance.PValue(1000, 0.576, 0.5, two_sided: true);
      TestHelpers.AlmostEqual(1/663000, p);
    }

    [Test] public void TestMeanPValue() {
      var p = Significance.MeanPValue(60, 7.177, 2.948);
      Assert.AreEqual(0, p);
    }

    [Test] public void TestMeanPValue2() {
      var p = Significance.MeanPValue(400, -14.15, 14.13, two_sided: true);
      Assert.AreEqual(0, p);
    }

    [Test] public void TestMeanPValue3() {
      var p = Significance.MeanPValue(130, 36.80513, 0.407324, two_sided: true);
      Assert.AreEqual(1/4000000, p);
    }
  }
}