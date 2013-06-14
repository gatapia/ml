using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Merges two values of a nominal attribute into one value.
  /// </summary>
  public class MergeTwoValues<T> : BaseFilter<T, MergeTwoValues> where T : new()
  {
    public MergeTwoValues(Runtime<T> rt) : base(rt, new MergeTwoValues()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public MergeTwoValues<T> AttributeIndex (string attIndex) {
      ((MergeTwoValues)Impl).setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// Sets the first value to be merged. ("first" and "last" are valid values)
    /// </summary>    
    public MergeTwoValues<T> FirstValueIndex (string firstIndex) {
      ((MergeTwoValues)Impl).setFirstValueIndex(firstIndex);
      return this;
    }

    /// <summary>
    /// Sets the second value to be merged. ("first" and "last" are valid values)
    /// </summary>    
    public MergeTwoValues<T> SecondValueIndex (string secondIndex) {
      ((MergeTwoValues)Impl).setSecondValueIndex(secondIndex);
      return this;
    }

        
        
  }
}