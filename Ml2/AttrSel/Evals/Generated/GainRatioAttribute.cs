using weka.core;
using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// GainRatioAttributeEval : Evaluates the worth of an attribute by measuring
  /// the gain ratio with respect to the class. GainR(Class, Attribute) =
  /// (H(Class) - H(Class | Attribute)) / H(Attribute).
  /// </summary>
  public class GainRatioAttribute : IAttributeSelectionEvaluator
  {
    private readonly weka.attributeSelection.GainRatioAttributeEval impl = new weka.attributeSelection.GainRatioAttributeEval();
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public GainRatioAttribute MissingMerge (bool value) {
      ((GainRatioAttributeEval)impl).setMissingMerge(value);
      return this;
    }

        
    public ASEvaluation GetImpl() { return impl; }

        
  }
}