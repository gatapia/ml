using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// Converts a nominal attribute (that is, a set number of values) to string
  /// (that is, an unspecified number of values).
  /// </summary>
  public class NominalToString<T> : BaseFilter<T>
  {
    public NominalToString(Runtime<T> rt) : base(rt, new NominalToString()) {}

    /// <summary>
    /// Sets a range attributes to process. Any non-nominal attributes in the
    /// range are left untouched ("first" and "last" are valid values)
    /// </summary>    
    public NominalToString<T> AttributeIndexes (string value) {
      ((NominalToString)impl).setAttributeIndexes(value);
      return this;
    }
        
  }
}