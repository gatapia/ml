using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// Evaluates the worth of an attribute by measuring the information 
  /// gain with respect to the class
  /// </summary>
  public class InfoGainAttribute : IAttributeSelectionEvaluation
  {
    private readonly InfoGainAttributeEval impl = new InfoGainAttributeEval();
    
    /// <summary>
    /// Treat missing values as a seperate value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public InfoGainAttribute TreatMissingAsSeparate(bool value) {
      impl.setMissingMerge(!value);
      return this;
    }

    /// <summary>
    /// just binarize numeric attributes instead of properly discretizing them
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public InfoGainAttribute BinarizeNumericAttributes(bool value) {
      impl.setBinarizeNumericAttributes(value);
      return this;
    }

    public ASEvaluation GetImpl() { return impl; }
  }
}