using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that adds a new nominal attribute representing the cluster
  /// assigned to each instance by the specified clustering algorithm. Either the
  /// clustering algorithm gets built with the first batch of data or one specifies
  /// are serialized clusterer model file to use instead.
  /// </summary>
  public class AddCluster<T> : BaseFilter<T>
  {
    public AddCluster(Runtime<T> rt) : base(rt, new AddCluster()) {}

    /// <summary>
    /// The range of attributes to be ignored by the clusterer. eg:
    /// first-3,5,9-last
    /// </summary>    
    public AddCluster<T> IgnoredAttributeIndices (string value) {
      ((AddCluster)impl).setIgnoredAttributeIndices(value);
      return this;
    }
        
  }
}