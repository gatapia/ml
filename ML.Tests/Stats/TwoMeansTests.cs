using System;
using ML.Stats;
using NUnit.Framework;

namespace ML.Tests.Stats
{
  [TestFixture] public class TwoMeansTests
  {
    [Test] public void TestConfidenceInterval1() {
      var exp = Tuple.Create(1.026, 7.374);
      var act = TwoMeans.ConfidenceInterval(281, -12.9, Math.Sqrt(181.5), 
        119, -17.1, Math.Sqrt(231.5));
      TestHelpers.AlmostEqual(exp, act);
    } 

    [Test] public void TestConfidenceInterval2() {
      var exp = Tuple.Create(-1.179, 13.379);
      var act = TwoMeans.ConfidenceInterval(30, 73.1, Math.Sqrt(38.7), 
        8, 67, Math.Sqrt(72.5));
      TestHelpers.AlmostEqual(exp, act);
    } 

    [Test] public void TestPValue1() {
      var exp = 0.0097;
      var act = TwoMeans.PValue(281, -12.9, Math.Sqrt(181.5), 
                        119, -17.1, Math.Sqrt(231.5));
      TestHelpers.AlmostEqual(exp, act);
    }

    [Test] public void TestPValue2() {
      var exp = 0.090;
      var act = TwoMeans.PValue(30, 73.1, Math.Sqrt(38.7), 
                                8, 67, Math.Sqrt(72.5));
      TestHelpers.AlmostEqual(exp, act);
    }
  }
}