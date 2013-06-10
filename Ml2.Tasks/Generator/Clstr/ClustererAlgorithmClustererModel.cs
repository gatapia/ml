using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator.Clstr
{  
  public partial class ClustererAlgorithm : IMl2CodeGenerator
  {
    protected readonly Type impl;
    public ClustererAlgorithm(Type impl) { this.impl = impl; }

    public string TypeName { get { return Utils.GetMl2ClustererTypeName(impl); } }

    public string GetClassDescription(string separator) { return Utils.GetClassDescription(impl, separator); }

    public string ImplTypeName
    {
      get
      {
        return impl.Name;
      }
    }

    public OptionModel[] Options
    {
      get
      {
        return impl.GetMethods(BindingFlags.Instance | BindingFlags.Public).
          Where(m => m.Name.StartsWith("set") && m.Name != "setOptions").
          Select(m => new OptionModel(impl, m)).
          Where(o => o.IsSupported).
          ToArray();
      }
    }
  }
}