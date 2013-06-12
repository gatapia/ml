using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
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
      ((SwapValues)Impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// The index of the first value.("first" and "last" are valid values)
    /// </summary>    
    public SwapValues<T> FirstValueIndex (string value) {
      ((SwapValues)Impl).setFirstValueIndex(value);
      return this;
    }

    /// <summary>
    /// The index of the second value.("first" and "last" are valid values)
    /// </summary>    
    public SwapValues<T> SecondValueIndex (string value) {
      ((SwapValues)Impl).setSecondValueIndex(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public SwapValues<T> InputFormat (Runtime<T> value) {
      ((SwapValues)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}