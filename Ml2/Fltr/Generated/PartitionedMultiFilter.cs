using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that applies filters on subsets of attributes and assembles the
  /// output into a new dataset. Attributes that are not covered by any of the
  /// ranges can be either retained or removed from the
  /// output.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-F
  /// &lt;classname [options]&gt; = 	A filter to apply (can be specified multiple
  /// times).<br/>-R &lt;range&gt; = 	An attribute range (can be specified multiple
  /// times).<br/>	For each filter a range must be supplied. 'first' and 'last'<br/>	are
  /// valid indices. 'inv(...)' around the range denotes an<br/>	inverted
  /// range.<br/>-U = 	Flag for leaving unused attributes out of the output, by
  /// default<br/>	these are included in the filter output.
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
    public PartitionedMultiFilter<T> Filters (Fltr.IBaseFilter<T, weka.filters.Filter>[] filters) {
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

        
        
  }
}