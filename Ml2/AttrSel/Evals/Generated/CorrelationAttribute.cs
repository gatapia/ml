using weka.core;
using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// CorrelationAttributeEval : Evaluates the worth of an attribute by
  /// measuring the correlation (Pearson's) between it and the class. Nominal attributes
  /// are considered on a value by value basis by treating each value as an
  /// indicator. An overall correlation for a nominal attribute is arrived at via a
  /// weighted average.
  /// </summary>
  public class CorrelationAttribute<T> : BaseAttributeSelectionEvaluator<T>
  {
    public CorrelationAttribute(Runtime<T> rt) : base(rt, new CorrelationAttributeEval()) {}
    
    /// <summary>
    /// Output per value correlation for nominal attributes
    /// </summary>    
    public CorrelationAttribute<T> OutputDetailedInfo (bool value) {
      ((CorrelationAttributeEval)impl).setOutputDetailedInfo(value);
      return this;
    }

            
        
  }
}