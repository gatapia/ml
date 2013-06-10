namespace Ml2.Fltrs
{
  public class UnsupervisedFilters<T>
  {
    private readonly Runtime<T> rt;
    public UnsupervisedFilters(Runtime<T> rt) { this.rt = rt; }

    public UnsupervisedInstanceFilters<T> Instance { get { return new UnsupervisedInstanceFilters<T>(rt); }}
    public UnsupervisedAttributeFilters<T> Attribute { get { return new UnsupervisedAttributeFilters<T>(rt); }}
  }
}