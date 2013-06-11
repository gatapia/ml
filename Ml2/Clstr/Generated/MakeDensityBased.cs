using weka.core;
using weka.clusterers;

namespace Ml2.Clstr
{
  /// <summary>
  /// Class for wrapping a Clusterer to make it return a distribution and
  /// density. Fits normal distributions and discrete distributions within each
  /// cluster produced by the wrapped clusterer. Supports the
  /// NumberOfClustersRequestable interface only if the wrapped Clusterer does.
  /// </summary>
  public class MakeDensityBased<T> : BaseClusterer<T>
  {    
    public MakeDensityBased(Runtime<T> rt) : base(rt, new MakeDensityBasedClusterer()) {}

    /// <summary>
    /// set minimum allowable standard deviation
    /// </summary>    
    public MakeDensityBased<T> MinStdDev (double value) {
      ((MakeDensityBasedClusterer)impl).setMinStdDev(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MakeDensityBased<T> NumClusters (int value) {
      ((MakeDensityBasedClusterer)impl).setNumClusters(value);
      return this;
    }

            

        
  }
}