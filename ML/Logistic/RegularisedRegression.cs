using System;
using System.Linq;

namespace ML.Logistic
{
  public static class RegularisedRegression
  {
   
    // -1/m * ∑₁..m [y⁽ⁱ⁾ log hθ(x⁽ⁱ⁾) + (1-y⁽ⁱ⁾) log(1-hθ(x⁽ⁱ⁾))] + λ/2m * ∑₁..n θj*θj
    public static double CostFunction(TrainingSet t, double[] Θ, double λ) {
      return (-1.0/t.m)*t.Sum(e => {
        var hθxi = Regression.Sigmoid(Θ, e.xi);
        return e.yi*Math.Log(hθxi) + (1 - e.yi)*Math.Log(1 - hθxi);
      }) + (λ/(2*t.m))*Θ.Skip(1).Sum(θ => θ*θ);
    }
  }
}