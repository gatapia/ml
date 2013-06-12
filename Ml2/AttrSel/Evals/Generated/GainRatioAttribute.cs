using weka.core;
using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// GainRatioAttributeEval : Evaluates the worth of an attribute by measuring
  /// the gain ratio with respect to the class. GainR(Class, Attribute) =
  /// (H(Class) - H(Class | Attribute)) / H(Attribute).
  /// </summary>
  public class GainRatioAttribute<T> : BaseAttributeSelectionEvaluator<T>
  {
    public GainRatioAttribute(Runtime<T> rt) : base(rt, new GainRatioAttributeEval()) {}
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public GainRatioAttribute<T> MissingMerge (bool value) {
      ((GainRatioAttributeEval)Impl).setMissingMerge(value);
      return this;
    }

            
        
  }
}