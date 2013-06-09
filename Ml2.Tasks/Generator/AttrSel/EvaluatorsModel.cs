using System;
using System.Linq;

namespace Ml2.Tasks.Generator.AttrSel
{
  public partial class Evaluators : IMl2CodeGenerator
  {
    private readonly Type[] types;

    public Evaluators(Type[] types)
    {
      this.types = types;
    }

    public string[] TypeNames { get { return types.Select(Utils.GetMl2EvalTypeName).ToArray(); } }

    public string TypeName
    {
      get { return String.Empty; }
    }    
  }
}