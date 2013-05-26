using System;
using System.Diagnostics;
using System.Linq;

namespace ML.LinearRegression
{
  public class LinearRegressionGradientDescent
  {
    private int max = 1000000;
    private double precision = 1e-3;    
    private double α = 1e-6;

    private double[] Θ;
    private readonly TrainingSet training;

    public LinearRegressionGradientDescent(TrainingSet training, double[] Θ)
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

    // θⱼ := θⱼ - α * (∂/∂θj J(Θ))
    private double GetNextθj(double θj, int j)
    {
      return θj - Alpha * Derivative(j);
    }

    // θⱼ := θⱼ - α/m * ∑₁.m ((x⁽ⁱ⁾) - y⁽ⁱ⁾) * x⁽ⁱ⁾
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