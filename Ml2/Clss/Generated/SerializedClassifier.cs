using System.Linq;
using weka.classifiers.misc;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A wrapper around a serialized classifier model. This classifier loads a
  /// serialized models and uses it to make predictions.<br/><br/>Warning: since
  /// the serialized model doesn't get changed, cross-validation cannot bet used
  /// with this classifier.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is
  /// run in debug mode and<br/>	may output additional info to the
  /// console<br/>-model &lt;filename&gt; = 	The file containing the serialized
  /// model.<br/>	(required)
  /// </summary>
  public class SerializedClassifier<T> : BaseClassifier<T, SerializedClassifier> where T : new()
  {
    public SerializedClassifier(Runtime<T> rt) : base(rt, new SerializedClassifier()) {}

    /// <summary>
    /// 
    /// </summary>    
    public SerializedClassifier<T> Model (Clss.IBaseClassifier<T, weka.classifiers.Classifier> value) {
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