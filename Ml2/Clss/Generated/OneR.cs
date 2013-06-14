using System.Linq;
using weka.classifiers.rules;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a 1R classifier; in other words, uses the
  /// minimum-error attribute for prediction, discretizing numeric attributes. For
  /// more information, see:<br/><br/>R.C. Holte (1993). Very simple
  /// classification rules perform well on most commonly used datasets. Machine Learning.
  /// 11:63-91.<br/><br/>Options:<br/><br/>-B &lt;minimum bucket size&gt; = 	The
  /// minimum number of objects in a bucket (default: 6).
  /// </summary>
  public class OneR<T> : BaseClassifier<T, OneR> where T : new()
  {
    public OneR(Runtime<T> rt) : base(rt, new OneR()) {}

    /// <summary>
    /// The minimum bucket size used for discretizing numeric attributes.
    /// </summary>    
    public OneR<T> MinBucketSize (int v) {
      ((OneR)Impl).setMinBucketSize(v);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public OneR<T> Debug (bool debug) {
      ((OneR)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}