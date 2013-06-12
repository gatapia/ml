using weka.core;
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
    /// Sets the method to use for transforming the multi-class problem into
    /// several 2-class ones.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Method (EMethod value) {
      ((MultiClassClassifierUpdateable)Impl).setMethod(new SelectedTag((int) value, MultiClassClassifierUpdateable.TAGS_METHOD));
      return this;
    }

    /// <summary>
    /// Sets the width multiplier when using random codes. The number of codes
    /// generated will be thus number multiplied by the number of classes.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> RandomWidthFactor (double value) {
      ((MultiClassClassifierUpdateable)Impl).setRandomWidthFactor(value);
      return this;
    }

    /// <summary>
    /// Use pairwise coupling (only has an effect for 1-against-1).
    /// </summary>    
    public MultiClassClassifierUpdateable<T> UsePairwiseCoupling (bool value) {
      ((MultiClassClassifierUpdateable)Impl).setUsePairwiseCoupling(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Seed (int value) {
      ((MultiClassClassifierUpdateable)Impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Classifier (Clss.BaseClassifier<T> value) {
      ((MultiClassClassifierUpdateable)Impl).setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Debug (bool value) {
      ((MultiClassClassifierUpdateable)Impl).setDebug(value);
      return this;
    }

        
    public enum EMethod {
      one_against_all = 0,
      Random_correction_code = 1,
      Exhaustive_correction_code = 2,
      one_against_one = 3
    }

        
  }
}