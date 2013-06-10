using weka.clusterers;

namespace Ml2.Clstr.Generated
{
  /// <summary>
  /// Class for wrapping a Clusterer to make it return a distribution and
  /// density. Fits normal distributions and discrete distributions within each
  /// cluster produced by the wrapped clusterer. Supports the
  /// NumberOfClustersRequestable interface only if the wrapped Clusterer does.
  /// </summary>
  public class MakeDensityBased<T> : BaseClusterer<T>
  {
    private readonly MakeDensityBasedClusterer impl = new MakeDensityBasedClusterer();
    
    public MakeDensityBased(Runtime<T> rt) : base(rt) {}

    /// <summary>
    /// set minimum allowable standard deviation
    /// </summary>    
    public MakeDensityBased<T> MinStdDev (double value) {
      impl.setMinStdDev(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MakeDensityBased<T> NumClusters (int value) {
      impl.setNumClusters(value);
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