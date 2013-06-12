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
    /// the clusterer to wrap
    /// </summary>    
    public MakeDensityBased<T> Clusterer (Clstr.BaseClusterer<T> value) {
      ((MakeDensityBasedClusterer)Impl).setClusterer(value.Impl);
      return this;
    }

    /// <summary>
    /// set minimum allowable standard deviation
    /// </summary>    
    public MakeDensityBased<T> MinStdDev (double value) {
      ((MakeDensityBasedClusterer)Impl).setMinStdDev(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MakeDensityBased<T> NumClusters (int value) {
      ((MakeDensityBasedClusterer)Impl).setNumClusters(value);
      return this;
    }

            

        
  }
}