namespace Ml2.Fltrs
{
  public class UnsupervisedInstanceFilters<T>
  {
    private readonly Runtime<T> rt;
    public UnsupervisedInstanceFilters(Runtime<T> rt) { this.rt = rt; }
  }
}