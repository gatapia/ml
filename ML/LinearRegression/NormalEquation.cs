using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;

namespace ML
{
  /// <summary>
  /// Θ := (XTX)⁻¹ * XTy (XT is transpose of X)
  /// </summary>
  public class NormalEquation
  {
    public static double[] Calculate(TrainingSet training)
    {
      ValidateTrainingSet(training);

      if (training.NumFeatures > 10000) throw new ApplicationException("When the number of features is > 10000 use Gradient Descent.");

      var X = DenseMatrix.OfRows(training.m, training.n, training.Select(t => t.xi));
      var XT = X.Transpose();
      var y = DenseVector.OfEnumerable(training.Select(t => t.yi));
      var result = (XT*X).Inverse()*(XT*y);
      return result.ToArray();
    }

    private static void ValidateTrainingSet(TrainingSet training)
    {
      if(!training.All(e => e.xi[0] == 1)) throw new ApplicationException("It is expected that all x₀ be 1."); 
    }
  }
}
