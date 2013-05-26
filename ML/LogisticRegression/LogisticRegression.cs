using System;
using System.Collections.Generic;
using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace ML.LogisticRegression
{
  /// <summary>
  /// Notation:
  /// y ∈ {0, 1} -> The output variable is either 0 or 1.
  /// 0 ≤ hθ(x) ≤ 1
  /// hθ(x) = g(Θᵀx)
  /// g(z) = 1/(1+e⁻ᶻ)
  /// hθ(x) = 1/(1 + e⁻ᶿᵀˣ)
  /// </summary>
  public class LogisticRegression
  {
     public double Sigmoid(double[] Θ, double[] x)
     {
       Trace.Assert(x.Length > 0 && Θ.Length == x.Length, "Features and parameters should be same length.");
       Trace.Assert(x[0].Equals(1.0), "X₀ should always be 1");

       return 1/(1 + (Math.Pow(Math.E, -θTx(Θ, x))));
     }

    public bool Predict1(double[] Θ, double[] x)
    {
      return θTx(Θ, x) >= 0.0;
    }

    private static double θTx(IEnumerable<double> Θ, IEnumerable<double> x)
    {
      return DenseVector.OfEnumerable(x).DotProduct(DenseVector.OfEnumerable(Θ));
    }
  }
}