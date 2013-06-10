using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// Performs a principal components analysis and transformation of the data.
  /// Dimensionality reduction is accomplished by choosing enough eigenvectors to
  /// account for some percentage of the variance in the original data --
  /// default 0.95 (95%). Based on code of the attribute selection scheme
  /// 'PrincipalComponents' by Mark Hall and Gabi Schmidberger.
  /// </summary>
  public class PrincipalComponents<T> : BaseFilter<T>
  {
    public PrincipalComponents(Runtime<T> rt) : base(rt, new PrincipalComponents()) {}

    /// <summary>
    /// Retain enough PC attributes to account for this proportion of variance.
    /// </summary>    
    public PrincipalComponents<T> VarianceCovered (double value) {
      ((PrincipalComponents)impl).setVarianceCovered(value);
      return this;
    }
    /// <summary>
    /// The maximum number of attributes to include in transformed attribute
    /// names.
    /// </summary>    
    public PrincipalComponents<T> MaximumAttributeNames (int value) {
      ((PrincipalComponents)impl).setMaximumAttributeNames(value);
      return this;
    }
    /// <summary>
    /// The maximum number of PC attributes to retain.
    /// </summary>    
    public PrincipalComponents<T> MaximumAttributes (int value) {
      ((PrincipalComponents)impl).setMaximumAttributes(value);
      return this;
    }
    /// <summary>
    /// Center (rather than standardize) the data. PCA will be computed from the
    /// covariance (rather than correlation) matrix
    /// </summary>    
    public PrincipalComponents<T> CenterData (bool value) {
      ((PrincipalComponents)impl).setCenterData(value);
      return this;
    }
        
  }
}