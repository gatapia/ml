using System;
using System.Linq;

namespace ML.Linear
{
  /// <summary>
  /// Θ := (XᵀX)⁻¹ * Xᵀy
  /// </summary>
  public class NormalEquation
  {
    public static double[] Calculate(TrainingSet t)
    {
      if(!t.All(e => Equals(e.xi[0], 1.0))) throw new ApplicationException("It is expected that all x₀ be 1."); 
      if (t.NumFeatures > 10000) throw new ApplicationException("When the number of features is > 10000 use Gradient Descent.");

      var X = t.ToFeatureMatrix();
      var XT = X.Transpose();
      var y = t.ToOutputVector();
      var result = (XT*X).Inverse()*(XT*y);
      return result.ToArray();
    }
  }
}
