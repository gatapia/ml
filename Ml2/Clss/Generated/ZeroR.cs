using System.Linq;
using weka.classifiers.rules;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a 0-R classifier. Predicts the mean (for a
  /// numeric class) or the mode (for a nominal class).
  /// </summary>
  public class ZeroR<T> : BaseClassifier<T, ZeroR>
  {
    public ZeroR(Runtime<T> rt) : base(rt, new ZeroR()) {}

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public ZeroR<T> Debug (bool debug) {
      ((ZeroR)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}