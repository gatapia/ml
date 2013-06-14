using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that adds a new nominal attribute representing the cluster
  /// assigned to each instance by the specified clustering algorithm.<br/>Either the
  /// clustering algorithm gets built with the first batch of data or one
  /// specifies are serialized clusterer model file to use
  /// instead.<br/><br/>Options:<br/><br/>-W &lt;clusterer specification&gt; = 	Full class name of clusterer
  /// to use, followed<br/>	by scheme options.
  /// eg:<br/>		"weka.clusterers.SimpleKMeans -N 3"<br/>	(default: weka.clusterers.SimpleKMeans)<br/>-serialized
  /// &lt;file&gt; = 	Instead of building a clusterer on the data, one can also
  /// provide<br/>	a serialized model and use that for adding the clusters.<br/>-I
  /// &lt;att1,att2-att4,...&gt; = 	The range of attributes the clusterer should
  /// ignore.<br/>
  /// </summary>
  public class AddCluster<T> : BaseFilter<T, AddCluster> where T : new()
  {
    public AddCluster(Runtime<T> rt) : base(rt, new AddCluster()) {}

    /// <summary>
    /// The clusterer to assign clusters with.
    /// </summary>    
    public AddCluster<T> Clusterer (Clstr.IBaseClusterer<T, weka.clusterers.Clusterer> clusterer) {
      ((AddCluster)Impl).setClusterer(clusterer.Impl);
      return this;
    }

    /// <summary>
    /// The range of attributes to be ignored by the clusterer. eg:
    /// first-3,5,9-last
    /// </summary>    
    public AddCluster<T> IgnoredAttributeIndices (string rangeList) {
      ((AddCluster)Impl).setIgnoredAttributeIndices(rangeList);
      return this;
    }

        
        
  }
}