using weka.associations;

namespace Ml2.Asstn
{
  public class BaseAssociation<T>
  {
    protected readonly Runtime<T> rt;
    protected internal AbstractAssociator Impl { get; private set; }

    public BaseAssociation(Runtime<T> rt, AbstractAssociator impl)
    {
      this.rt = rt;
      Impl = impl;
    }

    public string GetRules()
    {
      Impl.buildAssociations(rt.Instances);
      return Impl.ToString();
    }
  }
}