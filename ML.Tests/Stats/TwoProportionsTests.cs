using System;
using ML.Stats;
using NUnit.Framework;

namespace ML.Tests.Stats
{
  [TestFixture] public class TwoProportionsTests
  {
    [Test] public void TestConfidenceInterval1() {
      var exp = Tuple.Create(0.108, 0.192);
      var act =TwoProportions.ConfidenceInterval(1050, 0.57, 1046, 0.42);
      TestHelpers.AlmostEqual(exp, act);
    } 

    [Test] public void TestConfidenceInterval2() {
      var exp = Tuple.Create(-0.012, 0.092);
      var act =TwoProportions.ConfidenceInterval(1010, 0.52, 563, 0.48);
      TestHelpers.AlmostEqual(exp, act);
    }
 
    [Test] public void TestConfidenceInterval3() {
      var exp = Tuple.Create(-0.059, -0.047);
      var act =TwoProportions.ConfidenceInterval(6163, 0.004, 6018, 0.057);
      TestHelpers.AlmostEqual(exp, act);
    }

    [Test] public void TestPValue1() {
      var exp = 0;
      TestHelpers.AlmostEqual(exp, TwoProportions.PValue(1050, 0.57, 1046, 0.42));
    }

    [Test] public void TestPValue2() {
      var exp = 0.129;
      TestHelpers.AlmostEqual(exp, TwoProportions.PValue(1010, 0.52, 563, 0.48));
    }    

    [Test] public void TestPValue3() {
      var exp = 0.0;
      TestHelpers.AlmostEqual(exp, TwoProportions.PValue(6163, 0.004, 6018, 0.057));
    }    
  }
}