using System;
using System.Linq;

namespace Ml2.Tasks.Generator.Fltr
{
  public partial class Filters 
  {
    private readonly Type[] types;    
    public Filters(Type[] types) { this.types = types; } 

    public string TypeName {get;set; }

    public WekaTypeModel[] AllFilters { 
      get { 
        return types.Select(t => new FilterAlgorithm(t).Model).ToArray(); 
      } 
    }    
  }
}