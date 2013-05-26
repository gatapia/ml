using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics.Distributions;

[assembly: InternalsVisibleTo("ML.Tests")]
namespace ML.Stats
{
  internal static class Helpers
  {
    private static readonly Normal NORM = new Normal();
    private static readonly StatisticFormula STATS = new Chart().DataManipulator.Statistics;    

    internal static double GetZ(double sigma) { return NORM.CumulativeDistribution(sigma); }
    internal static double GetZSigma(double conf) { return NORM.InverseCumulativeDistribution(conf + ((1-conf)/2)); }
    internal static double GetT(double v, int dof) { return STATS.TDistribution(v, dof, false); }
    internal static double GetTSigma(double p, int dof) { return STATS.InverseTDistribution(p, dof); }
    internal static Tuple<double, double> PlusMinus(double a, double b) { 
      var x = a + b;
      var y = a - b;
      return Tuple.Create(Math.Min(x, y), Math.Max(x, y)); 
    } 
  }
}