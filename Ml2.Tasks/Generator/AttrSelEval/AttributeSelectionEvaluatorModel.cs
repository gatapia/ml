using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator.AttrSelEval
{
  public partial class AttributeSelectionEvaluator : IMl2CodeGenerator
  {
    private readonly Type impl;

    public AttributeSelectionEvaluator(Type impl)
    {
      this.impl = impl;
    }

    public bool IsSupported
    {
      get { return impl.Name != "DummySubsetEvaluator"; }
    }

    public string TypeName
    {
      get
      {
        var idx = impl.Name.IndexOf("Eval");
        if (idx < 0) return impl.Name;
        return impl.Name.Substring(0, idx);
      }
    }

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
          Select(m => new OptionModel(m)).
          Where(o => o.IsSupported).
          ToArray();
      }
    }
  }
}