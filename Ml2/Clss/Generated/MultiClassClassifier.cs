using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// A metaclassifier for handling multi-class datasets with 2-class
  /// classifiers. This classifier is also capable of applying error correcting output
  /// codes for increased accuracy.
  /// </summary>
  public class MultiClassClassifier<T> : BaseClassifier<T>
  {
    public MultiClassClassifier(Runtime<T> rt) : base(rt, new MultiClassClassifier()) {}

    /// <summary>
    /// Sets the width multiplier when using random codes. The number of codes
    /// generated will be thus number multiplied by the number of classes.
    /// </summary>    
    public MultiClassClassifier<T> RandomWidthFactor (double value) {
      ((MultiClassClassifier)impl).setRandomWidthFactor(value);
      return this;
    }

    /// <summary>
    /// Use pairwise coupling (only has an effect for 1-against-1).
    /// </summary>    
    public MultiClassClassifier<T> UsePairwiseCoupling (bool value) {
      ((MultiClassClassifier)impl).setUsePairwiseCoupling(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public MultiClassClassifier<T> Seed (int value) {
      ((MultiClassClassifier)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultiClassClassifier<T> Debug (bool value) {
      ((MultiClassClassifier)impl).setDebug(value);
      return this;
    }

        
  }
}