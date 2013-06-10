using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that applies filters on subsets of attributes and assembles the
  /// output into a new dataset. Attributes that are not covered by any of the
  /// ranges can be either retained or removed from the output.
  /// </summary>
  public class PartitionedMultiFilter<T> : BaseFilter<T>
  {
    public PartitionedMultiFilter(Runtime<T> rt) : base(rt, new PartitionedMultiFilter()) {}

    /// <summary>
    /// If true then unused attributes (ones that are not covered by any of the
    /// ranges) will be removed from the output.
    /// </summary>    
    public PartitionedMultiFilter<T> RemoveUnused (bool value) {
      ((PartitionedMultiFilter)impl).setRemoveUnused(value);
      return this;
    }
    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public PartitionedMultiFilter<T> Debug (bool value) {
      ((PartitionedMultiFilter)impl).setDebug(value);
      return this;
    }
        
  }
}