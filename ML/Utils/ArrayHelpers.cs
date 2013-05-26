using System.Diagnostics;
using System.Linq;

namespace ML.Utils
{
  public static class ArrayHelpers
  {
    public static double[][] Transpose(double[][] a) {
      Trace.Assert(a.Length > 0);
      Trace.Assert(a[0].Length > 0);
      Trace.Assert(a.All(ai => ai.Length == a[0].Length));

      var width = a.Length;
      var height = a[0].Length;
      double[][] b = new double[height][];
      for (int i = 0; i < width; i++) {         
        for (int j = 0; j < height; j++) { 
          if (i == 0) b[j] = new double[width];
          b[j][i] = a[i][j]; 
        } 
      }
      return b;
    }
  }
}