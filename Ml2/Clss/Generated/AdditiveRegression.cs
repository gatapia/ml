using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Meta classifier that enhances the performance of a regression base
  /// classifier. Each iteration fits a model to the residuals left by the classifier
  /// on the previous iteration. Prediction is accomplished by adding the
  /// predictions of each classifier. Reducing the shrinkage (learning rate) parameter
  /// helps prevent overfitting and has a smoothing effect but increases the
  /// learning time. For more information see: J.H. Friedman (1999). Stochastic
  /// Gradient Boosting.
  /// </summary>
  public class AdditiveRegression<T> : BaseClassifier<T, AdditiveRegression> where T : new()
  {
    public AdditiveRegression(Runtime<T> rt) : base(rt, new AdditiveRegression()) {}

    /// <summary>
    /// Shrinkage rate. Smaller values help prevent overfitting and have a
    /// smoothing effect (but increase learning time). Default = 1.0, ie. no shrinkage.
    /// </summary>    
    public AdditiveRegression<T> Shrinkage (double l) {
      ((AdditiveRegression)Impl).setShrinkage(l);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public AdditiveRegression<T> NumIterations (int numIterations) {
      ((AdditiveRegression)Impl).setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public AdditiveRegression<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((AdditiveRegression)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AdditiveRegression<T> Debug (bool debug) {
      ((AdditiveRegression)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}