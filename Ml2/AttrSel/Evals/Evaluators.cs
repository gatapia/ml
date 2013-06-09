using weka.core;

namespace Ml2.AttrSel.Evals
{
  public class Evaluators
  {
    private readonly Instances inst;    
    public Evaluators(Instances inst) { this.inst = inst; }

    public CfsSubset CfsSubset() { return new CfsSubset(); }
    public CorrelationAttribute CorrelationAttribute() { return new CorrelationAttribute(); }
  }
}