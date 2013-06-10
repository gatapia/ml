namespace Ml2.Fltr
{
  public class SupervisedAttributeFilters<T>
  {
    private readonly Runtime<T> rt;
    public SupervisedAttributeFilters(Runtime<T> rt) { this.rt = rt; }
  }
}