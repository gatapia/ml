using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for combining classifiers. Different combinations of probability
  /// estimates for classification are available. For more information see: Ludmila
  /// I. Kuncheva (2004). Combining Pattern Classifiers: Methods and Algorithms.
  /// John Wiley and Sons, Inc.. J. Kittler, M. Hatef, Robert P.W. Duin, J.
  /// Matas (1998). On combining classifiers. IEEE Transactions on Pattern Analysis
  /// and Machine Intelligence. 20(3):226-239.
  /// </summary>
  public class Vote<T> : BaseClassifier<T>
  {
    public Vote(Runtime<T> rt) : base(rt, new Vote()) {}

    /// <summary>
    /// The combination rule used.
    /// </summary>    
    public Vote<T> CombinationRule (ECombinationRule newRule) {
      ((Vote)Impl).setCombinationRule(new weka.core.SelectedTag((int) newRule, Vote.TAGS_RULES));
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public Vote<T> Seed (int seed) {
      ((Vote)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Vote<T> Debug (bool debug) {
      ((Vote)Impl).setDebug(debug);
      return this;
    }

        
    public enum ECombinationRule {
      Average_of_Probabilities = 1,
      Product_of_Probabilities = 2,
      Majority_Voting = 3,
      Minimum_Probability = 4,
      Maximum_Probability = 5,
      Median = 6
    }

        
  }
}