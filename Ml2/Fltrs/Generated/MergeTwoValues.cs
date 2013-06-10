using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// Merges two values of a nominal attribute into one value.
  /// </summary>
  public class MergeTwoValues<T> : BaseFilter<T>
  {
    public MergeTwoValues(Runtime<T> rt) : base(rt, new MergeTwoValues()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public MergeTwoValues<T> AttributeIndex (string value) {
      ((MergeTwoValues)impl).setAttributeIndex(value);
      return this;
    }
    /// <summary>
    /// Sets the first value to be merged. ("first" and "last" are valid values)
    /// </summary>    
    public MergeTwoValues<T> FirstValueIndex (string value) {
      ((MergeTwoValues)impl).setFirstValueIndex(value);
      return this;
    }
    /// <summary>
    /// Sets the second value to be merged. ("first" and "last" are valid values)
    /// </summary>    
    public MergeTwoValues<T> SecondValueIndex (string value) {
      ((MergeTwoValues)impl).setSecondValueIndex(value);
      return this;
    }
        
  }
}