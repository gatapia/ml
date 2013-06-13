namespace Ml2.Fltr
{
  public class Filters<T> where T : new()
  {
    private readonly Runtime<T> rt;
    public Filters(Runtime<T> rt) { this.rt = rt; }

    public SupervisedFilters<T> Supervised { get { return new SupervisedFilters<T>(rt); }}
    public UnsupervisedFilters<T> Unsupervised { get { return new UnsupervisedFilters<T>(rt); }}
  }
}