using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Class for wrapping a Clusterer to make it return a distribution and
  /// density. Fits normal distributions and discrete distributions within each
  /// cluster produced by the wrapped clusterer. Supports the
  /// NumberOfClustersRequestable interface only if the wrapped Clusterer does.
  /// </summary>
  public class MakeDensityBased<T> : BaseClusterer<T, MakeDensityBasedClusterer>
  {    
    public MakeDensityBased(Runtime<T> rt) : base(rt, new MakeDensityBasedClusterer()) {}

    /// <summary>
    /// the clusterer to wrap
    /// </summary>    
    public MakeDensityBased<T> Clusterer (Clstr.BaseClusterer<T, weka.clusterers.Clusterer> toWrap) {
      ((MakeDensityBasedClusterer)Impl).setClusterer(toWrap.Impl);
      return this;
    }

    /// <summary>
    /// set minimum allowable standard deviation
    /// </summary>    
    public MakeDensityBased<T> MinStdDev (double m) {
      ((MakeDensityBasedClusterer)Impl).setMinStdDev(m);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MakeDensityBased<T> NumClusters (int n) {
      ((MakeDensityBasedClusterer)Impl).setNumClusters(n);
      return this;
    }

            

        
  }
}