using weka.core;
using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// SymmetricalUncertAttributeEval : Evaluates the worth of an attribute by
  /// measuring the symmetrical uncertainty with respect to the class.
  /// SymmU(Class, Attribute) = 2 * (H(Class) - H(Class | Attribute)) / H(Class) +
  /// H(Attribute).
  /// </summary>
  public class SymmetricalUncertAttribute<T> : BaseAttributeSelectionEvaluator<T>
  {
    public SymmetricalUncertAttribute(Runtime<T> rt) : base(rt, new SymmetricalUncertAttributeEval()) {}
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public SymmetricalUncertAttribute<T> MissingMerge (bool value) {
      ((SymmetricalUncertAttributeEval)impl).setMissingMerge(value);
      return this;
    }

            
        
  }
}