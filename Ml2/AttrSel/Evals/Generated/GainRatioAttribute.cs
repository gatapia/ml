using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// GainRatioAttributeEval : Evaluates the worth of an attribute by measuring
  /// the gain ratio with respect to the class. GainR(Class, Attribute) =
  /// (H(Class) - H(Class | Attribute)) / H(Attribute).
  /// </summary>
  public class GainRatioAttribute<T> : BaseAttributeSelectionEvaluator<T, GainRatioAttributeEval> where T : new()
  {
    public GainRatioAttribute(Runtime<T> rt) : base(rt, new GainRatioAttributeEval()) {}
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public GainRatioAttribute<T> MissingMerge (bool b) {
      ((GainRatioAttributeEval)Impl).setMissingMerge(b);
      return this;
    }

            
        
  }
}