using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a 1R classifier; in other words, uses the
  /// minimum-error attribute for prediction, discretizing numeric attributes. For
  /// more information, see: R.C. Holte (1993). Very simple classification rules
  /// perform well on most commonly used datasets. Machine Learning. 11:63-91.
  /// </summary>
  public class OneR<T> : BaseClassifier<T>
  {
    public OneR(Runtime<T> rt) : base(rt, new OneR()) {}

    /// <summary>
    /// The minimum bucket size used for discretizing numeric attributes.
    /// </summary>    
    public OneR<T> MinBucketSize (int value) {
      ((OneR)impl).setMinBucketSize(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public OneR<T> Debug (bool value) {
      ((OneR)impl).setDebug(value);
      return this;
    }

        
  }
}