using weka.core;
using weka.clusterers;

namespace Ml2.Clstr
{
  /// <summary>
  /// Hierarchical clustering class. Implements a number of classic
  /// agglomorative (i.e. bottom up) hierarchical clustering methodsbased on .
  /// </summary>
  public class Hierarchical<T> : BaseClusterer<T>
  {    
    public Hierarchical(Runtime<T> rt) : base(rt, new HierarchicalClusterer()) {}

    /// <summary>
    /// Sets the number of clusters. If a single hierarchy is desired, set this
    /// to 1.
    /// </summary>    
    public Hierarchical<T> NumClusters (int value) {
      ((HierarchicalClusterer)Impl).setNumClusters(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Hierarchical<T> Debug (bool value) {
      ((HierarchicalClusterer)Impl).setDebug(value);
      return this;
    }

    /// <summary>
    /// If set to false, the distance between clusters is interpreted as the
    /// height of the node linking the clusters. This is appropriate for example for
    /// single link clustering. However, for neighbor joining, the distance is better
    /// interpreted as branch length. Set this flag to get the latter
    /// interpretation.
    /// </summary>    
    public Hierarchical<T> DistanceIsBranchLength (bool value) {
      ((HierarchicalClusterer)Impl).setDistanceIsBranchLength(value);
      return this;
    }

    /// <summary>
    /// Sets the method used to measure the distance between two clusters.
    /// SINGLE: find single link distance aka minimum link, which is the closest distance
    /// between any item in cluster1 and any item in cluster2 COMPLETE: find
    /// complete link distance aka maximum link, which is the largest distance between
    /// any item in cluster1 and any item in cluster2 ADJCOMLPETE: as COMPLETE, but
    /// with adjustment, which is the largest within cluster distance AVERAGE:
    /// finds average distance between the elements of the two clusters MEAN:
    /// calculates the mean distance of a merged cluster (akak Group-average agglomerative
    /// clustering) CENTROID: finds the distance of the centroids of the clusters
    /// WARD: finds the distance of the change in caused by merging the cluster. The
    /// information of a cluster is calculated as the error sum of squares of the
    /// centroids of the cluster and its members. NEIGHBOR_JOINING use neighbor
    /// joining algorithm.
    /// </summary>    
    public Hierarchical<T> LinkType (ELinkType value) {
      ((HierarchicalClusterer)Impl).setLinkType(new SelectedTag((int) value, HierarchicalClusterer.TAGS_LINK_TYPE));
      return this;
    }

    /// <summary>
    /// Flag to indicate whether the cluster should be print in Newick format.
    /// This can be useful for display in other programs. However, for large datasets
    /// a lot of text may be produced, which may not be a nuisance when the Newick
    /// format is not required
    /// </summary>    
    public Hierarchical<T> PrintNewick (bool value) {
      ((HierarchicalClusterer)Impl).setPrintNewick(value);
      return this;
    }

            

    public enum ELinkType {
      SINGLE = 0,
      COMPLETE = 1,
      AVERAGE = 2,
      MEAN = 3,
      CENTROID = 4,
      WARD = 5,
      ADJCOMLPETE = 6,
      NEIGHBOR_JOINING = 7
    }

        
  }
}