using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for constructing a forest of random trees. For more information
  /// see: Leo Breiman (2001). Random Forests. Machine Learning. 45(1):5-32.
  /// </summary>
  public class RandomForest<T> : BaseClassifier<T>
  {
    public RandomForest(Runtime<T> rt) : base(rt, new RandomForest()) {}

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public RandomForest<T> Seed (int value) {
      ((RandomForest)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// The maximum depth of the trees, 0 for unlimited.
    /// </summary>    
    public RandomForest<T> MaxDepth (int value) {
      ((RandomForest)impl).setMaxDepth(value);
      return this;
    }

    /// <summary>
    /// Print the individual trees in the output
    /// </summary>    
    public RandomForest<T> PrintTrees (bool value) {
      ((RandomForest)impl).setPrintTrees(value);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public RandomForest<T> NumExecutionSlots (int value) {
      ((RandomForest)impl).setNumExecutionSlots(value);
      return this;
    }

    /// <summary>
    /// The number of trees to be generated.
    /// </summary>    
    public RandomForest<T> NumTrees (int value) {
      ((RandomForest)impl).setNumTrees(value);
      return this;
    }

    /// <summary>
    /// The number of attributes to be used in random selection (see RandomTree).
    /// </summary>    
    public RandomForest<T> NumFeatures (int value) {
      ((RandomForest)impl).setNumFeatures(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomForest<T> Debug (bool value) {
      ((RandomForest)impl).setDebug(value);
      return this;
    }

        
  }
}