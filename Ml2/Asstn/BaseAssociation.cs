using weka.associations;

namespace Ml2.Asstn
{
  public class BaseAssociation<T, I> where I : AbstractAssociator
  {
    protected readonly Runtime<T> rt;
    protected internal I Impl { get; private set; }

    public BaseAssociation(Runtime<T> rt, I impl)
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