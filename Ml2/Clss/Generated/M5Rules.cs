using weka.classifiers.rules;

namespace Ml2.Clss
{
  /// <summary>
  /// Generates a decision list for regression problems using
  /// separate-and-conquer. In each iteration it builds a model tree using M5 and makes the "best"
  /// leaf into a rule. For more information see: Geoffrey Holmes, Mark Hall,
  /// Eibe Frank: Generating Rule Sets from Model Trees. In: Twelfth Australian
  /// Joint Conference on Artificial Intelligence, 1-12, 1999. Ross J. Quinlan:
  /// Learning with Continuous Classes. In: 5th Australian Joint Conference on
  /// Artificial Intelligence, Singapore, 343-348, 1992. Y. Wang, I. H. Witten:
  /// Induction of model trees for predicting continuous classes. In: Poster papers of
  /// the 9th European Conference on Machine Learning, 1997.
  /// </summary>
  public class M5Rules<T> : BaseClassifier<T>
  {
    public M5Rules(Runtime<T> rt) : base(rt, new M5Rules()) {}

    /// <summary>
    /// Whether unpruned tree/rules are to be generated.
    /// </summary>    
    public M5Rules<T> Unpruned (bool value) {
      ((M5Rules)impl).setUnpruned(value);
      return this;
    }

    /// <summary>
    /// Whether to use unsmoothed predictions.
    /// </summary>    
    public M5Rules<T> UseUnsmoothed (bool value) {
      ((M5Rules)impl).setUseUnsmoothed(value);
      return this;
    }

    /// <summary>
    /// Whether to generate a regression tree/rule instead of a model tree/rule.
    /// </summary>    
    public M5Rules<T> BuildRegressionTree (bool value) {
      ((M5Rules)impl).setBuildRegressionTree(value);
      return this;
    }

    /// <summary>
    /// The minimum number of instances to allow at a leaf node.
    /// </summary>    
    public M5Rules<T> MinNumInstances (double value) {
      ((M5Rules)impl).setMinNumInstances(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public M5Rules<T> Debug (bool value) {
      ((M5Rules)impl).setDebug(value);
      return this;
    }

        
  }
}