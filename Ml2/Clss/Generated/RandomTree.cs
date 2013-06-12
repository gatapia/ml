using weka.core;
using weka.classifiers.trees;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for constructing a tree that considers K randomly chosen attributes
  /// at each node. Performs no pruning. Also has an option to allow estimation
  /// of class probabilities based on a hold-out set (backfitting).
  /// </summary>
  public class RandomTree<T> : BaseClassifier<T>
  {
    public RandomTree(Runtime<T> rt) : base(rt, new RandomTree()) {}

    /// <summary>
    /// 
    /// </summary>    
    public RandomTree<T> KValue (int value) {
      ((RandomTree)Impl).setKValue(value);
      return this;
    }

    /// <summary>
    /// The maximum depth of the tree, 0 for unlimited.
    /// </summary>    
    public RandomTree<T> MaxDepth (int value) {
      ((RandomTree)Impl).setMaxDepth(value);
      return this;
    }

    /// <summary>
    /// The random number seed used for selecting attributes.
    /// </summary>    
    public RandomTree<T> Seed (int value) {
      ((RandomTree)Impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// Whether to allow unclassified instances.
    /// </summary>    
    public RandomTree<T> AllowUnclassifiedInstances (bool value) {
      ((RandomTree)Impl).setAllowUnclassifiedInstances(value);
      return this;
    }

    /// <summary>
    /// The minimum total weight of the instances in a leaf.
    /// </summary>    
    public RandomTree<T> MinNum (double value) {
      ((RandomTree)Impl).setMinNum(value);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for backfitting. One fold is used for
    /// backfitting, the rest for growing the tree. (Default: 0, no backfitting)
    /// </summary>    
    public RandomTree<T> NumFolds (int value) {
      ((RandomTree)Impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomTree<T> Debug (bool value) {
      ((RandomTree)Impl).setDebug(value);
      return this;
    }

        
        
  }
}