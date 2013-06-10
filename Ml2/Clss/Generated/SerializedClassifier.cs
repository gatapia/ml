using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// A wrapper around a serialized classifier model. This classifier loads a
  /// serialized models and uses it to make predictions. Warning: since the
  /// serialized model doesn't get changed, cross-validation cannot bet used with this
  /// classifier.
  /// </summary>
  public class SerializedClassifier<T> : BaseClassifier<T>
  {
    public SerializedClassifier(Runtime<T> rt) : base(rt, new SerializedClassifier()) {}

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SerializedClassifier<T> Debug (bool value) {
      ((SerializedClassifier)impl).setDebug(value);
      return this;
    }

        
  }
}