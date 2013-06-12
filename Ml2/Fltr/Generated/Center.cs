using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
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
    /// 
    /// </summary>    
    public Center<T> InputFormat (Runtime<T> instanceInfo) {
      ((Center)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Center<T> IgnoreClass (bool newIgnoreClass) {
      ((Center)Impl).setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}