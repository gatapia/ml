using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A simple instance filter that renames the relation, all attribute names
  /// and all nominal (and string) attribute values. For exchanging sensitive
  /// datasets. Currently doesn't like string or relational attributes.
  /// </summary>
  public class Obfuscate<T> : BaseFilter<T, Obfuscate> where T : new()
  {
    public Obfuscate(Runtime<T> rt) : base(rt, new Obfuscate()) {}

    /// <summary>
    /// 
    /// </summary>    
    public Obfuscate<T> InputFormat (Runtime<T> instanceInfo) {
      ((Obfuscate)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}