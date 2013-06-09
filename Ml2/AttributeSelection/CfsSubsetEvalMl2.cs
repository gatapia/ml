using weka.attributeSelection;

namespace Ml2.AttributeSelection
{
  public class CfsSubsetEvalMl2 : IAttributeSelectionEvaluation
  {
    private readonly CfsSubsetEval impl = new CfsSubsetEval();
    
    public CfsSubsetEvalMl2 TreatMissingAsSeparate(bool value) {
      impl.setMissingSeparate(value);
      return this;
    }

    public CfsSubsetEvalMl2 DontIncludeLocallyPredictive(bool value) {
      impl.setLocallyPredictive(value);
      return this;
    }

    public ASEvaluation GetImpl() { return impl; }
  }
}