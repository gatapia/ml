using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// InfoGainAttributeEval : Evaluates the worth of an attribute by measuring
  /// the information gain with respect to the class. InfoGain(Class,Attribute) =
  /// H(Class) - H(Class | Attribute).
  /// </summary>
  public class InfoGainAttribute<T> : BaseAttributeSelectionEvaluator<T, InfoGainAttributeEval>
  {
    public InfoGainAttribute(Runtime<T> rt) : base(rt, new InfoGainAttributeEval()) {}
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public InfoGainAttribute<T> MissingMerge (bool b) {
      ((InfoGainAttributeEval)Impl).setMissingMerge(b);
      return this;
    }

    /// <summary>
    /// Just binarize numeric attributes instead of properly discretizing them.
    /// </summary>    
    public InfoGainAttribute<T> BinarizeNumericAttributes (bool b) {
      ((InfoGainAttributeEval)Impl).setBinarizeNumericAttributes(b);
      return this;
    }

            
        
  }
}