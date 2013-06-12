using weka.clusterers;

namespace Ml2.Clstr
{
  public abstract class BaseClusterer<T> : IClusterer<T>
  {
    protected readonly Runtime<T> rt;
    public Clusterer Impl { get; private set; }

    protected BaseClusterer(Runtime<T> rt, Clusterer impl) { 
      this.rt = rt; 
      Impl = impl;
    }

    public IClusterer<T> Build()
    {
      Impl.buildClusterer(rt.Instances);
      return this;
    }

    public int Classify(T row) { return Impl.clusterInstance(rt.GetRowInstance(row)); }
  }
}