// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  public class FiltersGeneral<T> where T : new()
  {
    private readonly Runtime<T> rt;    
    public FiltersGeneral(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// An instance filter that passes all instances through unmodified.
    /// Primarily for testing purposes.
    /// </summary>
    public AllFilter<T> AllFilter() { return new AllFilter<T>(rt); }

    /// <summary>
    /// Applies several filters successively. In case all supplied filters are
    /// StreamableFilters, it will act as a streamable one,
    /// too.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-F &lt;classname
    /// [options]&gt; = 	A filter to apply (can be specified multiple times).
    /// </summary>
    public MultiFilter<T> MultiFilter() { return new MultiFilter<T>(rt); }

    
  }
}