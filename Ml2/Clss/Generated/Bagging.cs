using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for bagging a classifier to reduce variance. Can do classification
  /// and regression depending on the base learner. <br/><br/>For more
  /// information, see<br/><br/>Leo Breiman (1996). Bagging predictors. Machine Learning.
  /// 24(2):123-140.<br/><br/>Options:<br/><br/>-P = 	Size of each bag, as a
  /// percentage of the<br/>	training set size. (default 100)<br/>-O = 	Calculate the
  /// out of bag error.<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
  /// 1)<br/>-num-slots &lt;num&gt; = 	Number of execution slots.<br/>	(default 1
  /// - i.e. no parallelism)<br/>-I &lt;num&gt; = 	Number of
  /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may
  /// output additional info to the console<br/>-W = 	Full name of base
  /// classifier.<br/>	(default: weka.classifiers.trees.REPTree)<br/><br/>Options specific
  /// to classifier weka.classifiers.trees.REPTree: = <br/>-M &lt;minimum number
  /// of instances&gt; = 	Set minimum number of instances per leaf (default
  /// 2).<br/>-V &lt;minimum variance for split&gt; = 	Set minimum numeric class
  /// variance proportion<br/>	of train variance for split (default 1e-3).<br/>-N
  /// &lt;number of folds&gt; = 	Number of folds for reduced error pruning (default
  /// 3).<br/>-S &lt;seed&gt; = 	Seed for random data shuffling (default 1).<br/>-P
  /// = 	No pruning.<br/>-L = 	Maximum tree depth (default -1, no
  /// maximum)<br/>-I = 	Initial class value count (default 0)<br/>-R = 	Spread initial count
  /// over all class values (i.e. don't use 1 per value)
  /// </summary>
  public class Bagging<T> : BaseClassifier<T, Bagging> where T : new()
  {
    public Bagging(Runtime<T> rt) : base(rt, new Bagging()) {}

    /// <summary>
    /// Size of each bag, as a percentage of the training set size.
    /// </summary>    
    public Bagging<T> BagSizePercent (int newBagSizePercent) {
      ((Bagging)Impl).setBagSizePercent(newBagSizePercent);
      return this;
    }

    /// <summary>
    /// Whether the out-of-bag error is calculated.
    /// </summary>    
    public Bagging<T> CalcOutOfBag (bool calcOutOfBag) {
      ((Bagging)Impl).setCalcOutOfBag(calcOutOfBag);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public Bagging<T> Seed (int seed) {
      throw new System.NotSupportedException("Seeds are handled internally by the system for reproducability.")
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public Bagging<T> NumExecutionSlots (int numSlots) {
      ((Bagging)Impl).setNumExecutionSlots(numSlots);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public Bagging<T> NumIterations (int numIterations) {
      ((Bagging)Impl).setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public Bagging<T> Classifier (weka.classifiers.Classifier newClassifier) {
      ((Bagging)Impl).setClassifier(newClassifier);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Bagging<T> Debug (bool debug) {
      ((Bagging)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}