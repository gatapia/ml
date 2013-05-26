using System;
using ML.Stats;
using NUnit.Framework;

namespace ML.Tests.Stats
{
  [TestFixture] public class StatisticsTests
  {
    [Test] public void TestProbability() {
      Assert.AreEqual(0.576, Statistics.Probability(1000, 576));
    }  

    [Test] public void TestConfidenceInterval95() {
      var exp = Tuple.Create(0.545, 0.607);
      var act = Statistics.ConfidenceInterval(1000, 576);
      TestHelpers.AlmostEqual(exp, act);      
    }

    [Test] public void TestConfidenceInterval90() {
      var exp = Tuple.Create(0.550, 0.602);
      var act = Statistics.ConfidenceInterval(1000, 576, conf: 0.90);
      TestHelpers.AlmostEqual(exp, act);      
    }

    [Test] public void TestConfidenceInterval99() {      
      var exp = Tuple.Create(0.535, 0.617);
      var act = Statistics.ConfidenceInterval(1000, 576, conf: 0.99);
      TestHelpers.AlmostEqual(exp, act);      
    }

    [Test] public void TestExperimentN3Perc() {
      Assert.AreEqual(1067, Statistics.ExperimentN());
    }

    [Test] public void TestExperimentN1Perc() {
      Assert.AreEqual(9603, Statistics.ExperimentN(0.01));
    }    

    [Test] public void TestMeanCI() {
      var exp = Tuple.Create(6.415, 7.938);
      var act = Statistics.MeanConfidenceInterval(7.177, 2.948, 60);
      TestHelpers.AlmostEqual(exp, act);      
    }

    [Test] public void TestMeanCI2() {
      var exp = Tuple.Create(-15.54, -12.76);
      var act = Statistics.MeanConfidenceInterval(-14.15, 14.124, 400);
      TestHelpers.AlmostEqual(exp, act);      
    }
  }
}