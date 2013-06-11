using weka.core;
using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// A regression scheme that employs any classifier on a copy of the data
  /// that has the class attribute discretized. The predicted value is the expected
  /// value of the mean class value for each discretized interval (based on the
  /// predicted probabilities for each interval). This class now also supports
  /// conditional density estimation by building a univariate density estimator from
  /// the target values in the training data, weighted by the class
  /// probabilities. For more information on this process, see Eibe Frank, Remco R.
  /// Bouckaert: Conditional Density Estimation with Class Probability Estimators. In:
  /// First Asian Conference on Machine Learning, Berlin, 65-81, 2009.
  /// </summary>
  public class RegressionByDiscretization<T> : BaseClassifier<T>
  {
    public RegressionByDiscretization(Runtime<T> rt) : base(rt, new RegressionByDiscretization()) {}

    /// <summary>
    /// Number of bins for discretization.
    /// </summary>    
    public RegressionByDiscretization<T> NumBins (int value) {
      ((RegressionByDiscretization)impl).setNumBins(value);
      return this;
    }

    /// <summary>
    /// Whether to delete empty bins after discretization.
    /// </summary>    
    public RegressionByDiscretization<T> DeleteEmptyBins (bool value) {
      ((RegressionByDiscretization)impl).setDeleteEmptyBins(value);
      return this;
    }

    /// <summary>
    /// If set to true, equal-frequency binning will be used instead of
    /// equal-width binning.
    /// </summary>    
    public RegressionByDiscretization<T> UseEqualFrequency (bool value) {
      ((RegressionByDiscretization)impl).setUseEqualFrequency(value);
      return this;
    }

    /// <summary>
    /// Whether to minimize absolute error.
    /// </summary>    
    public RegressionByDiscretization<T> MinimizeAbsoluteError (bool value) {
      ((RegressionByDiscretization)impl).setMinimizeAbsoluteError(value);
      return this;
    }

    /// <summary>
    /// The density estimator to use.
    /// </summary>    
    public RegressionByDiscretization<T> EstimatorType (EEstimatorType value) {
      ((RegressionByDiscretization)impl).setEstimatorType(new SelectedTag((int) value, RegressionByDiscretization.TAGS_ESTIMATOR));
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RegressionByDiscretization<T> Debug (bool value) {
      ((RegressionByDiscretization)impl).setDebug(value);
      return this;
    }

        
    public enum EEstimatorType {
      Histogram_density_estimator = 0,
      Kernel_density_estimator = 1,
      Normal_density_estimator = 2
    }

        
  }
}