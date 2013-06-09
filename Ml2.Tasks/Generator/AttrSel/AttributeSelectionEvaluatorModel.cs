using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator.AttrSel
{  
  public partial class AttributeSelectionEvaluator : IMl2CodeGenerator
  {
    protected readonly Type impl;
    public AttributeSelectionEvaluator(Type impl) { this.impl = impl; }

    public string TypeName { get { return Utils.GetMl2EvalTypeName(impl); } }

    public string GetClassDescription(string separator) { return Utils.GetClassDescription(impl, separator); }

    public string ImplTypeName
    {
      get
      {
        var name = impl.Name;
        return name.IndexOf("Eval") < 0 ? ("weka.attributeSelection." + name) : name;
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