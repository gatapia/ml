using weka.core;
using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// This method constructs a decision tree based classifier that maintains
  /// highest accuracy on training data and improves on generalization accuracy as
  /// it grows in complexity. The classifier consists of multiple trees
  /// constructed systematically by pseudorandomly selecting subsets of components of the
  /// feature vector, that is, trees constructed in randomly chosen subspaces.
  /// For more information, see Tin Kam Ho (1998). The Random Subspace Method for
  /// Constructing Decision Forests. IEEE Transactions on Pattern Analysis and
  /// Machine Intelligence. 20(8):832-844. URL
  /// http://citeseer.ist.psu.edu/ho98random.html.
  /// </summary>
  public class RandomSubSpace<T> : BaseClassifier<T>
  {
    public RandomSubSpace(Runtime<T> rt) : base(rt, new RandomSubSpace()) {}

    /// <summary>
    /// Size of each subSpace: if less than 1 as a percentage of the number of
    /// attributes, otherwise the absolute number of attributes.
    /// </summary>    
    public RandomSubSpace<T> SubSpaceSize (double value) {
      ((weka.classifiers.meta.RandomSubSpace)impl).setSubSpaceSize(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public RandomSubSpace<T> Seed (int value) {
      ((weka.classifiers.meta.RandomSubSpace)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public RandomSubSpace<T> NumExecutionSlots (int value) {
      ((weka.classifiers.meta.RandomSubSpace)impl).setNumExecutionSlots(value);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public RandomSubSpace<T> NumIterations (int value) {
      ((weka.classifiers.meta.RandomSubSpace)impl).setNumIterations(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomSubSpace<T> Debug (bool value) {
      ((weka.classifiers.meta.RandomSubSpace)impl).setDebug(value);
      return this;
    }

        
        
  }
}