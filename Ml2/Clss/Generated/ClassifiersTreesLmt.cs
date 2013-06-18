// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  public class ClassifiersTreesLmt<T> where T : new()
  {
    private readonly Runtime<T> rt;    
    public ClassifiersTreesLmt(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// No class description found.
    /// </summary>
    public LogisticBase<T> LogisticBase() { return new LogisticBase<T>(rt); }

    
  }
}