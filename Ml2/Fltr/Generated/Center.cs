using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Centers all numeric attributes in the given dataset to have zero mean
  /// (apart from the class attribute, if set).
  /// </summary>
  public class Center<T> : BaseFilter<T>
  {
    public Center(Runtime<T> rt) : base(rt, new Center()) {}

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Center<T> IgnoreClass (bool value) {
      ((Center)impl).setIgnoreClass(value);
      return this;
    }

        
        
  }
}