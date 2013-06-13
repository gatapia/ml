using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that applies filters on subsets of attributes and assembles the
  /// output into a new dataset. Attributes that are not covered by any of the
  /// ranges can be either retained or removed from the output.
  /// </summary>
  public class PartitionedMultiFilter<T> : BaseFilter<T, PartitionedMultiFilter> where T : new()
  {
    public PartitionedMultiFilter(Runtime<T> rt) : base(rt, new PartitionedMultiFilter()) {}

    /// <summary>
    /// If true then unused attributes (ones that are not covered by any of the
    /// ranges) will be removed from the output.
    /// </summary>    
    public PartitionedMultiFilter<T> RemoveUnused (bool value) {
      ((PartitionedMultiFilter)Impl).setRemoveUnused(value);
      return this;
    }

    /// <summary>
    /// The base filters to be used.
    /// </summary>    
    public PartitionedMultiFilter<T> Filters (Fltr.BaseFilter<T, weka.filters.Filter>[] filters) {
      ((PartitionedMultiFilter)Impl).setFilters(filters.Select(v => v.Impl).ToArray());
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public PartitionedMultiFilter<T> Debug (bool value) {
      ((PartitionedMultiFilter)Impl).setDebug(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public PartitionedMultiFilter<T> InputFormat (Runtime<T> instanceInfo) {
      ((PartitionedMultiFilter)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}