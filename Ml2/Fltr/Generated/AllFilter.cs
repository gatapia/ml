using weka.core;
using weka.filters;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that passes all instances through unmodified.
  /// Primarily for testing purposes.
  /// </summary>
  public class AllFilter<T> : BaseFilter<T>
  {
    public AllFilter(Runtime<T> rt) : base(rt, new AllFilter()) {}

    /// <summary>
    /// 
    /// </summary>    
    public AllFilter<T> InputFormat (Runtime<T> value) {
      ((AllFilter)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}