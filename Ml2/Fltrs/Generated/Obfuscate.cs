using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// A simple instance filter that renames the relation, all attribute names
  /// and all nominal (and string) attribute values. For exchanging sensitive
  /// datasets. Currently doesn't like string or relational attributes.
  /// </summary>
  public class Obfuscate<T> : BaseFilter<T>
  {
    public Obfuscate(Runtime<T> rt) : base(rt, new Obfuscate()) {}

        
  }
}