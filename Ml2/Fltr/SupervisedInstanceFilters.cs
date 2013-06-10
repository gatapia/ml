namespace Ml2.Fltr
{
  public class SupervisedInstanceFilters<T>
  {
    private readonly Runtime<T> rt;
    public SupervisedInstanceFilters(Runtime<T> rt) { this.rt = rt; }
  }
}