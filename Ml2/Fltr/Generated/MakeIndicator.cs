using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that creates a new dataset with a boolean attribute replacing a
  /// nominal attribute. In the new dataset, a value of 1 is assigned to an
  /// instance that exhibits a particular range of attribute values, a 0 to an
  /// instance that doesn't. The boolean attribute is coded as numeric by default.
  /// </summary>
  public class MakeIndicator<T> : BaseFilter<T>
  {
    public MakeIndicator(Runtime<T> rt) : base(rt, new MakeIndicator()) {}

    /// <summary>
    /// Sets which attribute should be replaced by the indicator. This attribute
    /// must be nominal.
    /// </summary>    
    public MakeIndicator<T> AttributeIndex (string value) {
      ((MakeIndicator)impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MakeIndicator<T> ValueIndex (int value) {
      ((MakeIndicator)impl).setValueIndex(value);
      return this;
    }

    /// <summary>
    /// Determines whether the output indicator attribute is numeric. If this is
    /// set to false, the output attribute will be nominal.
    /// </summary>    
    public MakeIndicator<T> Numeric (bool value) {
      ((MakeIndicator)impl).setNumeric(value);
      return this;
    }

    /// <summary>
    /// Specify range of nominal values to act on. This is a comma separated list
    /// of attribute indices (numbered from 1), with "first" and "last" valid
    /// values. Specify an inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public MakeIndicator<T> ValueIndices (string value) {
      ((MakeIndicator)impl).setValueIndices(value);
      return this;
    }

        
        
  }
}