using weka.core;
using weka.classifiers.lazy;

namespace Ml2.Clss
{
  /// <summary>
  /// Locally weighted learning. Uses an instance-based algorithm to assign
  /// instance weights which are then used by a specified WeightedInstancesHandler.
  /// Can do classification (e.g. using naive Bayes) or regression (e.g. using
  /// linear regression). For more info, see Eibe Frank, Mark Hall, Bernhard
  /// Pfahringer: Locally Weighted Naive Bayes. In: 19th Conference in Uncertainty in
  /// Artificial Intelligence, 249-256, 2003. C. Atkeson, A. Moore, S. Schaal
  /// (1996). Locally weighted learning. AI Review..
  /// </summary>
  public class LWL<T> : BaseClassifier<T>
  {
    public LWL(Runtime<T> rt) : base(rt, new LWL()) {}

    /// <summary>
    /// 
    /// </summary>    
    public LWL<T> KNN (int value) {
      ((LWL)Impl).setKNN(value);
      return this;
    }

    /// <summary>
    /// Determines weighting function. [0 = Linear, 1 = Epnechnikov,2 = Tricube,
    /// 3 = Inverse, 4 = Gaussian and 5 = Constant. (default 0 = Linear)].
    /// </summary>    
    public LWL<T> WeightingKernel (int value) {
      ((LWL)Impl).setWeightingKernel(value);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public LWL<T> Classifier (Clss.BaseClassifier<T> value) {
      ((LWL)Impl).setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LWL<T> Debug (bool value) {
      ((LWL)Impl).setDebug(value);
      return this;
    }

        
        
  }
}