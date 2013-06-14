using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Swaps two values of a nominal attribute.<br/><br/>Options:<br/><br/>-C
  /// &lt;col&gt; = 	Sets the attribute index (default last).<br/>-F &lt;value
  /// index&gt; = 	Sets the first value's index (default first).<br/>-S &lt;value
  /// index&gt; = 	Sets the second value's index (default last).
  /// </summary>
  public class SwapValues<T> : BaseFilter<T, SwapValues> where T : new()
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

        
        
  }
}