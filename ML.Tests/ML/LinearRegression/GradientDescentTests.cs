using ML.Linear;
using ML.Optimisation;
using NUnit.Framework;

namespace ML.Tests.ML.LinearRegression
{
  [TestFixture] public class GradientDescentTests
  {
    private TrainingSet t;

    [SetUp] public void SetUp() {
      double[] xs =  { 80, 60, 10, 20, 30 };
      double[] ys = { 20, 40, 30, 50, 60 };

      t = TrainingSet.FromOutputsAndFeatures(ys, true, new [] {xs});
    }

    [Test] public void TestFromPoints() {      
      var gd = new GradientDescent(t, new [] {0.0, 0.0}, Regression.CostFunction, Regression.Hypothesis);      
      gd.Alpha = 1e-5;
      gd.Precision = 1e-4;
      ValidateParameters(gd.Optimize());
    }

    [Test] public void TestNormalEquation() {      
      ValidateParameters(NormalEquation.Calculate(t));
    }

    private static void ValidateParameters(double[] Θ) {
      double slope = Θ[1];
      double intercept = Θ[0];

      // Expected slope and intercept
      double eSlope = -0.264706;
      double eIntercept = 50.588235;

      Assert.AreEqual(eSlope, slope, 1e-5);
      Assert.AreEqual(eIntercept, intercept, 1e-5);
    }
  }
}