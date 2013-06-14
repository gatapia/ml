using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// M5Base. Implements base routines for generating M5 Model trees and
  /// rules<br/>The original algorithm M5 was invented by R. Quinlan and Yong Wang made
  /// improvements.<br/><br/>For more information see:<br/><br/>Ross J. Quinlan:
  /// Learning with Continuous Classes. In: 5th Australian Joint Conference on
  /// Artificial Intelligence, Singapore, 343-348, 1992.<br/><br/>Y. Wang, I. H.
  /// Witten: Induction of model trees for predicting continuous classes. In:
  /// Poster papers of the 9th European Conference on Machine Learning,
  /// 1997.<br/><br/>Options:<br/><br/>-N = 	Use unpruned tree/rules<br/>-U = 	Use unsmoothed
  /// predictions<br/>-R = 	Build regression tree/rule rather than a model
  /// tree/rule<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
  /// instances per leaf<br/>	(default 4)<br/>-L = 	Save instances at the nodes
  /// in<br/>	the tree (for visualization purposes)
  /// </summary>
  public class M5P<T> : BaseClassifier<T, M5P> where T : new()
  {
    public M5P(Runtime<T> rt) : base(rt, new M5P()) {}

    /// <summary>
    /// Whether to save instance data at each node in the tree for visualization
    /// purposes.
    /// </summary>    
    public M5P<T> SaveInstances (bool save) {
      ((M5P)Impl).setSaveInstances(save);
      return this;
    }

    /// <summary>
    /// Whether unpruned tree/rules are to be generated.
    /// </summary>    
    public M5P<T> Unpruned (bool unpruned) {
      ((M5P)Impl).setUnpruned(unpruned);
      return this;
    }

    /// <summary>
    /// Whether to use unsmoothed predictions.
    /// </summary>    
    public M5P<T> UseUnsmoothed (bool s) {
      ((M5P)Impl).setUseUnsmoothed(s);
      return this;
    }

    /// <summary>
    /// Whether to generate a regression tree/rule instead of a model tree/rule.
    /// </summary>    
    public M5P<T> BuildRegressionTree (bool newregressionTree) {
      ((M5P)Impl).setBuildRegressionTree(newregressionTree);
      return this;
    }

    /// <summary>
    /// The minimum number of instances to allow at a leaf node.
    /// </summary>    
    public M5P<T> MinNumInstances (double minNum) {
      ((M5P)Impl).setMinNumInstances(minNum);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public M5P<T> Debug (bool debug) {
      ((M5P)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}