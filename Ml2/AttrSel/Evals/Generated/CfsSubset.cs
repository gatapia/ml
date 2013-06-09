using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class CfsSubset : IAttributeSelectionEvaluator
  {
    private readonly CfsSubsetEval impl = new CfsSubsetEval();
    
        
    public CfsSubset MissingSeparate (bool value) {
      impl.setMissingSeparate(value);
      return this;
    }

        
    public CfsSubset LocallyPredictive (bool value) {
      impl.setLocallyPredictive(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}