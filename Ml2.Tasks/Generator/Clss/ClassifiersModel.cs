using System;
using System.Linq;

namespace Ml2.Tasks.Generator.Clss
{
  public partial class Classifiers : IMl2CodeGenerator
  {
    private readonly Type[] types;

    public Classifiers(Type[] types)
    {
      this.types = types;
    }

    public ClassifierAlgorithm[] AllClassifiers { get { return types.Select(t => new ClassifierAlgorithm(t)).ToArray(); } }

    public string TypeName
    {
      get { return String.Empty; }
    }    
  }
}