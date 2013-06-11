using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator
{
  public class WekaTypeModel
  {
    private readonly Type impl;
    private readonly string ignoresuffix;

    public WekaTypeModel(Type impl, string ignoresuffix = null) {
      this.impl = impl;
      this.ignoresuffix = ignoresuffix;
    }

    public string TypeName { get { return Utils.GetMl2TypeName(impl, ignoresuffix); } }
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