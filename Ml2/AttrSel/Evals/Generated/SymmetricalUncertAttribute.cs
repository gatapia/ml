using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class SymmetricalUncertAttribute : IAttributeSelectionEvaluator
  {
    private readonly SymmetricalUncertAttributeEval impl = new SymmetricalUncertAttributeEval();
    
        
    public SymmetricalUncertAttribute MissingMerge (bool value) {
      impl.setMissingMerge(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}