using weka.clusterers;

namespace Ml2.Clstr
{
  public interface IBaseClusterer<T, out I> where T : new() where I : Clusterer {
    I Impl { get; }
    IBaseClusterer<T, I> Build();
    int Classify(Observation<T> row);
  }

  public abstract class BaseClusterer<T, I> : IBaseClusterer<T, I> where I : Clusterer where T : new()
  {
    protected readonly Runtime<T> rt;
    public I Impl { get; private set; }

    protected BaseClusterer(Runtime<T> rt, I impl) { 
      this.rt = rt; 
      Impl = impl;

      InternalHelpers.SetSeedOnInstance(impl);
    }

    public IBaseClusterer<T, I> Build()
    {
      Impl.buildClusterer(rt.Instances);
      return this;
    }

    public int Classify(Observation<T> row) { return Impl.clusterInstance(row.Instance); }
  }
}