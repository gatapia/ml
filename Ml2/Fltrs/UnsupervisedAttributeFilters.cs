namespace Ml2.Fltrs
{
  public class UnsupervisedAttributeFilters<T>
  {
    private readonly Runtime<T> rt;
    public UnsupervisedAttributeFilters(Runtime<T> rt) { this.rt = rt; }
  }
}