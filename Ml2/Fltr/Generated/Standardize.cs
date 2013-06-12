using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// Standardizes all numeric attributes in the given dataset to have zero
  /// mean and unit variance (apart from the class attribute, if set).
  /// </summary>
  public class Standardize<T> : BaseFilter<T>
  {
    public Standardize(Runtime<T> rt) : base(rt, new Standardize()) {}

    /// <summary>
    /// 
    /// </summary>    
    public Standardize<T> InputFormat (Runtime<T> value) {
      ((Standardize)Impl).setInputFormat(value.Instances);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Standardize<T> IgnoreClass (bool value) {
      ((Standardize)Impl).setIgnoreClass(value);
      return this;
    }

        
        
  }
}