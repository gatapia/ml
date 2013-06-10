using weka.classifiers.trees;

namespace Ml2.Clss
{
  /// <summary>
  /// M5Base. Implements base routines for generating M5 Model trees and rules
  /// The original algorithm M5 was invented by R. Quinlan and Yong Wang made
  /// improvements. For more information see: Ross J. Quinlan: Learning with
  /// Continuous Classes. In: 5th Australian Joint Conference on Artificial
  /// Intelligence, Singapore, 343-348, 1992. Y. Wang, I. H. Witten: Induction of model trees
  /// for predicting continuous classes. In: Poster papers of the 9th European
  /// Conference on Machine Learning, 1997.
  /// </summary>
  public class M5P<T> : BaseClassifier<T>
  {
    public M5P(Runtime<T> rt) : base(rt, new M5P()) {}

    /// <summary>
    /// Whether to save instance data at each node in the tree for visualization
    /// purposes.
    /// </summary>    
    public M5P<T> SaveInstances (bool value) {
      ((M5P)impl).setSaveInstances(value);
      return this;
    }

    /// <summary>
    /// Whether unpruned tree/rules are to be generated.
    /// </summary>    
    public M5P<T> Unpruned (bool value) {
      ((M5P)impl).setUnpruned(value);
      return this;
    }

    /// <summary>
    /// Whether to use unsmoothed predictions.
    /// </summary>    
    public M5P<T> UseUnsmoothed (bool value) {
      ((M5P)impl).setUseUnsmoothed(value);
      return this;
    }

    /// <summary>
    /// Whether to generate a regression tree/rule instead of a model tree/rule.
    /// </summary>    
    public M5P<T> BuildRegressionTree (bool value) {
      ((M5P)impl).setBuildRegressionTree(value);
      return this;
    }

    /// <summary>
    /// The minimum number of instances to allow at a leaf node.
    /// </summary>    
    public M5P<T> MinNumInstances (double value) {
      ((M5P)impl).setMinNumInstances(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public M5P<T> Debug (bool value) {
      ((M5P)impl).setDebug(value);
      return this;
    }

        
  }
}