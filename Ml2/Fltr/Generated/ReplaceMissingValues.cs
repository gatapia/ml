using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

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
    /// 
    /// </summary>    
    public ReplaceMissingValues<T> InputFormat (Runtime<T> value) {
      ((ReplaceMissingValues)Impl).setInputFormat(value.Instances);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public ReplaceMissingValues<T> IgnoreClass (bool value) {
      ((ReplaceMissingValues)Impl).setIgnoreClass(value);
      return this;
    }

        
        
  }
}