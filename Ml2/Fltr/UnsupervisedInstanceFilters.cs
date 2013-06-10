namespace Ml2.Fltr
{
  public class UnsupervisedInstanceFilters<T>
  {
    private readonly Runtime<T> rt;
    public UnsupervisedInstanceFilters(Runtime<T> rt) { this.rt = rt; }
  }
}