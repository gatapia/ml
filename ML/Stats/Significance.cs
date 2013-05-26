using System;

namespace ML.Stats
{
  public static class Significance
  {
    /// The p-value is a number between 0 and 1 that quantifies the strength 
    /// of the evidence against the null hypothesis (H₀).  It can also be 
    /// considered as the likelyhood of observing our test statistic assuming
    /// H₀ is true.  If the p-value is small enough you can reject the H₀ in
    /// favour of the Hₐ (alternate hypothesis)
    public static double PValue(int n, double p̂, double H0, double p = 0.5, bool two_sided = false) {
      var p̂_p = p̂ - p;
      var denom = Math.Sqrt(0.5*(1 - 0.5)/n);
      var sigma = p̂_p/denom;
      var pv = Helpers.GetZ(p̂_p > 0 ? -1 * sigma : sigma);
      return !two_sided ? pv : pv * 2;
    }

    public static double MeanPValue(int n, double x̄, double s, double μ = 0.0, bool two_sided = false) {
      var x̄_μ = x̄ - μ;
      var targett = x̄_μ/Math.Sqrt(s*s/n);
      var pv = Helpers.GetT(targett, n - 1);
      return !two_sided ? pv : pv * 2;
    }
  }
}