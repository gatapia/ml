using weka.filters;

namespace Ml2.Fltrs
{
  /// <summary>
  /// An instance filter that passes all instances through unmodified.
  /// Primarily for testing purposes.
  /// </summary>
  public class AllFilter<T> : BaseFilter<T>
  {
    public AllFilter(Runtime<T> rt) : base(rt, new AllFilter()) {}

        
  }
}