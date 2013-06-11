using weka.core;
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
    public SimpleKMeans(Runtime<T> rt) : base(rt, new SimpleKMeans()) {}

    /// <summary>
    /// set number of clusters
    /// </summary>    
    public SimpleKMeans<T> NumClusters (int value) {
      ((weka.clusterers.SimpleKMeans)impl).setNumClusters(value);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use. Set equal to the number
    /// of available cpu/cores
    /// </summary>    
    public SimpleKMeans<T> NumExecutionSlots (int value) {
      ((weka.clusterers.SimpleKMeans)impl).setNumExecutionSlots(value);
      return this;
    }

    /// <summary>
    /// Display std deviations of numeric attributes and counts of nominal
    /// attributes.
    /// </summary>    
    public SimpleKMeans<T> DisplayStdDevs (bool value) {
      ((weka.clusterers.SimpleKMeans)impl).setDisplayStdDevs(value);
      return this;
    }

    /// <summary>
    /// set maximum number of iterations
    /// </summary>    
    public SimpleKMeans<T> MaxIterations (int value) {
      ((weka.clusterers.SimpleKMeans)impl).setMaxIterations(value);
      return this;
    }

    /// <summary>
    /// Initialize cluster centers using the probabilistic farthest first method
    /// of the k-means++ algorithm
    /// </summary>    
    public SimpleKMeans<T> InitializeUsingKMeansPlusPlusMethod (bool value) {
      ((weka.clusterers.SimpleKMeans)impl).setInitializeUsingKMeansPlusPlusMethod(value);
      return this;
    }

    /// <summary>
    /// Replace missing values globally with mean/mode.
    /// </summary>    
    public SimpleKMeans<T> DontReplaceMissingValues (bool value) {
      ((weka.clusterers.SimpleKMeans)impl).setDontReplaceMissingValues(value);
      return this;
    }

    /// <summary>
    /// Preserve order of instances.
    /// </summary>    
    public SimpleKMeans<T> PreserveInstancesOrder (bool value) {
      ((weka.clusterers.SimpleKMeans)impl).setPreserveInstancesOrder(value);
      return this;
    }

    /// <summary>
    /// Uses cut-off values for speeding up distance calculation, but suppresses
    /// also the calculation and output of the within cluster sum of squared
    /// errors/sum of distances.
    /// </summary>    
    public SimpleKMeans<T> FastDistanceCalc (bool value) {
      ((weka.clusterers.SimpleKMeans)impl).setFastDistanceCalc(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public SimpleKMeans<T> Seed (int value) {
      ((weka.clusterers.SimpleKMeans)impl).setSeed(value);
      return this;
    }

            

        
  }
}