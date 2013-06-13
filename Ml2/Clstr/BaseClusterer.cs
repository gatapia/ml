using weka.clusterers;

namespace Ml2.Clstr
{
  public abstract class BaseClusterer<T, I> where I : Clusterer
  {
    protected readonly Runtime<T> rt;
    public I Impl { get; private set; }

    protected BaseClusterer(Runtime<T> rt, I impl) { 
      this.rt = rt; 
      Impl = impl;
    }

    public BaseClusterer<T, I> Build()
    {
      Impl.buildClusterer(rt.Instances);
      return this;
    }

    public int Classify(T row) { return Impl.clusterInstance(rt.GetRowInstance(row)); }
  }
}