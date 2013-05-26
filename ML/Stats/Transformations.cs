using System;

namespace ML.Stats
{
  public static class Transformations
  {
    public static double[] Log10(double[] ys) {
      var transformed = new double[ys.Length];
      for (int i = 0; i < ys.Length; i++) {
        transformed[i] = Math.Log10(ys[i]);
      }
      return transformed;
    }
  }
}