using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;

namespace ML.LinearRegression
{
  /// <summary>
  /// Θ := (XᵀX)⁻¹ * Xᵀy
  /// </summary>
  public class NormalEquation
  {
    public static double[] Calculate(TrainingSet training)
    {
      if(!training.All(e => Equals(e.xi[0], 1.0))) throw new ApplicationException("It is expected that all x₀ be 1."); 
      if (training.NumFeatures > 10000) throw new ApplicationException("When the number of features is > 10000 use Gradient Descent.");

      var X = DenseMatrix.OfRows(training.m, training.n, training.Select(t => t.xi));
      var XT = X.Transpose();
      var y = DenseVector.OfEnumerable(training.Select(t => t.yi));
      var result = (XT*X).Inverse()*(XT*y);
      return result.ToArray();
    }
  }
}
