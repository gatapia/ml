using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Fast decision tree learner. Builds a decision/regression tree using
  /// information gain/variance and prunes it using reduced-error pruning (with
  /// backfitting). Only sorts values for numeric attributes once. Missing values are
  /// dealt with by splitting the corresponding instances into pieces (i.e. as in
  /// C4.5).
  /// </summary>
  public class REPTree<T> : BaseClassifier<T>
  {
    public REPTree(Runtime<T> rt) : base(rt, new REPTree()) {}

    /// <summary>
    /// Whether pruning is performed.
    /// </summary>    
    public REPTree<T> NoPruning (bool newNoPruning) {
      ((REPTree)Impl).setNoPruning(newNoPruning);
      return this;
    }

    /// <summary>
    /// The minimum total weight of the instances in a leaf.
    /// </summary>    
    public REPTree<T> MinNum (double newMinNum) {
      ((REPTree)Impl).setMinNum(newMinNum);
      return this;
    }

    /// <summary>
    /// The minimum proportion of the variance on all the data that needs to be
    /// present at a node in order for splitting to be performed in regression
    /// trees.
    /// </summary>    
    public REPTree<T> MinVarianceProp (double newMinVarianceProp) {
      ((REPTree)Impl).setMinVarianceProp(newMinVarianceProp);
      return this;
    }

    /// <summary>
    /// The seed used for randomizing the data.
    /// </summary>    
    public REPTree<T> Seed (int newSeed) {
      ((REPTree)Impl).setSeed(newSeed);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for pruning. One fold is used for
    /// pruning, the rest for growing the rules.
    /// </summary>    
    public REPTree<T> NumFolds (int newNumFolds) {
      ((REPTree)Impl).setNumFolds(newNumFolds);
      return this;
    }

    /// <summary>
    /// The maximum tree depth (-1 for no restriction).
    /// </summary>    
    public REPTree<T> MaxDepth (int newMaxDepth) {
      ((REPTree)Impl).setMaxDepth(newMaxDepth);
      return this;
    }

    /// <summary>
    /// Initial class value count.
    /// </summary>    
    public REPTree<T> InitialCount (double newInitialCount) {
      ((REPTree)Impl).setInitialCount(newInitialCount);
      return this;
    }

    /// <summary>
    /// Spread initial count across all values instead of using the count per
    /// value.
    /// </summary>    
    public REPTree<T> SpreadInitialCount (bool newSpreadInitialCount) {
      ((REPTree)Impl).setSpreadInitialCount(newSpreadInitialCount);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public REPTree<T> Debug (bool debug) {
      ((REPTree)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}