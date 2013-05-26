using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;

namespace ML
{
  public class TrainingSet : List<TrainingExample>
  {

    public int NumFeatures { get; private set; }
    public int n { get { return NumFeatures; } }
    public int m { get { return Count; } }

    public TrainingSet(IEnumerable<TrainingExample> trainingset) : base(trainingset)
    {
      if (Count == 0) throw new ApplicationException("Empty TrainingSet is not supported.");
      NumFeatures = this.First().xi.Length;
    }

    /// <summary>
    /// Will get every feature into a -1 ≤ xᵢ ≤ 1 range. This done by
    /// xᵢ = (xᵢ-μᵢ)/range(xs)
    /// </summary>
    public TrainingSet Scale()
    {
      var μs = new double[n];
      var rs = new double[n];
      for (var i = 0; i < n; i++)
      {
        μs[i] = this.Average(e => e.xi[i]);
        rs[i] = this.Max(e => e.xi[i]) - this.Min(e => e.xi[i]);
      }
      return new TrainingSet(this.Select(e => e.Scale(μs, rs)).ToArray());
    }

    public DenseMatrix ToFeatureMatrix()
    {
      return DenseMatrix.OfRows(m, n, this.Select(t => t.xi));
    }

    public DenseVector ToOutputVector()
    {
      return DenseVector.OfEnumerable(this.Select(t => t.yi));
    }
  }
}