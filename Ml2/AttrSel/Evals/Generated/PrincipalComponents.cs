using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// Performs a principal components analysis and transformation of the data.
  /// Use in conjunction with a Ranker search. Dimensionality reduction is
  /// accomplished by choosing enough eigenvectors to account for some percentage of
  /// the variance in the original data---default 0.95 (95%). Attribute noise can
  /// be filtered by transforming to the PC space, eliminating some of the worst
  /// eigenvectors, and then transforming back to the original
  /// space.<br/><br/>Options:<br/><br/>-C = 	Center (rather than standardize) the<br/>	data and
  /// compute PCA using the covariance (rather<br/>	 than the correlation)
  /// matrix.<br/>-R = 	Retain enough PC attributes to account <br/>	for this proportion
  /// of variance in the original data.<br/>	(default = 0.95)<br/>-O = 	Transform
  /// through the PC space and <br/>	back to the original space.<br/>-A =
  /// 	Maximum number of attributes to include in <br/>	transformed attribute names. (-1
  /// = include all)
  /// </summary>
  public class PrincipalComponents<T> : BaseAttributeSelectionEvaluator<T, PrincipalComponents> where T : new()
  {
    public PrincipalComponents(Runtime<T> rt) : base(rt, new PrincipalComponents()) {}
    
    /// <summary>
    /// Retain enough PC attributes to account for this proportion of variance.
    /// </summary>    
    public PrincipalComponents<T> VarianceCovered (double vc) {
      ((PrincipalComponents)Impl).setVarianceCovered(vc);
      return this;
    }

    /// <summary>
    /// The maximum number of attributes to include in transformed attribute
    /// names.
    /// </summary>    
    public PrincipalComponents<T> MaximumAttributeNames (int m) {
      ((PrincipalComponents)Impl).setMaximumAttributeNames(m);
      return this;
    }

    /// <summary>
    /// Transform through the PC space and back to the original space. If only
    /// the best n PCs are retained (by setting varianceCovered < 1) then this option
    /// will give a dataset in the original space but with less attribute noise.
    /// </summary>    
    public PrincipalComponents<T> TransformBackToOriginal (bool b) {
      ((PrincipalComponents)Impl).setTransformBackToOriginal(b);
      return this;
    }

    /// <summary>
    /// Center (rather than standardize) the data. PCA will be computed from the
    /// covariance (rather than correlation) matrix
    /// </summary>    
    public PrincipalComponents<T> CenterData (bool center) {
      ((PrincipalComponents)Impl).setCenterData(center);
      return this;
    }

            
        
  }
}