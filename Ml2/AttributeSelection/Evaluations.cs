using weka.core;

namespace Ml2.AttributeSelection
{
  public class Evaluations
  {
    private readonly Instances inst;    
    public Evaluations(Instances inst) { this.inst = inst; }

    public CfsSubsetEvalMl2 CfsSubsetEval() { return new CfsSubsetEvalMl2(); }
  }
}