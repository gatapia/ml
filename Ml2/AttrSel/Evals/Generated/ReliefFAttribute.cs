using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class ReliefFAttribute : IAttributeSelectionEvaluator
  {
    private readonly ReliefFAttributeEval impl = new ReliefFAttributeEval();
    
        
    public ReliefFAttribute WeightByDistance (bool value) {
      impl.setWeightByDistance(value);
      return this;
    }

        
    public ReliefFAttribute SampleSize (int value) {
      impl.setSampleSize(value);
      return this;
    }

        
    public ReliefFAttribute Seed (int value) {
      impl.setSeed(value);
      return this;
    }

        
    public ReliefFAttribute NumNeighbours (int value) {
      impl.setNumNeighbours(value);
      return this;
    }

        
    public ReliefFAttribute Sigma (int value) {
      impl.setSigma(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}