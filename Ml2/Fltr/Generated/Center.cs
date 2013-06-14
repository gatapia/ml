using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Centers all numeric attributes in the given dataset to have zero mean
  /// (apart from the class attribute, if
  /// set).<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before the filter
  /// is<br/>	applied to the data.<br/>	(default: no)
  /// </summary>
  public class Center<T> : BaseFilter<T, Center> where T : new()
  {
    public Center(Runtime<T> rt) : base(rt, new Center()) {}

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Center<T> IgnoreClass (bool newIgnoreClass) {
      ((Center)Impl).setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}