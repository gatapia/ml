using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class OneRAttribute : IAttributeSelectionEvaluator
  {
    private readonly OneRAttributeEval impl = new OneRAttributeEval();
    
        
    public OneRAttribute Seed (int value) {
      impl.setSeed(value);
      return this;
    }

        
    public OneRAttribute Folds (int value) {
      impl.setFolds(value);
      return this;
    }

        
    public OneRAttribute MinimumBucketSize (int value) {
      impl.setMinimumBucketSize(value);
      return this;
    }

        
    public OneRAttribute EvalUsingTrainingData (bool value) {
      impl.setEvalUsingTrainingData(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}