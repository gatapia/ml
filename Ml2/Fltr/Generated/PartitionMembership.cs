using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that uses a PartitionGenerator to generate partition membership
  /// values; filtered instances are composed of these values plus the class
  /// attribute (if set in the input data) and rendered as sparse instances.
  /// </summary>
  public class PartitionMembership<T> : BaseFilter<T>
  {
    public PartitionMembership(Runtime<T> rt) : base(rt, new PartitionMembership()) {}

    /// <summary>
    /// 
    /// </summary>    
    public PartitionMembership<T> InputFormat (Runtime<T> value) {
      ((PartitionMembership)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}