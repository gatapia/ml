using System;
using System.Linq;

namespace ML.Optimisation
{
  public class RegularisedGradientDescent : GradientDescent
  {
    private readonly double λ;
    public RegularisedGradientDescent(TrainingSet t, double[] Θ, Func<TrainingSet, 
          double[], double> costfn, Func<double[], double[], double> hypothesis, double λ) : 
          base(t, Θ, costfn, hypothesis) {
      
      this.λ = λ;
    }
    
    // θj := θj - α * 1/m ∑₁.m ((x⁽ⁱ⁾) - y⁽ⁱ⁾) * x⁽ⁱ⁾ - 
    public override double Derivative(TrainingSet t, double[] Θ, int j)
    {
      return (1.0/t.Count) * t.Sum(ei => (hypothesis(ei.xi, Θ) - ei.yi) * ei.xi[j]) - 
          (j == 0 ? 0 : λ/t.m * Θ[j]);
    }
  }
}