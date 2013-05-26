using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ML.Utils;
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
    /// Creates a TrainingSet from the specified output variables and input features.
    /// </summary>
    /// <param name="ys">The output variables for each training example.</param>
    /// <param name="injectx0">Wether to add one more column to the features array (all 1s)</param>
    /// <param name="features">The features.  If this is a univariate training set then this is an array with 1 column and ys.Length rows.</param>
    /// <returns>The created TrainingSet.</returns>
    public static TrainingSet FromOutputsAndFeatures(double[] ys, bool injectx0 = true, params double[][] features) {      
      Trace.Assert(ys.Length > 0);
      Trace.Assert(features.All(xi => xi.Length == ys.Length));
      if (injectx0) {
        IList<double[]> tmp = new List<double[]>(features);
        tmp.Insert(0, Enumerable.Repeat(1.0, ys.Length).ToArray());
        features = tmp.ToArray();
      }
      var featuresT = ArrayHelpers.Transpose(features);
      return new TrainingSet(ys.Select((y, i) => new TrainingExample(y, featuresT[i])));
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