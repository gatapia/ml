using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Standardizes all numeric attributes in the given dataset to have zero
  /// mean and unit variance (apart from the class attribute, if
  /// set).<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index
  /// temporarily before the filter is<br/>	applied to the data.<br/>	(default: no)
  /// </summary>
  public class Standardize<T> : BaseFilter<T, Standardize> where T : new()
  {
    public Standardize(Runtime<T> rt) : base(rt, new Standardize()) {}

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Standardize<T> IgnoreClass (bool newIgnoreClass) {
      ((Standardize)Impl).setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}