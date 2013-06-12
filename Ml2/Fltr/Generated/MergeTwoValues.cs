using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
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
      ((MergeTwoValues)Impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// Sets the first value to be merged. ("first" and "last" are valid values)
    /// </summary>    
    public MergeTwoValues<T> FirstValueIndex (string value) {
      ((MergeTwoValues)Impl).setFirstValueIndex(value);
      return this;
    }

    /// <summary>
    /// Sets the second value to be merged. ("first" and "last" are valid values)
    /// </summary>    
    public MergeTwoValues<T> SecondValueIndex (string value) {
      ((MergeTwoValues)Impl).setSecondValueIndex(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MergeTwoValues<T> InputFormat (Runtime<T> value) {
      ((MergeTwoValues)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}