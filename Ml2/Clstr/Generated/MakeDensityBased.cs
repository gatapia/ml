using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Class for wrapping a Clusterer to make it return a distribution and
  /// density. Fits normal distributions and discrete distributions within each
  /// cluster produced by the wrapped clusterer. Supports the
  /// NumberOfClustersRequestable interface only if the wrapped Clusterer
  /// does.<br/><br/>Options:<br/><br/>-M &lt;num&gt; = 	minimum allowable standard deviation for normal density
  /// computation <br/>	(default 1e-6)<br/>-W &lt;clusterer name&gt; = 	Clusterer
  /// to wrap.<br/>	(default weka.clusterers.SimpleKMeans)<br/><br/>Options
  /// specific to clusterer weka.clusterers.SimpleKMeans: = <br/>-N &lt;num&gt; =
  /// 	number of clusters.<br/>	(default 2).<br/>-P = 	Initialize using the
  /// k-means++ method.<br/><br/>-V = 	Display std. deviations for centroids.<br/><br/>-M
  /// = 	Replace missing values with mean/mode.<br/><br/>-A &lt;classname and
  /// options&gt; = 	Distance function to use.<br/>	(default:
  /// weka.core.EuclideanDistance)<br/>-I &lt;num&gt; = 	Maximum number of iterations.<br/><br/>-O =
  /// 	Preserve order of instances.<br/><br/>-fast = 	Enables faster distance
  /// calculations, using cut-off values.<br/>	Disables the calculation/output of
  /// squared errors/distances.<br/><br/>-num-slots &lt;num&gt; = 	Number of
  /// execution slots.<br/>	(default 1 - i.e. no parallelism)<br/>-S &lt;num&gt; =
  /// 	Random number seed.<br/>	(default 10)
  /// </summary>
  public class MakeDensityBased<T> : BaseClusterer<T, MakeDensityBasedClusterer> where T : new()
  {    
    public MakeDensityBased(Runtime<T> rt) : base(rt, new MakeDensityBasedClusterer()) {}

    /// <summary>
    /// the clusterer to wrap
    /// </summary>    
    public MakeDensityBased<T> Clusterer (Clstr.IBaseClusterer<T, weka.clusterers.Clusterer> toWrap) {
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