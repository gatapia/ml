using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for bagging a classifier to reduce variance. Can do classification
  /// and regression depending on the base learner. For more information, see Leo
  /// Breiman (1996). Bagging predictors. Machine Learning. 24(2):123-140.
  /// </summary>
  public class Bagging<T> : BaseClassifier<T, Bagging>
  {
    public Bagging(Runtime<T> rt) : base(rt, new Bagging()) {}

    /// <summary>
    /// Size of each bag, as a percentage of the training set size.
    /// </summary>    
    public Bagging<T> BagSizePercent (int newBagSizePercent) {
      ((Bagging)Impl).setBagSizePercent(newBagSizePercent);
      return this;
    }

    /// <summary>
    /// Whether the out-of-bag error is calculated.
    /// </summary>    
    public Bagging<T> CalcOutOfBag (bool calcOutOfBag) {
      ((Bagging)Impl).setCalcOutOfBag(calcOutOfBag);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public Bagging<T> Seed (int seed) {
      ((Bagging)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public Bagging<T> NumExecutionSlots (int numSlots) {
      ((Bagging)Impl).setNumExecutionSlots(numSlots);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public Bagging<T> NumIterations (int numIterations) {
      ((Bagging)Impl).setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public Bagging<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((Bagging)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Bagging<T> Debug (bool debug) {
      ((Bagging)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}