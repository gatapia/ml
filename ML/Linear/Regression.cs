using System;
using System.Diagnostics;
using System.Linq;

namespace ML.Linear
{
  public static class Regression
  {

    /// <summary>
    /// hθ(x) = θ₀x₀ + θ₁x₁ + ... + θₙxₙ
    /// This is equivalent to θᵀx
    /// </summary>
    /// <param name="xs">The input features vector for the ith training example.</param>
    /// <param name="Θ">The hypothesis parameters.</param>
    /// <returns></returns>
    public static double Hypothesis(double[] xs, double[] Θ)
    {
      Trace.Assert(Equals(xs[0], 1.0), "For convenience x₀ should always equal 1.");
      Trace.Assert(xs.Length == Θ.Length);

      return xs.Zip(Θ, (xi, θi) => xi * θi).Sum();
    }

    // J(Θ) -> 1/2m ∑₁.m ((x⁽ⁱ⁾) - y⁽ⁱ⁾)²
    public static double CostFunction(TrainingSet t, double[] Θ)
    {
      return (1.0 / (2.0 * t.Count)) *
             t.Sum(ei => CostFunctionImpl(ei.xi, ei.yi, Θ));
    }

    private static double CostFunctionImpl(double[] xi, double yi, double[] Θ)
    {
      return Math.Pow(Hypothesis(xi, Θ) - yi, 2);
    }
  }
}