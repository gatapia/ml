using weka.classifiers.bayes;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for a Naive Bayes classifier using estimator classes. Numeric
  /// estimator precision values are chosen based on analysis of the training data.
  /// For this reason, the classifier is not an UpdateableClassifier (which in
  /// typical usage are initialized with zero training instances) -- if you need the
  /// UpdateableClassifier functionality, use the NaiveBayesUpdateable
  /// classifier. The NaiveBayesUpdateable classifier will use a default precision of 0.1
  /// for numeric attributes when buildClassifier is called with zero training
  /// instances. For more information on Naive Bayes classifiers, see George H.
  /// John, Pat Langley: Estimating Continuous Distributions in Bayesian Classifiers.
  /// In: Eleventh Conference on Uncertainty in Artificial Intelligence, San
  /// Mateo, 338-345, 1995.
  /// </summary>
  public class NaiveBayes<T> : BaseClassifier<T>
  {
    public NaiveBayes(Runtime<T> rt) : base(rt, new NaiveBayes()) {}

    /// <summary>
    /// Use supervised discretization to convert numeric attributes to nominal
    /// ones.
    /// </summary>    
    public NaiveBayes<T> UseSupervisedDiscretization (bool newblah) {
      ((NaiveBayes)Impl).setUseSupervisedDiscretization(newblah);
      return this;
    }

    /// <summary>
    /// Use a kernel estimator for numeric attributes rather than a normal
    /// distribution.
    /// </summary>    
    public NaiveBayes<T> UseKernelEstimator (bool v) {
      ((NaiveBayes)Impl).setUseKernelEstimator(v);
      return this;
    }

    /// <summary>
    /// Use old format for model output. The old format is better when there are
    /// many class values. The new format is better when there are fewer classes
    /// and many attributes.
    /// </summary>    
    public NaiveBayes<T> DisplayModelInOldFormat (bool d) {
      ((NaiveBayes)Impl).setDisplayModelInOldFormat(d);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public NaiveBayes<T> Debug (bool debug) {
      ((NaiveBayes)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}