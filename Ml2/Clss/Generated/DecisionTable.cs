using weka.classifiers.rules;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a simple decision table majority classifier.
  /// For more information see: Ron Kohavi: The Power of Decision Tables. In:
  /// 8th European Conference on Machine Learning, 174-189, 1995.
  /// </summary>
  public class DecisionTable<T> : BaseClassifier<T>
  {
    public DecisionTable(Runtime<T> rt) : base(rt, new DecisionTable()) {}

    /// <summary>
    /// Sets the number of folds for cross validation (1 = leave one out).
    /// </summary>    
    public DecisionTable<T> CrossVal (int value) {
      ((DecisionTable)impl).setCrossVal(value);
      return this;
    }

    /// <summary>
    /// Sets whether IBk should be used instead of the majority class.
    /// </summary>    
    public DecisionTable<T> UseIBk (bool value) {
      ((DecisionTable)impl).setUseIBk(value);
      return this;
    }

    /// <summary>
    /// Sets whether rules are to be printed.
    /// </summary>    
    public DecisionTable<T> DisplayRules (bool value) {
      ((DecisionTable)impl).setDisplayRules(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public DecisionTable<T> Debug (bool value) {
      ((DecisionTable)impl).setDebug(value);
      return this;
    }

        
  }
}