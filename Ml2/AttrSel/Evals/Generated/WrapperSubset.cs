using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class WrapperSubset : IAttributeSelectionEvaluator
  {
    private readonly WrapperSubsetEval impl = new WrapperSubsetEval();
    
        
    public WrapperSubset Folds (int value) {
      impl.setFolds(value);
      return this;
    }

        
    public WrapperSubset Seed (int value) {
      impl.setSeed(value);
      return this;
    }

        
    public WrapperSubset Threshold (double value) {
      impl.setThreshold(value);
      return this;
    }

        
    public WrapperSubset IRClassValue (string value) {
      impl.setIRClassValue(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}