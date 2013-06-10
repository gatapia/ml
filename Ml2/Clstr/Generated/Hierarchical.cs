using weka.clusterers;

namespace Ml2.Clstr
{
  /// <summary>
  /// Hierarchical clustering class. Implements a number of classic
  /// agglomorative (i.e. bottom up) hierarchical clustering methodsbased on .
  /// </summary>
  public class Hierarchical<T> : BaseClusterer<T>
  {
    private readonly HierarchicalClusterer impl = new HierarchicalClusterer();
    
    public Hierarchical(Runtime<T> rt) : base(rt) {}

    /// <summary>
    /// Sets the number of clusters. If a single hierarchy is desired, set this
    /// to 1.
    /// </summary>    
    public Hierarchical<T> NumClusters (int value) {
      impl.setNumClusters(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Hierarchical<T> Debug (bool value) {
      impl.setDebug(value);
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
      impl.setDistanceIsBranchLength(value);
      return this;
    }

    /// <summary>
    /// Flag to indicate whether the cluster should be print in Newick format.
    /// This can be useful for display in other programs. However, for large datasets
    /// a lot of text may be produced, which may not be a nuisance when the Newick
    /// format is not required
    /// </summary>    
    public Hierarchical<T> PrintNewick (bool value) {
      impl.setPrintNewick(value);
      return this;
    }

        

    public override IClusterer<T> Build()
    {
      impl.buildClusterer(rt.Instances);
      return this;
    }

    public override int Classify(T row) { return impl.clusterInstance(rt.GetRowInstance(row)); }
  }
}