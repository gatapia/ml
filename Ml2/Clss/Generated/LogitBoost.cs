using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for performing additive logistic regression. <br/>This class
  /// performs classification using a regression scheme as the base learner, and can
  /// handle multi-class problems. For more information, see<br/><br/>J. Friedman,
  /// T. Hastie, R. Tibshirani (1998). Additive Logistic Regression: a
  /// Statistical View of Boosting. Stanford University.<br/><br/>Can do efficient internal
  /// cross-validation to determine appropriate number of
  /// iterations.<br/><br/>Options:<br/><br/>-Q = 	Use resampling instead of reweighting for
  /// boosting.<br/>-P &lt;percent&gt; = 	Percentage of weight mass to base training
  /// on.<br/>	(default 100, reduce to around 90 speed up)<br/>-F &lt;num&gt; = 	Number
  /// of folds for internal cross-validation.<br/>	(default 0 -- no
  /// cross-validation)<br/>-R &lt;num&gt; = 	Number of runs for internal
  /// cross-validation.<br/>	(default 1)<br/>-L &lt;num&gt; = 	Threshold on the improvement of the
  /// likelihood.<br/>	(default -Double.MAX_VALUE)<br/>-H &lt;num&gt; = 	Shrinkage
  /// parameter.<br/>	(default 1)<br/>-S &lt;num&gt; = 	Random number
  /// seed.<br/>	(default 1)<br/>-I &lt;num&gt; = 	Number of iterations.<br/>	(default
  /// 10)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console<br/>-W = 	Full name of base
  /// classifier.<br/>	(default: weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to
  /// classifier weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the console
  /// </summary>
  public class LogitBoost<T> : BaseClassifier<T, LogitBoost> where T : new()
  {
    public LogitBoost(Runtime<T> rt) : base(rt, new LogitBoost()) {}

    /// <summary>
    /// Number of folds for internal cross-validation (default 0 means no
    /// cross-validation is performed).
    /// </summary>    
    public LogitBoost<T> NumFolds (int newNumFolds) {
      ((LogitBoost)Impl).setNumFolds(newNumFolds);
      return this;
    }

    /// <summary>
    /// Number of runs for internal cross-validation.
    /// </summary>    
    public LogitBoost<T> NumRuns (int newNumRuns) {
      ((LogitBoost)Impl).setNumRuns(newNumRuns);
      return this;
    }

    /// <summary>
    /// Weight threshold for weight pruning (reduce to 90 for speeding up
    /// learning process).
    /// </summary>    
    public LogitBoost<T> WeightThreshold (int threshold) {
      ((LogitBoost)Impl).setWeightThreshold(threshold);
      return this;
    }

    /// <summary>
    /// Threshold on improvement in likelihood.
    /// </summary>    
    public LogitBoost<T> LikelihoodThreshold (double newPrecision) {
      ((LogitBoost)Impl).setLikelihoodThreshold(newPrecision);
      return this;
    }

    /// <summary>
    /// Shrinkage parameter (use small value like 0.1 to reduce overfitting).
    /// </summary>    
    public LogitBoost<T> Shrinkage (double newShrinkage) {
      ((LogitBoost)Impl).setShrinkage(newShrinkage);
      return this;
    }

    /// <summary>
    /// Whether resampling is used instead of reweighting.
    /// </summary>    
    public LogitBoost<T> UseResampling (bool r) {
      ((LogitBoost)Impl).setUseResampling(r);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public LogitBoost<T> Seed (int seed) {
      throw new System.NotSupportedException("Seeds are handled internally by the system for reproducability.")
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public LogitBoost<T> NumIterations (int numIterations) {
      ((LogitBoost)Impl).setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public LogitBoost<T> Classifier (weka.classifiers.Classifier newClassifier) {
      ((LogitBoost)Impl).setClassifier(newClassifier);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LogitBoost<T> Debug (bool debug) {
      ((LogitBoost)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}