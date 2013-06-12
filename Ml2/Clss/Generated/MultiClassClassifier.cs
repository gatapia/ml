using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
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
    /// Sets the method to use for transforming the multi-class problem into
    /// several 2-class ones.
    /// </summary>    
    public MultiClassClassifier<T> Method (EMethod newMethod) {
      ((MultiClassClassifier)Impl).setMethod(new weka.core.SelectedTag((int) newMethod, MultiClassClassifier.TAGS_METHOD));
      return this;
    }

    /// <summary>
    /// Sets the width multiplier when using random codes. The number of codes
    /// generated will be thus number multiplied by the number of classes.
    /// </summary>    
    public MultiClassClassifier<T> RandomWidthFactor (double newRandomWidthFactor) {
      ((MultiClassClassifier)Impl).setRandomWidthFactor(newRandomWidthFactor);
      return this;
    }

    /// <summary>
    /// Use pairwise coupling (only has an effect for 1-against-1).
    /// </summary>    
    public MultiClassClassifier<T> UsePairwiseCoupling (bool p) {
      ((MultiClassClassifier)Impl).setUsePairwiseCoupling(p);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public MultiClassClassifier<T> Seed (int seed) {
      ((MultiClassClassifier)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public MultiClassClassifier<T> Classifier (Clss.BaseClassifier<T> newClassifier) {
      ((MultiClassClassifier)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultiClassClassifier<T> Debug (bool debug) {
      ((MultiClassClassifier)Impl).setDebug(debug);
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