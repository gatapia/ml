using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class GainRatioAttribute : IAttributeSelectionEvaluator
  {
    private readonly GainRatioAttributeEval impl = new GainRatioAttributeEval();
    
        
    public GainRatioAttribute MissingMerge (bool value) {
      impl.setMissingMerge(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}