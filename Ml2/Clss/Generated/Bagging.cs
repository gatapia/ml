using weka.core;
using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for bagging a classifier to reduce variance. Can do classification
  /// and regression depending on the base learner. For more information, see Leo
  /// Breiman (1996). Bagging predictors. Machine Learning. 24(2):123-140.
  /// </summary>
  public class Bagging<T> : BaseClassifier<T>
  {
    public Bagging(Runtime<T> rt) : base(rt, new Bagging()) {}

    /// <summary>
    /// Size of each bag, as a percentage of the training set size.
    /// </summary>    
    public Bagging<T> BagSizePercent (int value) {
      ((Bagging)Impl).setBagSizePercent(value);
      return this;
    }

    /// <summary>
    /// Whether the out-of-bag error is calculated.
    /// </summary>    
    public Bagging<T> CalcOutOfBag (bool value) {
      ((Bagging)Impl).setCalcOutOfBag(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public Bagging<T> Seed (int value) {
      ((Bagging)Impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public Bagging<T> NumExecutionSlots (int value) {
      ((Bagging)Impl).setNumExecutionSlots(value);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public Bagging<T> NumIterations (int value) {
      ((Bagging)Impl).setNumIterations(value);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public Bagging<T> Classifier (Clss.BaseClassifier<T> value) {
      ((Bagging)Impl).setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Bagging<T> Debug (bool value) {
      ((Bagging)Impl).setDebug(value);
      return this;
    }

        
        
  }
}