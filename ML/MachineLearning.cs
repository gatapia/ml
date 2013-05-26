using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ML
{
  /// <summary>
  /// Notation:
  /// m = Number of training examples
  /// x's -> "input" variables/features
  /// y's -> "output"/"target" vartiable
  /// x⁽i⁾ -> Ith input variable, e.g.: x⁽³⁾ -> The 3rd input variable.
  /// (x⁽i⁾, y⁽i⁾) -> Ith training example, e.g.: x⁽³⁾, y⁽³⁾ -> The 3rd training example
  /// hθ(x) -> The hypothesis (maps x's to y's)
  /// θi -> The ith parameters
  /// (x) = θ₀ + θ₁x -> univariate linear regression
  /// J(θ₀, θ₁) -> Cost function
  /// J(θ₀, θ₁) -> 1/2m ∑₁.m ((x(i)) - y(i))²
  /// 
  /// Multivariate:
  /// n -> Number of features
  /// x⁽³⁾ -> The 3rd set of input features, this is a vector
  /// x₁⁽³⁾ -> The first feeature of the 3rd feature set.
  /// For convenience: x₀⁽i⁾ = 1
  /// Θ -> All parameters
  /// </summary>
  public class MachineLearning
  {

  }

  public class Example
  {
    public double[] xi { get; set; }
    public double yi { get; set; }

    public Example Scale(double[] μs, double[] rs)
    {
      var n = xi.Length;
      var xi2 = new double[n];
      for (int i = 0; i < n; i++)
      {
        // (xi-μi)/range(xs)
        xi2[i] = (xi2[i] - μs[i])/rs[i];
      }
      return new Example {xi = xi2, yi = yi};
    }
  }

  public class FeatureScaling
  {
    /// <summary>
    /// Will get every feature into a -1 ≤ xi ≤ 1 range. This done by
    /// xi = (xi-μi)/range(xs)
    /// </summary>
    /// <param name="training"></param>
    /// <returns></returns>
    public ICollection<Example> Scale(ICollection<Example> training)
    {
      var e1 = training.First();
      var n = e1.xi.Length;
      var μs = new double[n];
      var rs = new double[n];
      for (int i = 0; i < n; i++)
      {
        μs[i] = training.Average(e => e.xi[i]);
        rs[i] = training.Max(e => e.xi[i]) - training.Min(e => e.xi[i]);
      }
      return training.Select(e => e.Scale(μs, rs)).ToArray();
    }
  }


  public static class LinearRegression
  {

    /// <summary>
    /// hθ(x) = θ₀x₀ + θ₁x₁ + ... + θnxn
    /// This is equivalent to θTx (theta transpose * x)
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

    // J(Θ) -> 1/2m ∑₁.m ((x(i)) - y(i))²
    public static double CostFunction(ICollection<Example> training, double[] Θ)
    {
      return (1.0 / (2.0 * training.Count)) *
             training.Sum(ei => CostFunctionImpl(ei.xi, ei.yi, Θ));
    }

    private static double CostFunctionImpl(double[] xi, double yi, double[] Θ)
    {
      return Math.Pow(Hypothesis(xi, Θ) - yi, 2);
    }
  }

  public class LinearRegressionGradientDescent
  {
    private int max = 1000000;
    private double precision = 1e-3;    
    private double α = 1e-6;

    private double[] Θ;
    private readonly ICollection<Example> training;

    public LinearRegressionGradientDescent(ICollection<Example> training, double[] Θ)
    {
      this.training = training;
      this.Θ = Θ;
    }

    public int Max { get { return max; } set { max = value; } }
    public double Precision { get { return precision; } set { precision = value; } }
    public double Alpha { get { return α; } set { α = value; } }

    public void Optimize()
    {
      double min = Double.MaxValue;
      for (int i = 0; i < Max; i++)
      {
        double cost = LinearRegression.CostFunction(training, Θ);
        if (Math.Abs(cost - min) <= Precision) return;
        Trace.Assert(cost <= min, "Cost should decrease after every iteration. Try smaller α [" + α + "]");
        min = cost;

        double[] tmpΘ = Θ.Select(GetNextθj).ToArray();
        Θ = tmpΘ;
      }
      throw new ApplicationException("Did not converge.");
    }

    // θj := θj - α * (∂/∂θj J(Θ))
    private double GetNextθj(double θj, int j)
    {
      return θj - Alpha * Derivative(j);
    }

    // θj := θj - α/m * ∑₁.m ((x(i)) - y(i)) * x(i)
    private double Derivative(int j)
    {
      return (1.0/training.Count) *
        training.Sum(ei => 
            (ei.xi[j]) * ErrorFunction(ei.xi, ei.yi));
    }

    public double ErrorFunction(double[] xi, double yi)
    {
      return LinearRegression.Hypothesis(xi, Θ) - yi;
    }
  }
}