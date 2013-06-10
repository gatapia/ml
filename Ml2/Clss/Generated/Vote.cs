using weka.classifiers.meta;

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
    /// The random number seed to be used.
    /// </summary>    
    public Vote<T> Seed (int value) {
      ((Vote)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Vote<T> Debug (bool value) {
      ((Vote)impl).setDebug(value);
      return this;
    }

        
  }
}