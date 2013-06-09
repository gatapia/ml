using weka.core;

namespace Ml2.AttributeSelection
{
  public class Algorithms
  {
    private readonly Instances inst;    
    public Algorithms(Instances inst) { this.inst = inst; }   

    public BestFirstMl2 BestFirst() { return new BestFirstMl2(inst); }
  }
}