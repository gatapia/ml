using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that uses a density-based clusterer to generate cluster
  /// membership values; filtered instances are composed of these values plus the class
  /// attribute (if set in the input data). If a (nominal) class attribute is set,
  /// the clusterer is run separately for each class. The class attribute (if
  /// set) and any user-specified attributes are ignored during the clustering
  /// operation<br/><br/>Options:<br/><br/>-W &lt;clusterer name&gt; = 	Full name of
  /// clusterer to use. eg:<br/>		weka.clusterers.EM<br/>	Additional options
  /// after the '--'.<br/>	(default: weka.clusterers.EM)<br/>-I
  /// &lt;att1,att2-att4,...&gt; = 	The range of attributes the clusterer should ignore.<br/>	(the
  /// class attribute is automatically ignored)
  /// </summary>
  public class ClusterMembership<T> : BaseFilter<T, ClusterMembership> where T : new()
  {
    public ClusterMembership(Runtime<T> rt) : base(rt, new ClusterMembership()) {}

    /// <summary>
    /// The range of attributes to be ignored by the clusterer. eg:
    /// first-3,5,9-last
    /// </summary>    
    public ClusterMembership<T> IgnoredAttributeIndices (string rangeList) {
      ((ClusterMembership)Impl).setIgnoredAttributeIndices(rangeList);
      return this;
    }

        
        
  }
}