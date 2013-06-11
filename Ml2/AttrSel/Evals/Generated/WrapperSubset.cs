using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// WrapperSubsetEval: Evaluates attribute sets by using a learning scheme.
  /// Cross validation is used to estimate the accuracy of the learning scheme for
  /// a set of attributes. For more information see: Ron Kohavi, George H. John
  /// (1997). Wrappers for feature subset selection. Artificial Intelligence.
  /// 97(1-2):273-324.
  /// </summary>
  public class WrapperSubset : IAttributeSelectionEvaluator
  {
    private readonly weka.attributeSelection.WrapperSubsetEval impl = new weka.attributeSelection.WrapperSubsetEval();
    
    /// <summary>
    /// Number of xval folds to use when estimating subset accuracy.
    /// </summary>    
    public WrapperSubset Folds (int value) {
      impl.setFolds(value);
      return this;
    }

    /// <summary>
    /// Seed to use for randomly generating xval splits.
    /// </summary>    
    public WrapperSubset Seed (int value) {
      impl.setSeed(value);
      return this;
    }

    /// <summary>
    /// Repeat xval if stdev of mean exceeds this value.
    /// </summary>    
    public WrapperSubset Threshold (double value) {
      impl.setThreshold(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public WrapperSubset IRClassValue (string value) {
      impl.setIRClassValue(value);
      return this;
    }

        
    public ASEvaluation GetImpl() { return impl; }
  }
}