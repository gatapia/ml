using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// A filter that uses a density-based clusterer to generate cluster
  /// membership values; filtered instances are composed of these values plus the class
  /// attribute (if set in the input data). If a (nominal) class attribute is set,
  /// the clusterer is run separately for each class. The class attribute (if
  /// set) and any user-specified attributes are ignored during the clustering
  /// operation
  /// </summary>
  public class ClusterMembership<T> : BaseFilter<T>
  {
    public ClusterMembership(Runtime<T> rt) : base(rt, new ClusterMembership()) {}

    /// <summary>
    /// The range of attributes to be ignored by the clusterer. eg:
    /// first-3,5,9-last
    /// </summary>    
    public ClusterMembership<T> IgnoredAttributeIndices (string value) {
      ((ClusterMembership)impl).setIgnoredAttributeIndices(value);
      return this;
    }
        
  }
}