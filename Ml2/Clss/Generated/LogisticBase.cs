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
      ((LogisticBase)Impl).setMaxIterations(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> HeuristicStop (int value) {
      ((LogisticBase)Impl).setHeuristicStop(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> WeightTrimBeta (double value) {
      ((LogisticBase)Impl).setWeightTrimBeta(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> UseAIC (bool value) {
      ((LogisticBase)Impl).setUseAIC(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LogisticBase<T> Debug (bool value) {
      ((LogisticBase)Impl).setDebug(value);
      return this;
    }

        
        
  }
}