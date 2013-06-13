using System.Linq;
using weka.classifiers.lazy;

// ReSharper disable once CheckNamespace
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
  public class LWL<T> : BaseClassifier<T, LWL>
  {
    public LWL(Runtime<T> rt) : base(rt, new LWL()) {}

    /// <summary>
    /// 
    /// </summary>    
    public LWL<T> KNN (int knn) {
      ((LWL)Impl).setKNN(knn);
      return this;
    }

    /// <summary>
    /// Determines weighting function. [0 = Linear, 1 = Epnechnikov,2 = Tricube,
    /// 3 = Inverse, 4 = Gaussian and 5 = Constant. (default 0 = Linear)].
    /// </summary>    
    public LWL<T> WeightingKernel (int kernel) {
      ((LWL)Impl).setWeightingKernel(kernel);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public LWL<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((LWL)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LWL<T> Debug (bool debug) {
      ((LWL)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}