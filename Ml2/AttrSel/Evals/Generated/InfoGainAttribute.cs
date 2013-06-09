using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// InfoGainAttributeEval : Evaluates the worth of an attribute by measuring
  /// the information gain with respect to the class. InfoGain(Class,Attribute) =
  /// H(Class) - H(Class | Attribute).
  /// </summary>
  public class InfoGainAttribute : IAttributeSelectionEvaluator
  {
    private readonly InfoGainAttributeEval impl = new InfoGainAttributeEval();
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public InfoGainAttribute MissingMerge (bool value) {
      impl.setMissingMerge(value);
      return this;
    }

    /// <summary>
    /// Just binarize numeric attributes instead of properly discretizing them.
    /// </summary>    
    public InfoGainAttribute BinarizeNumericAttributes (bool value) {
      impl.setBinarizeNumericAttributes(value);
      return this;
    }

        
    public ASEvaluation GetImpl() { return impl; }
  }
}