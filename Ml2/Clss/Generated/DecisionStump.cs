using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a decision stump. Usually used in
  /// conjunction with a boosting algorithm. Does regression (based on mean-squared error)
  /// or classification (based on entropy). Missing is treated as a separate
  /// value.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console
  /// </summary>
  public class DecisionStump<T> : BaseClassifier<T, DecisionStump> where T : new()
  {
    public DecisionStump(Runtime<T> rt) : base(rt, new DecisionStump()) {}

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public DecisionStump<T> Debug (bool debug) {
      ((DecisionStump)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}