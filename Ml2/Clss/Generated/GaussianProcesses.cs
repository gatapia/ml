using weka.core;
using weka.classifiers.functions;

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
  public class GaussianProcesses<T> : BaseClassifier<T>
  {
    public GaussianProcesses(Runtime<T> rt) : base(rt, new GaussianProcesses()) {}

    /// <summary>
    /// The level of Gaussian Noise (added to the diagonal of the Covariance
    /// Matrix), after the target has been normalized/standardized/left unchanged).
    /// </summary>    
    public GaussianProcesses<T> Noise (double value) {
      ((weka.classifiers.functions.GaussianProcesses)impl).setNoise(value);
      return this;
    }

    /// <summary>
    /// Determines how/if the data will be transformed.
    /// </summary>    
    public GaussianProcesses<T> FilterType (EFilterType value) {
      ((weka.classifiers.functions.GaussianProcesses)impl).setFilterType(new SelectedTag((int) value, weka.classifiers.functions.GaussianProcesses.TAGS_FILTER));
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public GaussianProcesses<T> Debug (bool value) {
      ((weka.classifiers.functions.GaussianProcesses)impl).setDebug(value);
      return this;
    }

        
    public enum EFilterType {
      Normalize_training_data = 0,
      Standardize_training_data = 1,
      No_normalization_div_standardization = 2
    }

        
  }
}