using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Merges many values of a nominal attribute into one value.
  /// </summary>
  public class MergeManyValues<T> : BaseFilter<T>
  {
    public MergeManyValues(Runtime<T> rt) : base(rt, new MergeManyValues()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public MergeManyValues<T> AttributeIndex (string value) {
      ((MergeManyValues)impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// The new label for the merged values.
    /// </summary>    
    public MergeManyValues<T> Label (string value) {
      ((MergeManyValues)impl).setLabel(value);
      return this;
    }

    /// <summary>
    /// The range of values to merge.
    /// </summary>    
    public MergeManyValues<T> MergeValueRange (string value) {
      ((MergeManyValues)impl).setMergeValueRange(value);
      return this;
    }

        
        
  }
}