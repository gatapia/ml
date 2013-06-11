using weka.core;
using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// Combines several classifiers using the stacking method. Can do
  /// classification or regression. For more information, see David H. Wolpert (1992).
  /// Stacked generalization. Neural Networks. 5:241-259.
  /// </summary>
  public class Stacking<T> : BaseClassifier<T>
  {
    public Stacking(Runtime<T> rt) : base(rt, new Stacking()) {}

    /// <summary>
    /// The number of folds used for cross-validation.
    /// </summary>    
    public Stacking<T> NumFolds (int value) {
      ((Stacking)impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public Stacking<T> Seed (int value) {
      ((Stacking)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public Stacking<T> NumExecutionSlots (int value) {
      ((Stacking)impl).setNumExecutionSlots(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Stacking<T> Debug (bool value) {
      ((Stacking)impl).setDebug(value);
      return this;
    }

        
        
  }
}