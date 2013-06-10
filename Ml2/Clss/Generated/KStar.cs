using weka.classifiers.lazy;

namespace Ml2.Clss
{
  /// <summary>
  /// K* is an instance-based classifier, that is the class of a test instance
  /// is based upon the class of those training instances similar to it, as
  /// determined by some similarity function. It differs from other instance-based
  /// learners in that it uses an entropy-based distance function. For more
  /// information on K*, see John G. Cleary, Leonard E. Trigg: K*: An Instance-based
  /// Learner Using an Entropic Distance Measure. In: 12th International Conference
  /// on Machine Learning, 108-114, 1995.
  /// </summary>
  public class KStar<T> : BaseClassifier<T>
  {
    public KStar(Runtime<T> rt) : base(rt, new KStar()) {}

    /// <summary>
    /// The parameter for global blending. Values are restricted to [0,100].
    /// </summary>    
    public KStar<T> GlobalBlend (int value) {
      ((KStar)impl).setGlobalBlend(value);
      return this;
    }

    /// <summary>
    /// Whether entropy-based blending is to be used.
    /// </summary>    
    public KStar<T> EntropicAutoBlend (bool value) {
      ((KStar)impl).setEntropicAutoBlend(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public KStar<T> Debug (bool value) {
      ((KStar)impl).setDebug(value);
      return this;
    }

        
  }
}