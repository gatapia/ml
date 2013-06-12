using weka.core;
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
    public FarthestFirst(Runtime<T> rt) : base(rt, new FarthestFirst()) {}

    /// <summary>
    /// set number of clusters
    /// </summary>    
    public FarthestFirst<T> NumClusters (int value) {
      ((FarthestFirst)Impl).setNumClusters(value);
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