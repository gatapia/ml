using weka.clusterers;

namespace Ml2.Clstr
{
  public abstract class BaseClusterer<T> : IClusterer<T>
  {
    protected readonly Runtime<T> rt;
    protected readonly Clusterer impl;

    protected BaseClusterer(Runtime<T> rt, Clusterer impl) { 
      this.rt = rt; 
      this.impl = impl;
    }

    public IClusterer<T> Build()
    {
      impl.buildClusterer(rt.Instances);
      return this;
    }

    public int Classify(T row) { return impl.clusterInstance(rt.GetRowInstance(row)); }
  }
}