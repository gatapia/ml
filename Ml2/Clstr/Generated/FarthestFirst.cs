using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Cluster data using the FarthestFirst algorithm.<br/><br/>For more
  /// information see:<br/><br/>Hochbaum, Shmoys (1985). A best possible heuristic for
  /// the k-center problem. Mathematics of Operations Research.
  /// 10(2):180-184.<br/><br/>Sanjoy Dasgupta: Performance Guarantees for Hierarchical Clustering.
  /// In: 15th Annual Conference on Computational Learning Theory, 351-363,
  /// 2002.<br/><br/>Notes:<br/>- works as a fast simple approximate clusterer<br/>-
  /// modelled after SimpleKMeans, might be a useful initializer for
  /// it<br/><br/>Options:<br/><br/>-N &lt;num&gt; = 	number of clusters. (default =
  /// 2).<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)
  /// </summary>
  public class FarthestFirst<T> : BaseClusterer<T, FarthestFirst> where T : new()
  {    
    public FarthestFirst(Runtime<T> rt) : base(rt, new FarthestFirst()) {}

    /// <summary>
    /// set number of clusters
    /// </summary>    
    public FarthestFirst<T> NumClusters (int n) {
      ((FarthestFirst)Impl).setNumClusters(n);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public FarthestFirst<T> Seed (int value) {
      ((FarthestFirst)Impl).setSeed(value);
      return this;
    }

            

        
  }
}