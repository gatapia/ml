using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// Evaluates the worth of an attribute by measuring the gain ratio with 
  /// respect to the class.
  /// </summary>
  public class GainRatioAttribute : IAttributeSelectionEvaluation
  {
    private readonly GainRatioAttributeEval impl = new GainRatioAttributeEval();
    
    public GainRatioAttribute TreatMissingAsSeparate(bool value) {
      impl.setMissingMerge(!value);
      return this;
    }

    public ASEvaluation GetImpl() { return impl; }
  }
}