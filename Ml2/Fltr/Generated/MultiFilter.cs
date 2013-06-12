using weka.core;
using weka.filters;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// Applies several filters successively. In case all supplied filters are
  /// StreamableFilters, it will act as a streamable one, too.
  /// </summary>
  public class MultiFilter<T> : BaseFilter<T>
  {
    public MultiFilter(Runtime<T> rt) : base(rt, new MultiFilter()) {}

    /// <summary>
    /// The base filters to be used.
    /// </summary>    
    public MultiFilter<T> Filters (Fltr.BaseFilter<T>[] value) {
      ((MultiFilter)Impl).setFilters(value.Select(v => v.Impl).ToArray());
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public MultiFilter<T> Debug (bool value) {
      ((MultiFilter)Impl).setDebug(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MultiFilter<T> InputFormat (Runtime<T> value) {
      ((MultiFilter)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}