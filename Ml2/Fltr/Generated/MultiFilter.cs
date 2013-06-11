using weka.core;
using weka.filters;

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
    /// Turns on output of debugging information.
    /// </summary>    
    public MultiFilter<T> Debug (bool value) {
      ((MultiFilter)impl).setDebug(value);
      return this;
    }

        
        
  }
}