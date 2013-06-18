namespace Ml2.Fltr
{
  public class Filters<T> where T : new()
  {
    private readonly Runtime<T> rt;
    public Filters(Runtime<T> rt) { this.rt = rt; }

    public FiltersGeneral<T> Supervised { get { return new FiltersGeneral<T>(rt); }}
    public FiltersSupervisedAttribute<T> SupervisedAttribute { get { return new FiltersSupervisedAttribute<T>(rt); }}
    public FiltersSupervisedInstance<T> SupervisedInstance { get { return new FiltersSupervisedInstance<T>(rt); }}
    public FiltersUnsupervisedAttribute<T> UnsupervisedAttribute { get { return new FiltersUnsupervisedAttribute<T>(rt); }}
    public FiltersUnsupervisedInstance<T> UnsupervisedInstance { get { return new FiltersUnsupervisedInstance<T>(rt); }}
  }
}