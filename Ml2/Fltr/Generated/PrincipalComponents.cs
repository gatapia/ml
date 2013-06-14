using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Performs a principal components analysis and transformation of the data.
  /// Dimensionality reduction is accomplished by choosing enough eigenvectors to
  /// account for some percentage of the variance in the original data --
  /// default 0.95 (95%). Based on code of the attribute selection scheme
  /// 'PrincipalComponents' by Mark Hall and Gabi Schmidberger.
  /// </summary>
  public class PrincipalComponents<T> : BaseFilter<T, PrincipalComponents> where T : new()
  {
    public PrincipalComponents(Runtime<T> rt) : base(rt, new PrincipalComponents()) {}

    /// <summary>
    /// Retain enough PC attributes to account for this proportion of variance.
    /// </summary>    
    public PrincipalComponents<T> VarianceCovered (double value) {
      ((PrincipalComponents)Impl).setVarianceCovered(value);
      return this;
    }

    /// <summary>
    /// The maximum number of attributes to include in transformed attribute
    /// names.
    /// </summary>    
    public PrincipalComponents<T> MaximumAttributeNames (int value) {
      ((PrincipalComponents)Impl).setMaximumAttributeNames(value);
      return this;
    }

    /// <summary>
    /// The maximum number of PC attributes to retain.
    /// </summary>    
    public PrincipalComponents<T> MaximumAttributes (int value) {
      ((PrincipalComponents)Impl).setMaximumAttributes(value);
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