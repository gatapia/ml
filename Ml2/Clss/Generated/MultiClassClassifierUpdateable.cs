using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A metaclassifier for handling multi-class datasets with 2-class
  /// classifiers. This classifier is also capable of applying error correcting output
  /// codes for increased accuracy. The base classifier must be an updateable
  /// classifier
  /// </summary>
  public class MultiClassClassifierUpdateable<T> : BaseClassifier<T, MultiClassClassifierUpdateable> where T : new()
  {
    public MultiClassClassifierUpdateable(Runtime<T> rt) : base(rt, new MultiClassClassifierUpdateable()) {}

    /// <summary>
    /// Sets the method to use for transforming the multi-class problem into
    /// several 2-class ones.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Method (EMethod newMethod) {
      ((MultiClassClassifierUpdateable)Impl).setMethod(new weka.core.SelectedTag((int) newMethod, MultiClassClassifierUpdateable.TAGS_METHOD));
      return this;
    }

    /// <summary>
    /// Sets the width multiplier when using random codes. The number of codes
    /// generated will be thus number multiplied by the number of classes.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> RandomWidthFactor (double newRandomWidthFactor) {
      ((MultiClassClassifierUpdateable)Impl).setRandomWidthFactor(newRandomWidthFactor);
      return this;
    }

    /// <summary>
    /// Use pairwise coupling (only has an effect for 1-against-1).
    /// </summary>    
    public MultiClassClassifierUpdateable<T> UsePairwiseCoupling (bool p) {
      ((MultiClassClassifierUpdateable)Impl).setUsePairwiseCoupling(p);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Seed (int seed) {
      ((MultiClassClassifierUpdateable)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((MultiClassClassifierUpdateable)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultiClassClassifierUpdateable<T> Debug (bool debug) {
      ((MultiClassClassifierUpdateable)Impl).setDebug(debug);
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