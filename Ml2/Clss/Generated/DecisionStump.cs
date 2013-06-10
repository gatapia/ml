using weka.classifiers.trees;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a decision stump. Usually used in
  /// conjunction with a boosting algorithm. Does regression (based on mean-squared error)
  /// or classification (based on entropy). Missing is treated as a separate
  /// value.
  /// </summary>
  public class DecisionStump<T> : BaseClassifier<T>
  {
    public DecisionStump(Runtime<T> rt) : base(rt, new DecisionStump()) {}

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public DecisionStump<T> Debug (bool value) {
      ((DecisionStump)impl).setDebug(value);
      return this;
    }

        
  }
}