using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building an ensemble of randomizable base classifiers. Each
  /// base classifiers is built using a different random number seed (but based one
  /// the same data). The final prediction is a straight average of the
  /// predictions generated by the individual base
  /// classifiers.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-num-slots
  /// &lt;num&gt; = 	Number of execution slots.<br/>	(default 1 - i.e. no
  /// parallelism)<br/>-I &lt;num&gt; = 	Number of iterations.<br/>	(default 10)<br/>-D =
  /// 	If set, classifier is run in debug mode and<br/>	may output additional info
  /// to the console<br/>-W = 	Full name of base classifier.<br/>	(default:
  /// weka.classifiers.trees.RandomTree)<br/><br/>Options specific to classifier
  /// weka.classifiers.trees.RandomTree: = <br/>-K &lt;number of attributes&gt; =
  /// 	Number of attributes to randomly investigate<br/>	(<0 =
  /// int(log_2(#attributes)+1)).<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
  /// instances per leaf.<br/>-S &lt;num&gt; = 	Seed for random number
  /// generator.<br/>	(default 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the tree, 0
  /// for unlimited.<br/>	(default 0)<br/>-N &lt;num&gt; = 	Number of folds for
  /// backfitting (default 0, no backfitting).<br/>-U = 	Allow unclassified
  /// instances.<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console
  /// </summary>
  public class RandomCommittee<T> : BaseClassifier<T, RandomCommittee> where T : new()
  {
    public RandomCommittee(Runtime<T> rt) : base(rt, new RandomCommittee()) {}

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public RandomCommittee<T> Seed (int seed) {
      ((RandomCommittee)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public RandomCommittee<T> NumExecutionSlots (int numSlots) {
      ((RandomCommittee)Impl).setNumExecutionSlots(numSlots);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public RandomCommittee<T> NumIterations (int numIterations) {
      ((RandomCommittee)Impl).setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public RandomCommittee<T> Classifier (weka.classifiers.Classifier newClassifier) {
      ((RandomCommittee)Impl).setClassifier(newClassifier);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomCommittee<T> Debug (bool debug) {
      ((RandomCommittee)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}