using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// CfsSubsetEval : Evaluates the worth of a subset of attributes by
  /// considering the individual predictive ability of each feature along with the degree
  /// of redundancy between them. Subsets of features that are highly correlated
  /// with the class while having low intercorrelation are preferred. For more
  /// information see: M. A. Hall (1998). Correlation-based Feature Subset
  /// Selection for Machine Learning. Hamilton, New Zealand.
  /// </summary>
  public class CfsSubset : IAttributeSelectionEvaluator
  {
    private readonly CfsSubsetEval impl = new CfsSubsetEval();
    
    /// <summary>
    /// Treat missing as a separate value. Otherwise, counts for missing values
    /// are distributed across other values in proportion to their frequency.
    /// </summary>    
    public CfsSubset MissingSeparate (bool value) {
      impl.setMissingSeparate(value);
      return this;
    }

    /// <summary>
    /// Identify locally predictive attributes. Iteratively adds attributes with
    /// the highest correlation with the class as long as there is not already an
    /// attribute in the subset that has a higher correlation with the attribute in
    /// question
    /// </summary>    
    public CfsSubset LocallyPredictive (bool value) {
      impl.setLocallyPredictive(value);
      return this;
    }

        
    public ASEvaluation GetImpl() { return impl; }
  }
}