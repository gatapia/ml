using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for selecting a classifier from among several using cross
  /// validation on the training data or the performance on the training data. Performance
  /// is measured based on percent correct (classification) or mean-squared
  /// error (regression).<br/><br/>Options:<br/><br/>-X &lt;number of folds&gt; =
  /// 	Use cross validation for model selection using the<br/>	given number of
  /// folds. (default 0, is to<br/>	use training error)<br/>-S &lt;num&gt; = 	Random
  /// number seed.<br/>	(default 1)<br/>-B &lt;classifier specification&gt; =
  /// 	Full class name of classifier to include, followed<br/>	by scheme options. May
  /// be specified multiple times.<br/>	(default:
  /// "weka.classifiers.rules.ZeroR")<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console
  /// </summary>
  public class MultiScheme<T> : BaseClassifier<T, MultiScheme> where T : new()
  {
    public MultiScheme(Runtime<T> rt) : base(rt, new MultiScheme()) {}

    /// <summary>
    /// The number of folds used for cross-validation (if 0, performance on
    /// training data will be used).
    /// </summary>    
    public MultiScheme<T> NumFolds (int numFolds) {
      ((MultiScheme)Impl).setNumFolds(numFolds);
      return this;
    }

    /// <summary>
    /// The classifiers to be chosen from.
    /// </summary>    
    public MultiScheme<T> Classifiers (weka.classifiers.Classifier[] classifiers) {
      ((MultiScheme)Impl).setClassifiers(classifiers);
      return this;
    }

    /// <summary>
    /// Whether debug information is output to console.
    /// </summary>    
    public MultiScheme<T> Debug (bool debug) {
      ((MultiScheme)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}