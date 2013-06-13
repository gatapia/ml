using System.Linq;
using weka.classifiers.bayes;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for a Naive Bayes classifier using estimator classes. This is the
  /// updateable version of NaiveBayes. This classifier will use a default
  /// precision of 0.1 for numeric attributes when buildClassifier is called with zero
  /// training instances. For more information on Naive Bayes classifiers, see
  /// George H. John, Pat Langley: Estimating Continuous Distributions in Bayesian
  /// Classifiers. In: Eleventh Conference on Uncertainty in Artificial
  /// Intelligence, San Mateo, 338-345, 1995.
  /// </summary>
  public class NaiveBayesUpdateable<T> : BaseClassifier<T, NaiveBayesUpdateable>
  {
    public NaiveBayesUpdateable(Runtime<T> rt) : base(rt, new NaiveBayesUpdateable()) {}

    /// <summary>
    /// Use supervised discretization to convert numeric attributes to nominal
    /// ones.
    /// </summary>    
    public NaiveBayesUpdateable<T> UseSupervisedDiscretization (bool newblah) {
      ((NaiveBayesUpdateable)Impl).setUseSupervisedDiscretization(newblah);
      return this;
    }

    /// <summary>
    /// Use a kernel estimator for numeric attributes rather than a normal
    /// distribution.
    /// </summary>    
    public NaiveBayesUpdateable<T> UseKernelEstimator (bool v) {
      ((NaiveBayesUpdateable)Impl).setUseKernelEstimator(v);
      return this;
    }

    /// <summary>
    /// Use old format for model output. The old format is better when there are
    /// many class values. The new format is better when there are fewer classes
    /// and many attributes.
    /// </summary>    
    public NaiveBayesUpdateable<T> DisplayModelInOldFormat (bool d) {
      ((NaiveBayesUpdateable)Impl).setDisplayModelInOldFormat(d);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public NaiveBayesUpdateable<T> Debug (bool debug) {
      ((NaiveBayesUpdateable)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}