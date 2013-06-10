using weka.filters.supervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// A supervised attribute filter that can be used to select attributes. It
  /// is very flexible and allows various search and evaluation methods to be
  /// combined.
  /// </summary>
  public class AttributeSelection<T> : BaseFilter<T>
  {
    public AttributeSelection(Runtime<T> rt) : base(rt, new AttributeSelection()) {}

        
  }
}