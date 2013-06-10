using System;
using System.Linq;

namespace Ml2.Tasks.Generator.Fltrs
{
  public partial class Filters : IMl2CodeGenerator
  {
    private readonly Type[] types;

    public Filters(Type[] types)
    {
      this.types = types;
    }

    public FilterAlgorithm[] AllFilters { get { return types.Select(t => new FilterAlgorithm(t)).ToArray(); } }

    public string TypeName { get; set; }    
  }
}