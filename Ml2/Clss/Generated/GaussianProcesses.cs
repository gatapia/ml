using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Implements Gaussian processes for regression without
  /// hyperparameter-tuning. To make choosing an appropriate noise level easier, this implementation
  /// applies normalization/standardization to the target attribute as well as
  /// the other attributes (if normalization/standardizaton is turned on). Missing
  /// values are replaced by the global mean/mode. Nominal attributes are
  /// converted to binary ones. Note that kernel caching is turned off if the kernel
  /// used implements CachedKernel.
  /// </summary>
  public class GaussianProcesses<T> : BaseClassifier<T, GaussianProcesses> where T : new()
  {
    public GaussianProcesses(Runtime<T> rt) : base(rt, new GaussianProcesses()) {}

    /// <summary>
    /// The level of Gaussian Noise (added to the diagonal of the Covariance
    /// Matrix), after the target has been normalized/standardized/left unchanged).
    /// </summary>    
    public GaussianProcesses<T> Noise (double v) {
      ((GaussianProcesses)Impl).setNoise(v);
      return this;
    }

    /// <summary>
    /// Determines how/if the data will be transformed.
    /// </summary>    
    public GaussianProcesses<T> FilterType (EFilterType newType) {
      ((GaussianProcesses)Impl).setFilterType(new weka.core.SelectedTag((int) newType, GaussianProcesses.TAGS_FILTER));
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public GaussianProcesses<T> Debug (bool debug) {
      ((GaussianProcesses)Impl).setDebug(debug);
      return this;
    }

        
    public enum EFilterType {
      Normalize_training_data = 0,
      Standardize_training_data = 1,
      No_normalization_div_standardization = 2
    }

        
  }
}