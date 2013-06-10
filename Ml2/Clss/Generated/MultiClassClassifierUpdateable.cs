using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// A metaclassifier for handling multi-class datasets with 2-class
  /// classifiers. This classifier is also capable of applying error correcting output
  /// codes for increased accuracy. The base classifier must be an updateable
  /// classifier
  /// </summary>
  public class MultiClassClassifierUpdateable<T> : BaseClassifier<T>
  {
    public MultiClassClassifierUpdateable(Runtime<T> rt) : base(rt, new MultiClassClassifierUpdateable()) {}

    /// <summary>
    /// Sets the width multiplier when using random codes. The number of codes
    /// generated will be thus number multiplied by the number of classes.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> RandomWidthFactor (double value) {
      ((MultiClassClassifierUpdateable)impl).setRandomWidthFactor(value);
      return this;
    }

    /// <summary>
    /// Use pairwise coupling (only has an effect for 1-against-1).
    /// </summary>    
    public MultiClassClassifierUpdateable<T> UsePairwiseCoupling (bool value) {
      ((MultiClassClassifierUpdateable)impl).setUsePairwiseCoupling(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Seed (int value) {
      ((MultiClassClassifierUpdateable)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Debug (bool value) {
      ((MultiClassClassifierUpdateable)impl).setDebug(value);
      return this;
    }

        
  }
}