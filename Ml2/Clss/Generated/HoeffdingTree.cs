using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A Hoeffding tree (VFDT) is an incremental, anytime decision tree
  /// induction algorithm that is capable of learning from massive data streams, assuming
  /// that the distribution generating examples does not change over time.
  /// Hoeffding trees exploit the fact that a small sample can often be enough to
  /// choose an optimal splitting attribute. This idea is supported mathematically by
  /// the Hoeffding bound, which quantifies the number of observations (in our
  /// case, examples) needed to estimate some statistics within a prescribed
  /// precision (in our case, the goodness of an attribute). A theoretically appealing
  /// feature of Hoeffding Trees not shared by otherincremental decision tree
  /// learners is that it has sound guarantees of performance. Using the Hoeffding
  /// bound one can show that its output is asymptotically nearly identical to
  /// that of a non-incremental learner using infinitely many examples. For more
  /// information see: Geoff Hulten, Laurie Spencer, Pedro Domingos: Mining
  /// time-changing data streams. In: ACM SIGKDD Intl. Conf. on Knowledge Discovery and
  /// Data Mining, 97-106, 2001.
  /// </summary>
  public class HoeffdingTree<T> : BaseClassifier<T, HoeffdingTree> where T : new()
  {
    public HoeffdingTree(Runtime<T> rt) : base(rt, new HoeffdingTree()) {}

    /// <summary>
    /// The allowable error in a split decision. Values closer to zero will take
    /// longer to decide.
    /// </summary>    
    public HoeffdingTree<T> SplitConfidence (double sc) {
      ((HoeffdingTree)Impl).setSplitConfidence(sc);
      return this;
    }

    /// <summary>
    /// Theshold below which a split will be forced to break ties.
    /// </summary>    
    public HoeffdingTree<T> HoeffdingTieThreshold (double ht) {
      ((HoeffdingTree)Impl).setHoeffdingTieThreshold(ht);
      return this;
    }

    /// <summary>
    /// Minimum fraction of weight required down at least two branches for info
    /// gain splitting.
    /// </summary>    
    public HoeffdingTree<T> MinimumFractionOfWeightInfoGain (double m) {
      ((HoeffdingTree)Impl).setMinimumFractionOfWeightInfoGain(m);
      return this;
    }

    /// <summary>
    /// Number of instances (or total weight of instances) a leaf should observe
    /// between split attempts.
    /// </summary>    
    public HoeffdingTree<T> GracePeriod (double grace) {
      ((HoeffdingTree)Impl).setGracePeriod(grace);
      return this;
    }

    /// <summary>
    /// The number of instances (weight) a leaf should observe before allowing
    /// naive Bayes (adaptive) to make predictions
    /// </summary>    
    public HoeffdingTree<T> NaiveBayesPredictionThreshold (double n) {
      ((HoeffdingTree)Impl).setNaiveBayesPredictionThreshold(n);
      return this;
    }

    /// <summary>
    /// Print leaf models (naive bayes leaves only)
    /// </summary>    
    public HoeffdingTree<T> PrintLeafModels (bool p) {
      ((HoeffdingTree)Impl).setPrintLeafModels(p);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public HoeffdingTree<T> Debug (bool debug) {
      ((HoeffdingTree)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}