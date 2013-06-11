using weka.core;
using weka.classifiers.trees;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for generating a pruned or unpruned C4.5 decision tree. For more
  /// information, see Ross Quinlan (1993). C4.5: Programs for Machine Learning.
  /// Morgan Kaufmann Publishers, San Mateo, CA.
  /// </summary>
  public class J48<T> : BaseClassifier<T>
  {
    public J48(Runtime<T> rt) : base(rt, new J48()) {}

    /// <summary>
    /// The seed used for randomizing the data when reduced-error pruning is
    /// used.
    /// </summary>    
    public J48<T> Seed (int value) {
      ((J48)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// Whether counts at leaves are smoothed based on Laplace.
    /// </summary>    
    public J48<T> UseLaplace (bool value) {
      ((J48)impl).setUseLaplace(value);
      return this;
    }

    /// <summary>
    /// Whether MDL correction is used when finding splits on numeric attributes.
    /// </summary>    
    public J48<T> UseMDLcorrection (bool value) {
      ((J48)impl).setUseMDLcorrection(value);
      return this;
    }

    /// <summary>
    /// Whether pruning is performed.
    /// </summary>    
    public J48<T> Unpruned (bool value) {
      ((J48)impl).setUnpruned(value);
      return this;
    }

    /// <summary>
    /// Whether parts are removed that do not reduce training error.
    /// </summary>    
    public J48<T> CollapseTree (bool value) {
      ((J48)impl).setCollapseTree(value);
      return this;
    }

    /// <summary>
    /// The minimum number of instances per leaf.
    /// </summary>    
    public J48<T> MinNumObj (int value) {
      ((J48)impl).setMinNumObj(value);
      return this;
    }

    /// <summary>
    /// Whether reduced-error pruning is used instead of C.4.5 pruning.
    /// </summary>    
    public J48<T> ReducedErrorPruning (bool value) {
      ((J48)impl).setReducedErrorPruning(value);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for reduced-error pruning. One fold is
    /// used for pruning, the rest for growing the tree.
    /// </summary>    
    public J48<T> NumFolds (int value) {
      ((J48)impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// Whether to use binary splits on nominal attributes when building the
    /// trees.
    /// </summary>    
    public J48<T> BinarySplits (bool value) {
      ((J48)impl).setBinarySplits(value);
      return this;
    }

    /// <summary>
    /// Whether to consider the subtree raising operation when pruning.
    /// </summary>    
    public J48<T> SubtreeRaising (bool value) {
      ((J48)impl).setSubtreeRaising(value);
      return this;
    }

    /// <summary>
    /// Whether to save the training data for visualization.
    /// </summary>    
    public J48<T> SaveInstanceData (bool value) {
      ((J48)impl).setSaveInstanceData(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public J48<T> Debug (bool value) {
      ((J48)impl).setDebug(value);
      return this;
    }

        
        
  }
}