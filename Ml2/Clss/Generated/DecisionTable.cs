using weka.core;
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
    /// The measure used to evaluate the performance of attribute combinations
    /// used in the decision table.
    /// </summary>    
    public DecisionTable<T> EvaluationMeasure (EEvaluationMeasure value) {
      ((weka.classifiers.rules.DecisionTable)impl).setEvaluationMeasure(new SelectedTag((int) value, weka.classifiers.rules.DecisionTable.TAGS_EVALUATION));
      return this;
    }

    /// <summary>
    /// Sets the number of folds for cross validation (1 = leave one out).
    /// </summary>    
    public DecisionTable<T> CrossVal (int value) {
      ((weka.classifiers.rules.DecisionTable)impl).setCrossVal(value);
      return this;
    }

    /// <summary>
    /// Sets whether IBk should be used instead of the majority class.
    /// </summary>    
    public DecisionTable<T> UseIBk (bool value) {
      ((weka.classifiers.rules.DecisionTable)impl).setUseIBk(value);
      return this;
    }

    /// <summary>
    /// Sets whether rules are to be printed.
    /// </summary>    
    public DecisionTable<T> DisplayRules (bool value) {
      ((weka.classifiers.rules.DecisionTable)impl).setDisplayRules(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public DecisionTable<T> Debug (bool value) {
      ((weka.classifiers.rules.DecisionTable)impl).setDebug(value);
      return this;
    }

        
    public enum EEvaluationMeasure {
      Default__accuracy_discrete_class_RMSE_numeric_class = 1,
      Accuracy_discrete_class_only = 2,
      RMSE_of_the_class_probabilities_for_discrete_class = 3,
      MAE_of_the_class_probabilities_for_discrete_class = 4,
      AUC_area_under_the_ROC_curve___discrete_class_only = 5
    }

        
  }
}