using Ml2.AttrSel.Algs;
using Ml2.AttrSel.Evals;
using weka.core;

namespace Ml2.AttrSel
{
  public class AttributeSelection
  {
    private readonly Instances inst;    
    public AttributeSelection(Instances inst) { this.inst = inst; }   

    public Algorithms Algorithms
    {
      get { return new Algorithms(inst); }
    }

    public Evaluators Evaluators
    {
      get { return new Evaluators(inst); }
    }

  }
}