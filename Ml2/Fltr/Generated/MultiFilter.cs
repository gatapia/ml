using weka.filters;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Applies several filters successively. In case all supplied filters are
  /// StreamableFilters, it will act as a streamable one,
  /// too.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-F &lt;classname
  /// [options]&gt; = 	A filter to apply (can be specified multiple times).
  /// </summary>
  public class MultiFilter<T> : BaseFilter<T, MultiFilter> where T : new()
  {
    public MultiFilter(Runtime<T> rt) : base(rt, new MultiFilter()) {}

    /// <summary>
    /// The base filters to be used.
    /// </summary>    
    public MultiFilter<T> Filters (Fltr.IBaseFilter<T, weka.filters.Filter>[] filters) {
      ((MultiFilter)Impl).setFilters(filters.Select(v => v.Impl).ToArray());
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public MultiFilter<T> Debug (bool value) {
      ((MultiFilter)Impl).setDebug(value);
      return this;
    }

        
        
  }
}