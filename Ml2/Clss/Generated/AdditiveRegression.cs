using weka.core;
using weka.classifiers.meta;

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
  public class AdditiveRegression<T> : BaseClassifier<T>
  {
    public AdditiveRegression(Runtime<T> rt) : base(rt, new AdditiveRegression()) {}

    /// <summary>
    /// Shrinkage rate. Smaller values help prevent overfitting and have a
    /// smoothing effect (but increase learning time). Default = 1.0, ie. no shrinkage.
    /// </summary>    
    public AdditiveRegression<T> Shrinkage (double value) {
      ((AdditiveRegression)Impl).setShrinkage(value);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public AdditiveRegression<T> NumIterations (int value) {
      ((AdditiveRegression)Impl).setNumIterations(value);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public AdditiveRegression<T> Classifier (Clss.BaseClassifier<T> value) {
      ((AdditiveRegression)Impl).setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AdditiveRegression<T> Debug (bool value) {
      ((AdditiveRegression)Impl).setDebug(value);
      return this;
    }

        
        
  }
}