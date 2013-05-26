using System;

namespace ML.Stats
{
  public static class TwoProportions
  {
    public static Tuple<double, double> ConfidenceInterval(int n1, double p̂1, int n2, double p̂2, double conf = 0.95) {
      var p̂1_p̂2 = p̂1 - p̂2;
      var expr = Helpers.GetZSigma(conf) * Math.Sqrt(p̂1*(1-p̂1)/n1 + p̂2*(1-p̂2)/n2);
      return Helpers.PlusMinus(p̂1_p̂2, expr);
    }

    public static double PValue(int n1, double p̂1, int n2, double p̂2, double conf = 0.95) {
      var p̂1_p̂2 = p̂1 - p̂2;
      var pooled = ((n1*p̂1)+(n2*p̂2))/(n1+n2);
      var sigma = Math.Abs(p̂1_p̂2)/Math.Sqrt((pooled * (1.0-pooled)) * (1.0/n1 + 1.0/n2));
      return 2 * (1 - Helpers.GetZ(sigma));
    }
  }
}