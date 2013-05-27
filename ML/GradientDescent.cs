using System;
using System.Diagnostics;
using System.Linq;

namespace ML
{
  public class GradientDescent
  {
    private int max = 1000000;
    private double precision = 1e-3;    
    private double α = 1e-6;

    private double[] Θ;
    private readonly TrainingSet t;
    private readonly Func<TrainingSet, double[], double> costfn;
    private readonly Func<double[], double[], double> hypothesis;

    public GradientDescent(TrainingSet t, double[] Θ, Func<TrainingSet, 
          double[], double> costfn, Func<double[], double[], double> hypothesis)
    {
      if(!t.All(e => Equals(e.xi[0], 1.0))) throw new ApplicationException("It is expected that all x₀ be 1."); 

      this.t = t;
      this.Θ = Θ;
      this.costfn = costfn;
      this.hypothesis = hypothesis;
    }

    public int Max { get { return max; } set { max = value; } }
    public double Precision { get { return precision; } set { precision = value; } }
    public double Alpha { get { return α; } set { α = value; } }

    public double[] Optimize()
    {
      double min = Double.MaxValue;
      for (int i = 0; i < Max; i++)
      {
        double cost = costfn(t, Θ);
        if (Math.Abs(cost - min) <= Precision) return Θ;
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
      return θj - Alpha * Derivative(t, Θ, j);
    }    

    
    // θj := θj - α/m * ∑₁.m ((x⁽ⁱ⁾) - y⁽ⁱ⁾) * x⁽ⁱ⁾
    public double Derivative(TrainingSet t, double[] Θ, int j)
    {
      return (1.0/t.Count) * t.Sum(ei => (hypothesis(ei.xi, Θ) - ei.yi) * ei.xi[j]);
    }
  }
}