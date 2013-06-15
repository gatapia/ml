using weka.core;

namespace Ml2
{
  public class Observation<T> 
  {
    public T Row { get; set; }
    public Instance Instance { get; set; }
  }
}