using weka.core;
using weka.classifiers.rules;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for generating a PART decision list. Uses separate-and-conquer.
  /// Builds a partial C4.5 decision tree in each iteration and makes the "best"
  /// leaf into a rule. For more information, see: Eibe Frank, Ian H. Witten:
  /// Generating Accurate Rule Sets Without Global Optimization. In: Fifteenth
  /// International Conference on Machine Learning, 144-151, 1998.
  /// </summary>
  public class PART<T> : BaseClassifier<T>
  {
    public PART(Runtime<T> rt) : base(rt, new PART()) {}

    /// <summary>
    /// The minimum number of instances per rule.
    /// </summary>    
    public PART<T> MinNumObj (int value) {
      ((PART)impl).setMinNumObj(value);
      return this;
    }

    /// <summary>
    /// Whether reduced-error pruning is used instead of C.4.5 pruning.
    /// </summary>    
    public PART<T> ReducedErrorPruning (bool value) {
      ((PART)impl).setReducedErrorPruning(value);
      return this;
    }

    /// <summary>
    /// Whether pruning is performed.
    /// </summary>    
    public PART<T> Unpruned (bool value) {
      ((PART)impl).setUnpruned(value);
      return this;
    }

    /// <summary>
    /// Whether MDL correction is used when finding splits on numeric attributes.
    /// </summary>    
    public PART<T> UseMDLcorrection (bool value) {
      ((PART)impl).setUseMDLcorrection(value);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for reduced-error pruning. One fold is
    /// used for pruning, the rest for growing the rules.
    /// </summary>    
    public PART<T> NumFolds (int value) {
      ((PART)impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// The seed used for randomizing the data when reduced-error pruning is
    /// used.
    /// </summary>    
    public PART<T> Seed (int value) {
      ((PART)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// Whether to use binary splits on nominal attributes when building the
    /// partial trees.
    /// </summary>    
    public PART<T> BinarySplits (bool value) {
      ((PART)impl).setBinarySplits(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public PART<T> Debug (bool value) {
      ((PART)impl).setDebug(value);
      return this;
    }

        
        
  }
}