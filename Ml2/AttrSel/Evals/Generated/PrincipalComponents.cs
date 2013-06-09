using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class PrincipalComponents : IAttributeSelectionEvaluator
  {
    private readonly weka.attributeSelection.PrincipalComponents impl = new weka.attributeSelection.PrincipalComponents();
    
        
    public PrincipalComponents VarianceCovered (double value) {
      impl.setVarianceCovered(value);
      return this;
    }

        
    public PrincipalComponents MaximumAttributeNames (int value) {
      impl.setMaximumAttributeNames(value);
      return this;
    }

        
    public PrincipalComponents TransformBackToOriginal (bool value) {
      impl.setTransformBackToOriginal(value);
      return this;
    }

        
    public PrincipalComponents CenterData (bool value) {
      impl.setCenterData(value);
      return this;
    }

            
    public ASEvaluation GetImpl() { return impl; }
  }
}