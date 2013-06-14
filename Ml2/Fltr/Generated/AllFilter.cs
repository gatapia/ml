using weka.filters;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that passes all instances through unmodified.
  /// Primarily for testing purposes.
  /// </summary>
  public class AllFilter<T> : BaseFilter<T, AllFilter> where T : new()
  {
    public AllFilter(Runtime<T> rt) : base(rt, new AllFilter()) {}

        
        
  }
}