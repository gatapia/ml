using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// A simple instance filter that renames the relation, all attribute names
  /// and all nominal (and string) attribute values. For exchanging sensitive
  /// datasets. Currently doesn't like string or relational attributes.
  /// </summary>
  public class Obfuscate<T> : BaseFilter<T>
  {
    public Obfuscate(Runtime<T> rt) : base(rt, new Obfuscate()) {}

    /// <summary>
    /// 
    /// </summary>    
    public Obfuscate<T> InputFormat (Runtime<T> value) {
      ((Obfuscate)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}