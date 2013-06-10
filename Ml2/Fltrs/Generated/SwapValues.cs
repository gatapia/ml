using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// Swaps two values of a nominal attribute.
  /// </summary>
  public class SwapValues<T> : BaseFilter<T>
  {
    public SwapValues(Runtime<T> rt) : base(rt, new SwapValues()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public SwapValues<T> AttributeIndex (string value) {
      ((SwapValues)impl).setAttributeIndex(value);
      return this;
    }
    /// <summary>
    /// The index of the first value.("first" and "last" are valid values)
    /// </summary>    
    public SwapValues<T> FirstValueIndex (string value) {
      ((SwapValues)impl).setFirstValueIndex(value);
      return this;
    }
    /// <summary>
    /// The index of the second value.("first" and "last" are valid values)
    /// </summary>    
    public SwapValues<T> SecondValueIndex (string value) {
      ((SwapValues)impl).setSecondValueIndex(value);
      return this;
    }
        
  }
}