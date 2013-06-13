using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
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
  public class RegressionByDiscretization<T> : BaseClassifier<T, RegressionByDiscretization> where T : new()
  {
    public RegressionByDiscretization(Runtime<T> rt) : base(rt, new RegressionByDiscretization()) {}

    /// <summary>
    /// Number of bins for discretization.
    /// </summary>    
    public RegressionByDiscretization<T> NumBins (int numBins) {
      ((RegressionByDiscretization)Impl).setNumBins(numBins);
      return this;
    }

    /// <summary>
    /// Whether to delete empty bins after discretization.
    /// </summary>    
    public RegressionByDiscretization<T> DeleteEmptyBins (bool b) {
      ((RegressionByDiscretization)Impl).setDeleteEmptyBins(b);
      return this;
    }

    /// <summary>
    /// If set to true, equal-frequency binning will be used instead of
    /// equal-width binning.
    /// </summary>    
    public RegressionByDiscretization<T> UseEqualFrequency (bool newUseEqualFrequency) {
      ((RegressionByDiscretization)Impl).setUseEqualFrequency(newUseEqualFrequency);
      return this;
    }

    /// <summary>
    /// Whether to minimize absolute error.
    /// </summary>    
    public RegressionByDiscretization<T> MinimizeAbsoluteError (bool b) {
      ((RegressionByDiscretization)Impl).setMinimizeAbsoluteError(b);
      return this;
    }

    /// <summary>
    /// The density estimator to use.
    /// </summary>    
    public RegressionByDiscretization<T> EstimatorType (EEstimatorType newEstimator) {
      ((RegressionByDiscretization)Impl).setEstimatorType(new weka.core.SelectedTag((int) newEstimator, RegressionByDiscretization.TAGS_ESTIMATOR));
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public RegressionByDiscretization<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((RegressionByDiscretization)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RegressionByDiscretization<T> Debug (bool debug) {
      ((RegressionByDiscretization)Impl).setDebug(debug);
      return this;
    }

        
    public enum EEstimatorType {
      Histogram_density_estimator = 0,
      Kernel_density_estimator = 1,
      Normal_density_estimator = 2
    }

        
  }
}