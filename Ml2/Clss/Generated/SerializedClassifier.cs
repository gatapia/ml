using System.Linq;
using weka.classifiers.misc;

// ReSharper disable once CheckNamespace
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
    /// 
    /// </summary>    
    public SerializedClassifier<T> Model (Clss.BaseClassifier<T> value) {
      ((SerializedClassifier)Impl).setModel(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SerializedClassifier<T> Debug (bool debug) {
      ((SerializedClassifier)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}