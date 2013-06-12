using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
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
    public RandomTree<T> KValue (int k) {
      ((RandomTree)Impl).setKValue(k);
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
    public RandomTree<T> Seed (int seed) {
      ((RandomTree)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// Whether to allow unclassified instances.
    /// </summary>    
    public RandomTree<T> AllowUnclassifiedInstances (bool newAllowUnclassifiedInstances) {
      ((RandomTree)Impl).setAllowUnclassifiedInstances(newAllowUnclassifiedInstances);
      return this;
    }

    /// <summary>
    /// The minimum total weight of the instances in a leaf.
    /// </summary>    
    public RandomTree<T> MinNum (double newMinNum) {
      ((RandomTree)Impl).setMinNum(newMinNum);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for backfitting. One fold is used for
    /// backfitting, the rest for growing the tree. (Default: 0, no backfitting)
    /// </summary>    
    public RandomTree<T> NumFolds (int newNumFolds) {
      ((RandomTree)Impl).setNumFolds(newNumFolds);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomTree<T> Debug (bool debug) {
      ((RandomTree)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}