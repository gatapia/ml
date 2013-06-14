using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that uses a PartitionGenerator to generate partition membership
  /// values; filtered instances are composed of these values plus the class
  /// attribute (if set in the input data) and rendered as sparse
  /// instances.<br/><br/>Options:<br/><br/>-W &lt;name of partition generator&gt; = 	Full name of
  /// partition generator to use,
  /// e.g.:<br/>		weka.classifiers.trees.J48<br/>	Additional options after the '--'.<br/>	(default: weka.classifiers.trees.J48)
  /// </summary>
  public class PartitionMembership<T> : BaseFilter<T, PartitionMembership> where T : new()
  {
    public PartitionMembership(Runtime<T> rt) : base(rt, new PartitionMembership()) {}

        
        
  }
}