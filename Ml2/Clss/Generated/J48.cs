using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
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
    public J48<T> Seed (int newSeed) {
      ((J48)Impl).setSeed(newSeed);
      return this;
    }

    /// <summary>
    /// Whether counts at leaves are smoothed based on Laplace.
    /// </summary>    
    public J48<T> UseLaplace (bool newuseLaplace) {
      ((J48)Impl).setUseLaplace(newuseLaplace);
      return this;
    }

    /// <summary>
    /// Whether MDL correction is used when finding splits on numeric attributes.
    /// </summary>    
    public J48<T> UseMDLcorrection (bool newuseMDLcorrection) {
      ((J48)Impl).setUseMDLcorrection(newuseMDLcorrection);
      return this;
    }

    /// <summary>
    /// Whether pruning is performed.
    /// </summary>    
    public J48<T> Unpruned (bool v) {
      ((J48)Impl).setUnpruned(v);
      return this;
    }

    /// <summary>
    /// Whether parts are removed that do not reduce training error.
    /// </summary>    
    public J48<T> CollapseTree (bool v) {
      ((J48)Impl).setCollapseTree(v);
      return this;
    }

    /// <summary>
    /// The minimum number of instances per leaf.
    /// </summary>    
    public J48<T> MinNumObj (int v) {
      ((J48)Impl).setMinNumObj(v);
      return this;
    }

    /// <summary>
    /// Whether reduced-error pruning is used instead of C.4.5 pruning.
    /// </summary>    
    public J48<T> ReducedErrorPruning (bool v) {
      ((J48)Impl).setReducedErrorPruning(v);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for reduced-error pruning. One fold is
    /// used for pruning, the rest for growing the tree.
    /// </summary>    
    public J48<T> NumFolds (int v) {
      ((J48)Impl).setNumFolds(v);
      return this;
    }

    /// <summary>
    /// Whether to use binary splits on nominal attributes when building the
    /// trees.
    /// </summary>    
    public J48<T> BinarySplits (bool v) {
      ((J48)Impl).setBinarySplits(v);
      return this;
    }

    /// <summary>
    /// Whether to consider the subtree raising operation when pruning.
    /// </summary>    
    public J48<T> SubtreeRaising (bool v) {
      ((J48)Impl).setSubtreeRaising(v);
      return this;
    }

    /// <summary>
    /// Whether to save the training data for visualization.
    /// </summary>    
    public J48<T> SaveInstanceData (bool v) {
      ((J48)Impl).setSaveInstanceData(v);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public J48<T> Debug (bool debug) {
      ((J48)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}