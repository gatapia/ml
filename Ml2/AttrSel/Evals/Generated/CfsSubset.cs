using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
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
  public class CfsSubset<T> : BaseAttributeSelectionEvaluator<T>
  {
    public CfsSubset(Runtime<T> rt) : base(rt, new CfsSubsetEval()) {}
    
    /// <summary>
    /// Treat missing as a separate value. Otherwise, counts for missing values
    /// are distributed across other values in proportion to their frequency.
    /// </summary>    
    public CfsSubset<T> MissingSeparate (bool b) {
      ((CfsSubsetEval)Impl).setMissingSeparate(b);
      return this;
    }

    /// <summary>
    /// Identify locally predictive attributes. Iteratively adds attributes with
    /// the highest correlation with the class as long as there is not already an
    /// attribute in the subset that has a higher correlation with the attribute in
    /// question
    /// </summary>    
    public CfsSubset<T> LocallyPredictive (bool b) {
      ((CfsSubsetEval)Impl).setLocallyPredictive(b);
      return this;
    }

            
        
  }
}