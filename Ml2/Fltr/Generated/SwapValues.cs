using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Swaps two values of a nominal attribute.
  /// </summary>
  public class SwapValues<T> : BaseFilter<T, SwapValues>
  {
    public SwapValues(Runtime<T> rt) : base(rt, new SwapValues()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public SwapValues<T> AttributeIndex (string attIndex) {
      ((SwapValues)Impl).setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The index of the first value.("first" and "last" are valid values)
    /// </summary>    
    public SwapValues<T> FirstValueIndex (string firstIndex) {
      ((SwapValues)Impl).setFirstValueIndex(firstIndex);
      return this;
    }

    /// <summary>
    /// The index of the second value.("first" and "last" are valid values)
    /// </summary>    
    public SwapValues<T> SecondValueIndex (string secondIndex) {
      ((SwapValues)Impl).setSecondValueIndex(secondIndex);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public SwapValues<T> InputFormat (Runtime<T> instanceInfo) {
      ((SwapValues)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}