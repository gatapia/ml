using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class CorrelationAttribute : IAttributeSelectionEvaluator
  {
    private readonly CorrelationAttributeEval impl = new CorrelationAttributeEval();
    
        
    public CorrelationAttribute OutputDetailedInfo (bool value) {
      impl.setOutputDetailedInfo(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}