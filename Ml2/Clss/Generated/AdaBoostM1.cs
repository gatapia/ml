using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for boosting a nominal class classifier using the Adaboost M1
  /// method. Only nominal class problems can be tackled. Often dramatically improves
  /// performance, but sometimes overfits. For more information, see Yoav Freund,
  /// Robert E. Schapire: Experiments with a new boosting algorithm. In:
  /// Thirteenth International Conference on Machine Learning, San Francisco, 148-156,
  /// 1996.
  /// </summary>
  public class AdaBoostM1<T> : BaseClassifier<T>
  {
    public AdaBoostM1(Runtime<T> rt) : base(rt, new AdaBoostM1()) {}

    /// <summary>
    /// Weight threshold for weight pruning.
    /// </summary>    
    public AdaBoostM1<T> WeightThreshold (int value) {
      ((AdaBoostM1)impl).setWeightThreshold(value);
      return this;
    }

    /// <summary>
    /// Whether resampling is used instead of reweighting.
    /// </summary>    
    public AdaBoostM1<T> UseResampling (bool value) {
      ((AdaBoostM1)impl).setUseResampling(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public AdaBoostM1<T> Seed (int value) {
      ((AdaBoostM1)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public AdaBoostM1<T> NumIterations (int value) {
      ((AdaBoostM1)impl).setNumIterations(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AdaBoostM1<T> Debug (bool value) {
      ((AdaBoostM1)impl).setDebug(value);
      return this;
    }

        
  }
}