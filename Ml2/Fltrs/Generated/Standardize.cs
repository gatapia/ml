using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// Standardizes all numeric attributes in the given dataset to have zero
  /// mean and unit variance (apart from the class attribute, if set).
  /// </summary>
  public class Standardize<T> : BaseFilter<T>
  {
    public Standardize(Runtime<T> rt) : base(rt, new Standardize()) {}

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Standardize<T> IgnoreClass (bool value) {
      ((Standardize)impl).setIgnoreClass(value);
      return this;
    }
        
  }
}