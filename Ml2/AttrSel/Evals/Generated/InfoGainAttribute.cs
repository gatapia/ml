using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class InfoGainAttribute : IAttributeSelectionEvaluator
  {
    private readonly InfoGainAttributeEval impl = new InfoGainAttributeEval();
    
        
    public InfoGainAttribute MissingMerge (bool value) {
      impl.setMissingMerge(value);
      return this;
    }

        
    public InfoGainAttribute BinarizeNumericAttributes (bool value) {
      impl.setBinarizeNumericAttributes(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}