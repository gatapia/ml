using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Converts a nominal attribute (that is, a set number of values) to string
  /// (that is, an unspecified number of values).
  /// </summary>
  public class NominalToString<T> : BaseFilter<T, NominalToString> where T : new()
  {
    public NominalToString(Runtime<T> rt) : base(rt, new NominalToString()) {}

    /// <summary>
    /// Sets a range attributes to process. Any non-nominal attributes in the
    /// range are left untouched ("first" and "last" are valid values)
    /// </summary>    
    public NominalToString<T> AttributeIndexes (string attIndex) {
      ((NominalToString)Impl).setAttributeIndexes(attIndex);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public NominalToString<T> InputFormat (Runtime<T> instanceInfo) {
      ((NominalToString)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}