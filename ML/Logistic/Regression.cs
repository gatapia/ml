using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;

namespace ML.Logistic
{
  /// <summary>
  ///   Notation:
  ///   y ∈ {0, 1} -> The output variable is either 0 or 1.
  ///   0 ≤ hθ(x) ≤ 1
  ///   hθ(x) = g(Θᵀx)
  ///   g(z) = 1/(1+e⁻ᶻ)
  ///   hθ(x) = 1/(1 + e⁻ᶿᵀˣ)
  ///   Gradient Descent for logistic regression has other alternatives not
  ///   covered in the ML course.  These include: Conjugate Gradient, BFGS, L-BFGS
  ///   To do multi class classification what we do is the one-vs-all method.  This
  ///   takes a multi class peroblem and turns it into many 0/1 problems.
  /// </summary>
  public static class Regression
  {
    // hθ(x) = 1/(1 + e⁻ᶿᵀˣ)
    public static double Sigmoid(double[] Θ, double[] x) {
      Trace.Assert(x.Length > 0 && Θ.Length == x.Length, "Features and parameters should be same length.");
      Trace.Assert(x[0].Equals(1.0), "X₀ should always be 1");

      return G(θTx(Θ, x));
    }

    public static double G(double z) {
      return 1/(1 + (Math.Pow(Math.E, -z)));
    }

    public static bool Predict1(double[] Θ, double[] x) {
      return θTx(Θ, x) >= 0.0;
    }

    // -1/m * ∑₁..m [y⁽ⁱ⁾ log hθ(x⁽ⁱ⁾) + (1-y⁽ⁱ⁾) log(1-hθ(x⁽ⁱ⁾))]
    public static double CostFunction(TrainingSet t, double[] Θ) {
      return (-1.0/t.m)*t.Sum(e => {
        var hθxi = Sigmoid(Θ, e.xi);
        return e.yi*Math.Log(hθxi) + (1 - e.yi)*Math.Log(1 - hθxi);
      });
    }

    public static double RegularisedCostFunction(TrainingSet t, double[] Θ, double λ) {
      return (-1.0/t.m)*t.Sum(e => {
        var hθxi = Sigmoid(Θ, e.xi);
        return e.yi*Math.Log(hθxi) + (1 - e.yi)*Math.Log(1 - hθxi);
      }) + (λ/(2*t.m))*Θ.Skip(1).Sum(θ => θ*θ);
    }

    private static double θTx(IEnumerable<double> Θ, IEnumerable<double> x) {
      return DenseVector.OfEnumerable(x).DotProduct(DenseVector.OfEnumerable(Θ));
    }
  }
}