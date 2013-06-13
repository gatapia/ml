using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Merges many values of a nominal attribute into one value.
  /// </summary>
  public class MergeManyValues<T> : BaseFilter<T, MergeManyValues> where T : new()
  {
    public MergeManyValues(Runtime<T> rt) : base(rt, new MergeManyValues()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public MergeManyValues<T> AttributeIndex (string attIndex) {
      ((MergeManyValues)Impl).setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The new label for the merged values.
    /// </summary>    
    public MergeManyValues<T> Label (string alabel) {
      ((MergeManyValues)Impl).setLabel(alabel);
      return this;
    }

    /// <summary>
    /// The range of values to merge.
    /// </summary>    
    public MergeManyValues<T> MergeValueRange (string range) {
      ((MergeManyValues)Impl).setMergeValueRange(range);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MergeManyValues<T> InputFormat (Runtime<T> instanceInfo) {
      ((MergeManyValues)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}