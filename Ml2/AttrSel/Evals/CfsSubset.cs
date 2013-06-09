using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// Evaluates the worth of a subset of attributes by considering the 
  /// individual predictive ability of each feature along with the degree 
  /// of redundancy between them.
  /// 
  /// Subsets of features that are highly correlated with the class while 
  /// having low intercorrelation are preferred.
  /// </summary>
  public class CfsSubset : IAttributeSelectionEvaluation
  {
    private readonly CfsSubsetEval impl = new CfsSubsetEval();
    
    public CfsSubset TreatMissingAsSeparate(bool value) {
      impl.setMissingSeparate(value);
      return this;
    }

    public CfsSubset DontIncludeLocallyPredictive(bool value) {
      impl.setLocallyPredictive(value);
      return this;
    }

    public ASEvaluation GetImpl() { return impl; }
  }
}