using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Reduces the dimensionality of the data by projecting it onto a lower
  /// dimensional subspace using a random matrix with columns of unit length (i.e. It
  /// will reduce the number of attributes in the data while preserving much of
  /// its variation like PCA, but at a much less computational cost). It first
  /// applies the NominalToBinary filter to convert all attributes to numeric
  /// before reducing the dimension. It preserves the class attribute. For more
  /// information, see: Dmitriy Fradkin, David Madigan: Experiments with random
  /// projections for machine learning. In: KDD '03: Proceedings of the ninth ACM SIGKDD
  /// international conference on Knowledge discovery and data mining, New York,
  /// NY, USA, 517-522, 003.
  /// </summary>
  public class RandomProjection<T> : BaseFilter<T>
  {
    public RandomProjection(Runtime<T> rt) : base(rt, new RandomProjection()) {}

    /// <summary>
    /// The percentage of dimensions (attributes) the data should be reduced to
    /// (inclusive of the class attribute). This NumberOfAttributes option is
    /// ignored if this option is present or is greater than zero.
    /// </summary>    
    public RandomProjection<T> Percent (double value) {
      ((RandomProjection)impl).setPercent(value);
      return this;
    }

    /// <summary>
    /// The number of dimensions (attributes) the data should be reduced to.
    /// </summary>    
    public RandomProjection<T> NumberOfAttributes (int value) {
      ((RandomProjection)impl).setNumberOfAttributes(value);
      return this;
    }

    /// <summary>
    /// The distribution to use for calculating the random matrix. Sparse1 is:
    /// sqrt(3) * { -1 with prob(1/6), 0 with prob(2/3), +1 with prob(1/6) } Sparse2
    /// is: { -1 with prob(1/2), +1 with prob(1/2) }
    /// </summary>    
    public RandomProjection<T> Distribution (EDistribution value) {
      ((RandomProjection)impl).setDistribution(new SelectedTag((int) value, RandomProjection.TAGS_DSTRS_TYPE));
      return this;
    }

    /// <summary>
    /// If set the filter uses
    /// weka.filters.unsupervised.attribute.ReplaceMissingValues to replace the missing values
    /// </summary>    
    public RandomProjection<T> ReplaceMissingValues (bool value) {
      ((RandomProjection)impl).setReplaceMissingValues(value);
      return this;
    }

        
    public enum EDistribution {
      Sparseone = 1,
      Sparse2 = 2,
      Gaussian = 3
    }

        
  }
}