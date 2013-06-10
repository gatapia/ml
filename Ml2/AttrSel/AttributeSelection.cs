using Ml2.AttrSel.Algs;
using Ml2.AttrSel.Algs.Generated;
using Ml2.AttrSel.Evals;
using Ml2.AttrSel.Evals.Generated;
using weka.core;

namespace Ml2.AttrSel
{
  public class AttributeSelection
  {
    public AttributeSelection(Instances inst)
    {
      Algorithms = new Algorithms(inst);
      Evaluators = new Evaluators();
    }

    public Algorithms Algorithms { get; private set; }
    public Evaluators Evaluators { get; private set; }
  }
}