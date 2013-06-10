using weka.associations;

namespace Ml2.Asstn
{
  public class BaseAssociation<T>
  {
    protected readonly Runtime<T> rt;
    protected readonly AbstractAssociator impl;    

    public BaseAssociation(Runtime<T> rt, AbstractAssociator impl)
    {
      this.rt = rt;
      this.impl = impl;
    }

    public string GetRules()
    {
      impl.buildAssociations(rt.Instances);
      return impl.ToString();
    }
  }
}