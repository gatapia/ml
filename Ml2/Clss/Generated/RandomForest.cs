using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for constructing a forest of random trees. For more information
  /// see: Leo Breiman (2001). Random Forests. Machine Learning. 45(1):5-32.
  /// </summary>
  public class RandomForest<T> : BaseClassifier<T, RandomForest> where T : new()
  {
    public RandomForest(Runtime<T> rt) : base(rt, new RandomForest()) {}

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public RandomForest<T> Seed (int seed) {
      ((RandomForest)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// The maximum depth of the trees, 0 for unlimited.
    /// </summary>    
    public RandomForest<T> MaxDepth (int value) {
      ((RandomForest)Impl).setMaxDepth(value);
      return this;
    }

    /// <summary>
    /// Print the individual trees in the output
    /// </summary>    
    public RandomForest<T> PrintTrees (bool print) {
      ((RandomForest)Impl).setPrintTrees(print);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public RandomForest<T> NumExecutionSlots (int numSlots) {
      ((RandomForest)Impl).setNumExecutionSlots(numSlots);
      return this;
    }

    /// <summary>
    /// The number of trees to be generated.
    /// </summary>    
    public RandomForest<T> NumTrees (int newNumTrees) {
      ((RandomForest)Impl).setNumTrees(newNumTrees);
      return this;
    }

    /// <summary>
    /// The number of attributes to be used in random selection (see RandomTree).
    /// </summary>    
    public RandomForest<T> NumFeatures (int newNumFeatures) {
      ((RandomForest)Impl).setNumFeatures(newNumFeatures);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomForest<T> Debug (bool debug) {
      ((RandomForest)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}