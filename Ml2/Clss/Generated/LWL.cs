using System.Linq;
using weka.classifiers.lazy;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Locally weighted learning. Uses an instance-based algorithm to assign
  /// instance weights which are then used by a specified
  /// WeightedInstancesHandler.<br/>Can do classification (e.g. using naive Bayes) or regression (e.g.
  /// using linear regression).<br/><br/>For more info, see<br/><br/>Eibe Frank, Mark
  /// Hall, Bernhard Pfahringer: Locally Weighted Naive Bayes. In: 19th
  /// Conference in Uncertainty in Artificial Intelligence, 249-256, 2003.<br/><br/>C.
  /// Atkeson, A. Moore, S. Schaal (1996). Locally weighted learning. AI
  /// Review..<br/><br/>Options:<br/><br/>-A = 	The nearest neighbour search algorithm to
  /// use (default: weka.core.neighboursearch.LinearNNSearch).<br/><br/>-K
  /// &lt;number of neighbours&gt; = 	Set the number of neighbours used to set the
  /// kernel bandwidth.<br/>	(default all)<br/>-U &lt;number of weighting method&gt; =
  /// 	Set the weighting kernel shape to use. 0=Linear,
  /// 1=Epanechnikov,<br/>	2=Tricube, 3=Inverse, 4=Gaussian.<br/>	(default 0 = Linear)<br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the
  /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
  /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier
  /// weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set, classifier is run in
  /// debug mode and<br/>	may output additional info to the console
  /// </summary>
  public class LWL<T> : BaseClassifier<T, LWL> where T : new()
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
    public LWL<T> Classifier (weka.classifiers.Classifier newClassifier) {
      ((LWL)Impl).setClassifier(newClassifier);
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