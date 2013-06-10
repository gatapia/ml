using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator.Fltr
{  
  public partial class FilterAlgorithm : IMl2CodeGenerator
  {
    protected readonly Type impl;
    public FilterAlgorithm(Type impl) { this.impl = impl; }

    public string TypeName { get { return impl.Name; } }

    public string GetClassDescription(string separator) { return Utils.GetClassDescription(impl, separator); }

    public string ImplTypeName { get { return impl.Name; } }
    public string ImplTypeFullName { get { return impl.FullName; } }
    public string ImplTypeNamespace { get { return impl.Namespace; } }

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