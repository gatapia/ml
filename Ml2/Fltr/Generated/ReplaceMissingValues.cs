using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Replaces all missing values for nominal and numeric attributes in a
  /// dataset with the modes and means from the training data.
  /// </summary>
  public class ReplaceMissingValues<T> : BaseFilter<T>
  {
    public ReplaceMissingValues(Runtime<T> rt) : base(rt, new ReplaceMissingValues()) {}

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public ReplaceMissingValues<T> IgnoreClass (bool value) {
      ((weka.filters.unsupervised.attribute.ReplaceMissingValues)impl).setIgnoreClass(value);
      return this;
    }

        
        
  }
}