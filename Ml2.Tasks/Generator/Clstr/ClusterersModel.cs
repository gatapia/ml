using System;
using System.Linq;

namespace Ml2.Tasks.Generator.Clstr
{
  public partial class Clusterers : IMl2CodeGenerator
  {
    private readonly Type[] types;

    public Clusterers(Type[] types)
    {
      this.types = types;
    }

    public ClustererAlgorithm[] AllClusterers { get { return types.Select(t => new ClustererAlgorithm(t)).ToArray(); } }

    public string TypeName
    {
      get { return String.Empty; }
    }    
  }
}