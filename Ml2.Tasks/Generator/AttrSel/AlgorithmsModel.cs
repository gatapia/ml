using System;
using System.Linq;

namespace Ml2.Tasks.Generator.AttrSel
{
  public partial class Algorithms : IMl2CodeGenerator
  {
    private readonly Type[] types;

    public Algorithms(Type[] types)
    {
      this.types = types;
    }

    public AttributeSelectionAlgorithm[] AllAgorithms
    {
      get { return types.Select(t => new AttributeSelectionAlgorithm(t)).ToArray(); }
    }

    public string TypeName { get { return String.Empty;  } }
    public bool IsSupported { get { return true; } }
  }
}