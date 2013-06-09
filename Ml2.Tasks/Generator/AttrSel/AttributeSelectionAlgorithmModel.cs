using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator.AttrSel
{
  public partial class AttributeSelectionAlgorithm : IMl2CodeGenerator
  {
    private readonly Type impl;

    public AttributeSelectionAlgorithm(Type impl)
    {
      this.impl = impl;
    }

    public string ClassDescription
    {
      get
      {
        var desc = (string) impl.GetMethod("globalInfo", BindingFlags.Instance | BindingFlags.Public).
            Invoke(Activator.CreateInstance(impl), null);
        return String.Join("\n  /// ", Utils.SplitIntoChunks(desc, 75));
      }
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
      get { return "weka.attributeSelection." + impl.Name; }
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