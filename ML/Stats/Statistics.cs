using System;

namespace ML.Stats
{
  public static class Statistics
  {    

    /// <summary>
    /// Works out the sample probability of success (p̂). Givent the CTL
    /// We know that p̂ is a good approximation of p (The population 
    /// probabilty).
    /// </summary>
    public static double Probability(double n, double successes) {
      return successes/n;
    }

    /// <summary>
    /// The variance with a specified p.
    /// </summary>
    private static double Variance(double n, double p) {
      return (p * (1-p))/n;
    }

    /// <summary>
    /// Gives the Confidence Interval for a proportion or probabilty of 
    /// occurrance.
    /// </summary>
    public static Tuple<double, double> ConfidenceInterval(double n, double successes, double p = 0.5, double conf = 0.95) {
      var p̂ = Probability(n, successes);
      var me = Math.Round(MarginOfError(n, p, conf), 3);
      return Tuple.Create(p̂ - me, p̂ + me);
    }

    /// <summary>
    /// Gives the Confidence Interval for the specified mean.
    /// </summary>
    public static Tuple<double, double> MeanConfidenceInterval(double x̄, double s, int n, double conf = 0.95) {
      var cdf = Helpers.GetTSigma(1 - conf, n - 1);
      var me = cdf * Math.Sqrt((s * s)/n);
      return Tuple.Create(x̄ - me, x̄ + me);
    }

    public static double MarginOfError(double n, double p, double conf = 0.95) {
      return Helpers.GetZSigma(conf) * Math.Sqrt(Variance(n, p));
    }

    public static int ExperimentN(double moe = 0.03, double conf = 0.95) {      
      var z = Helpers.GetZSigma(conf);
      var v = (z*0.5)/moe;
      return (int) (v*v);
    }        
  }
}