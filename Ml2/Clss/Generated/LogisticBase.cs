using System.Linq;
using weka.classifiers.trees.lmt;

// ReSharper disable once CheckNamespace
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
    public LogisticBase<T> MaxIterations (int maxIterations) {
      ((LogisticBase)Impl).setMaxIterations(maxIterations);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> HeuristicStop (int heuristicStop) {
      ((LogisticBase)Impl).setHeuristicStop(heuristicStop);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> WeightTrimBeta (double w) {
      ((LogisticBase)Impl).setWeightTrimBeta(w);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase<T> UseAIC (bool c) {
      ((LogisticBase)Impl).setUseAIC(c);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LogisticBase<T> Debug (bool debug) {
      ((LogisticBase)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}