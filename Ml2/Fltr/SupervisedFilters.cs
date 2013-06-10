namespace Ml2.Fltr
{
  public class SupervisedFilters<T>
  {
    private readonly Runtime<T> rt;
    public SupervisedFilters(Runtime<T> rt) { this.rt = rt; }

    public SupervisedInstanceFilters<T> Instance { get { return new SupervisedInstanceFilters<T>(rt); }}
    public SupervisedAttributeFilters<T> Attribute { get { return new SupervisedAttributeFilters<T>(rt); }}
  }
}