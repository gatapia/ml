using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// A metaclassifier that makes its base classifier cost-sensitive. Two
  /// methods can be used to introduce cost-sensitivity: reweighting training
  /// instances according to the total cost assigned to each class; or predicting the
  /// class with minimum expected misclassification cost (rather than the most
  /// likely class). Performance can often be improved by using a Bagged classifier to
  /// improve the probability estimates of the base classifier.
  /// </summary>
  public class CostSensitiveClassifier<T> : BaseClassifier<T>
  {
    public CostSensitiveClassifier(Runtime<T> rt) : base(rt, new CostSensitiveClassifier()) {}

    /// <summary>
    /// Sets whether the minimum expected cost criteria will be used. If this is
    /// false, the training data will be reweighted according to the costs assigned
    /// to each class. If true, the minimum expected cost criteria will be used.
    /// </summary>    
    public CostSensitiveClassifier<T> MinimizeExpectedCost (bool value) {
      ((CostSensitiveClassifier)impl).setMinimizeExpectedCost(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public CostSensitiveClassifier<T> Seed (int value) {
      ((CostSensitiveClassifier)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public CostSensitiveClassifier<T> Debug (bool value) {
      ((CostSensitiveClassifier)impl).setDebug(value);
      return this;
    }

        
  }
}