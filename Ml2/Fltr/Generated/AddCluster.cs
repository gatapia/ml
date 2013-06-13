using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that adds a new nominal attribute representing the cluster
  /// assigned to each instance by the specified clustering algorithm. Either the
  /// clustering algorithm gets built with the first batch of data or one specifies
  /// are serialized clusterer model file to use instead.
  /// </summary>
  public class AddCluster<T> : BaseFilter<T, AddCluster> where T : new()
  {
    public AddCluster(Runtime<T> rt) : base(rt, new AddCluster()) {}

    /// <summary>
    /// The clusterer to assign clusters with.
    /// </summary>    
    public AddCluster<T> Clusterer (Clstr.BaseClusterer<T, weka.clusterers.Clusterer> clusterer) {
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

    /// <summary>
    /// 
    /// </summary>    
    public AddCluster<T> InputFormat (Runtime<T> instanceInfo) {
      ((AddCluster)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}