using weka.core;
using weka.classifiers.trees.lmt;

namespace Ml2.Clss
{
  /// <summary>
  /// No class description found.
  /// </summary>
  public class LogisticBase<T> : BaseClassifier<T>
  {
    public LogisticBase(Runtime<T> rt) : base(rt, new LogisticBase()) {}

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> MaxIterations (int value) {
      ((weka.classifiers.trees.lmt.LogisticBase)impl).setMaxIterations(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> HeuristicStop (int value) {
      ((weka.classifiers.trees.lmt.LogisticBase)impl).setHeuristicStop(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> WeightTrimBeta (double value) {
      ((weka.classifiers.trees.lmt.LogisticBase)impl).setWeightTrimBeta(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> UseAIC (bool value) {
      ((weka.classifiers.trees.lmt.LogisticBase)impl).setUseAIC(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LogisticBase<T> Debug (bool value) {
      ((weka.classifiers.trees.lmt.LogisticBase)impl).setDebug(value);
      return this;
    }

        
        
  }
}