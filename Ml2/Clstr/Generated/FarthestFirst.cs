using weka.clusterers;

namespace Ml2.Clstr
{
  /// <summary>
  /// Cluster data using the FarthestFirst algorithm. For more information see:
  /// Hochbaum, Shmoys (1985). A best possible heuristic for the k-center
  /// problem. Mathematics of Operations Research. 10(2):180-184. Sanjoy Dasgupta:
  /// Performance Guarantees for Hierarchical Clustering. In: 15th Annual Conference
  /// on Computational Learning Theory, 351-363, 2002. Notes: - works as a fast
  /// simple approximate clusterer - modelled after SimpleKMeans, might be a
  /// useful initializer for it
  /// </summary>
  public class FarthestFirst<T> : BaseClusterer<T>
  {
    private readonly FarthestFirst impl = new FarthestFirst();
    
    public FarthestFirst(Runtime<T> rt) : base(rt) {}

    /// <summary>
    /// set number of clusters
    /// </summary>    
    public FarthestFirst<T> NumClusters (int value) {
      impl.setNumClusters(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public FarthestFirst<T> Seed (int value) {
      impl.setSeed(value);
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