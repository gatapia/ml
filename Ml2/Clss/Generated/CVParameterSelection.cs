using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for performing parameter selection by cross-validation for any
  /// classifier.<br/><br/>For more information, see:<br/><br/>R. Kohavi (1995).
  /// Wrappers for Performance Enhancement and Oblivious Decision Graphs. Department
  /// of Computer Science, Stanford University.<br/><br/>Options:<br/><br/>-X
  /// &lt;number of folds&gt; = 	Number of folds used for cross validation (default
  /// 10).<br/>-P &lt;classifier parameter&gt; = 	Classifier parameter
  /// options.<br/>	eg: "N 1 5 10" Sets an optimisation parameter for the<br/>	classifier
  /// with name -N, with lower bound 1, upper bound<br/>	5, and 10 optimisation
  /// steps. The upper bound may be the<br/>	character 'A' or 'I' to substitute the
  /// number of<br/>	attributes or instances in the training
  /// data,<br/>	respectively. This parameter may be supplied more than<br/>	once to optimise over
  /// several classifier options<br/>	simultaneously.<br/>-S &lt;num&gt; = 	Random
  /// number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is run in debug
  /// mode and<br/>	may output additional info to the console<br/>-W = 	Full
  /// name of base classifier.<br/>	(default:
  /// weka.classifiers.rules.ZeroR)<br/><br/>Options specific to classifier weka.classifiers.rules.ZeroR: = <br/>-D =
  /// 	If set, classifier is run in debug mode and<br/>	may output additional info
  /// to the console
  /// </summary>
  public class CVParameterSelection<T> : BaseClassifier<T, CVParameterSelection> where T : new()
  {
    public CVParameterSelection(Runtime<T> rt) : base(rt, new CVParameterSelection()) {}

    /// <summary>
    /// Get the number of folds used for cross-validation.
    /// </summary>    
    public CVParameterSelection<T> NumFolds (int numFolds) {
      ((CVParameterSelection)Impl).setNumFolds(numFolds);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public CVParameterSelection<T> Seed (int seed) {
      ((CVParameterSelection)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public CVParameterSelection<T> Classifier (Clss.IBaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((CVParameterSelection)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public CVParameterSelection<T> Debug (bool debug) {
      ((CVParameterSelection)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}