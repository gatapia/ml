namespace Ml2.Clstr
{
  public abstract class BaseClusterer<T> : IClusterer<T>
  {
    protected readonly Runtime<T> rt;
    protected BaseClusterer(Runtime<T> rt) { this.rt = rt; }

    public abstract IClusterer<T> Build();
    public abstract int Classify(T row);
  }
}