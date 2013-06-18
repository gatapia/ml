using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for boosting a nominal class classifier using the Adaboost M1
  /// method. Only nominal class problems can be tackled. Often dramatically improves
  /// performance, but sometimes overfits.<br/><br/>For more information,
  /// see<br/><br/>Yoav Freund, Robert E. Schapire: Experiments with a new boosting
  /// algorithm. In: Thirteenth International Conference on Machine Learning, San
  /// Francisco, 148-156, 1996.<br/><br/>Options:<br/><br/>-P &lt;num&gt; =
  /// 	Percentage of weight mass to base training on.<br/>	(default 100, reduce to around
  /// 90 speed up)<br/>-Q = 	Use resampling for boosting.<br/>-S &lt;num&gt; =
  /// 	Random number seed.<br/>	(default 1)<br/>-I &lt;num&gt; = 	Number of
  /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console<br/>-W = 	Full name of
  /// base classifier.<br/>	(default:
  /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier weka.classifiers.trees.DecisionStump: =
  /// <br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console
  /// </summary>
  public class AdaBoostM1<T> : BaseClassifier<T, AdaBoostM1> where T : new()
  {
    public AdaBoostM1(Runtime<T> rt) : base(rt, new AdaBoostM1()) {}

    /// <summary>
    /// Weight threshold for weight pruning.
    /// </summary>    
    public AdaBoostM1<T> WeightThreshold (int threshold) {
      ((AdaBoostM1)Impl).setWeightThreshold(threshold);
      return this;
    }

    /// <summary>
    /// Whether resampling is used instead of reweighting.
    /// </summary>    
    public AdaBoostM1<T> UseResampling (bool r) {
      ((AdaBoostM1)Impl).setUseResampling(r);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public AdaBoostM1<T> Seed (int seed) {
      throw new System.NotSupportedException("Seeds are handled internally by the system for reproducability.")
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public AdaBoostM1<T> NumIterations (int numIterations) {
      ((AdaBoostM1)Impl).setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public AdaBoostM1<T> Classifier (Clss.IBaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((AdaBoostM1)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AdaBoostM1<T> Debug (bool debug) {
      ((AdaBoostM1)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}