using System;
using System.Linq;

namespace Ml2.Tasks.Generator.Asstn
{
  public partial class Associations : IMl2CodeGenerator
  {
    private readonly Type[] types;

    public Associations(Type[] types)
    {
      this.types = types;
    }

    public AssociationAlgorithm[] AllAssociations { get { return types.Select(t => new AssociationAlgorithm(t)).ToArray(); } }

    public string TypeName
    {
      get { return String.Empty; }
    }    
  }
}