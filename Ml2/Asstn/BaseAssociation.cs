using weka.associations;

namespace Ml2.Asstn
{
  public interface IBaseAssociation<out I> where I : AbstractAssociator {
    I Impl { get; }
    string GetRules();
  }

  public class BaseAssociation<T, I> : IBaseAssociation<I> where I : AbstractAssociator where T : new()
  {
    protected readonly Runtime<T> rt;
    public I Impl { get; private set; }

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