using System;

namespace ML.Stats
{
  /// <summary>
  /// H₀ in all methods below os that μ1 = μ2.
  /// </summary>
  public static class TwoMeans
  {
    public static Tuple<double, double> ConfidenceInterval(
        int n1, double x̄1, double s1,
        int n2, double x̄2, double s2, double conf = 0.95) {
      var dof = DegreesOfFreedom(n1, s1, n2, s2);
      var criticalt = Helpers.GetTSigma(1 - conf, (int) dof);
      var x̄1_x̄2 = x̄1 - x̄2;
      var b = criticalt * Math.Sqrt(s1*s1/n1 + s2*s2/n2);
      return Helpers.PlusMinus(x̄1_x̄2, b);
    }

    public static double PValue(int n1, double x̄1, double s1,
        int n2, double x̄2, double s2, double conf = 0.95) {
      var dof = DegreesOfFreedom(n1, s1, n2, s2);
      var x̄1_x̄2 = x̄1 - x̄2;
      var target = x̄1_x̄2 /Math.Sqrt(s1*s1/n1 + s2*s2/n2);
      var p = Helpers.GetT(target, (int) dof);
      return p;
    }

    private static double DegreesOfFreedom(int n1, double s1, int n2, double s2) {
      return Math.Pow(s1*s1/n1 + s2*s2/n2, 2)/
                ((Math.Pow(s1*s1/n1, 2)/(n1 - 1)) + (Math.Pow(s2*s2/n2, 2)/(n2 - 1)));
    }
  }
}