using weka.clusterers;

namespace Ml2.Clstr
{
  /// <summary>
  /// Cluster data using the k means algorithm. Can use either the Euclidean
  /// distance (default) or the Manhattan distance. If the Manhattan distance is
  /// used, then centroids are computed as the component-wise median rather than
  /// mean. For more information see: D. Arthur, S. Vassilvitskii: k-means++: the
  /// advantages of carefull seeding. In: Proceedings of the eighteenth annual
  /// ACM-SIAM symposium on Discrete algorithms, 1027-1035, 2007.
  /// </summary>
  public class SimpleKMeans<T> : BaseClusterer<T>
  {
    private readonly SimpleKMeans impl = new SimpleKMeans();
    
    public SimpleKMeans(Runtime<T> rt) : base(rt) {}

    /// <summary>
    /// set number of clusters
    /// </summary>    
    public SimpleKMeans<T> NumClusters (int value) {
      impl.setNumClusters(value);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use. Set equal to the number
    /// of available cpu/cores
    /// </summary>    
    public SimpleKMeans<T> NumExecutionSlots (int value) {
      impl.setNumExecutionSlots(value);
      return this;
    }

    /// <summary>
    /// Display std deviations of numeric attributes and counts of nominal
    /// attributes.
    /// </summary>    
    public SimpleKMeans<T> DisplayStdDevs (bool value) {
      impl.setDisplayStdDevs(value);
      return this;
    }

    /// <summary>
    /// set maximum number of iterations
    /// </summary>    
    public SimpleKMeans<T> MaxIterations (int value) {
      impl.setMaxIterations(value);
      return this;
    }

    /// <summary>
    /// Initialize cluster centers using the probabilistic farthest first method
    /// of the k-means++ algorithm
    /// </summary>    
    public SimpleKMeans<T> InitializeUsingKMeansPlusPlusMethod (bool value) {
      impl.setInitializeUsingKMeansPlusPlusMethod(value);
      return this;
    }

    /// <summary>
    /// Replace missing values globally with mean/mode.
    /// </summary>    
    public SimpleKMeans<T> DontReplaceMissingValues (bool value) {
      impl.setDontReplaceMissingValues(value);
      return this;
    }

    /// <summary>
    /// Preserve order of instances.
    /// </summary>    
    public SimpleKMeans<T> PreserveInstancesOrder (bool value) {
      impl.setPreserveInstancesOrder(value);
      return this;
    }

    /// <summary>
    /// Uses cut-off values for speeding up distance calculation, but suppresses
    /// also the calculation and output of the within cluster sum of squared
    /// errors/sum of distances.
    /// </summary>    
    public SimpleKMeans<T> FastDistanceCalc (bool value) {
      impl.setFastDistanceCalc(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public SimpleKMeans<T> Seed (int value) {
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