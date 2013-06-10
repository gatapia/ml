namespace Ml2.Fltrs
{
  public class SupervisedAttributeFilters<T>
  {
    private readonly Runtime<T> rt;
    public SupervisedAttributeFilters(Runtime<T> rt) { this.rt = rt; }
  }
}