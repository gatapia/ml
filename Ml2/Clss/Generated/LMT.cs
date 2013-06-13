using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Classifier for building 'logistic model trees', which are classification
  /// trees with logistic regression functions at the leaves. The algorithm can
  /// deal with binary and multi-class target variables, numeric and nominal
  /// attributes and missing values. For more information see: Niels Landwehr, Mark
  /// Hall, Eibe Frank (2005). Logistic Model Trees. Machine Learning.
  /// 95(1-2):161-205. Marc Sumner, Eibe Frank, Mark Hall: Speeding up Logistic Model Tree
  /// Induction. In: 9th European Conference on Principles and Practice of
  /// Knowledge Discovery in Databases, 675-683, 2005.
  /// </summary>
  public class LMT<T> : BaseClassifier<T, LMT> where T : new()
  {
    public LMT(Runtime<T> rt) : base(rt, new LMT()) {}

    /// <summary>
    /// Convert all nominal attributes to binary ones before building the tree.
    /// This means that all splits in the final tree will be binary.
    /// </summary>    
    public LMT<T> ConvertNominal (bool c) {
      ((LMT)Impl).setConvertNominal(c);
      return this;
    }

    /// <summary>
    /// Set splitting criterion based on the residuals of LogitBoost. There are
    /// two possible splitting criteria for LMT: the default is to use the C4.5
    /// splitting criterion that uses information gain on the class variable. The other
    /// splitting criterion tries to improve the purity in the residuals produces
    /// when fitting the logistic regression functions. The choice of the splitting
    /// criterion does not usually affect classification accuracy much, but can
    /// produce different trees.
    /// </summary>    
    public LMT<T> SplitOnResiduals (bool c) {
      ((LMT)Impl).setSplitOnResiduals(c);
      return this;
    }

    /// <summary>
    /// Use heuristic that avoids cross-validating the number of Logit-Boost
    /// iterations at every node. When fitting the logistic regression functions at a
    /// node, LMT has to determine the number of LogitBoost iterations to run.
    /// Originally, this number was cross-validated at every node in the tree. To save
    /// time, this heuristic cross-validates the number only once and then uses that
    /// number at every node in the tree. Usually this does not decrease accuracy
    /// but improves runtime considerably.
    /// </summary>    
    public LMT<T> FastRegression (bool c) {
      ((LMT)Impl).setFastRegression(c);
      return this;
    }

    /// <summary>
    /// Minimize error on probabilities instead of misclassification error when
    /// cross-validating the number of LogitBoost iterations. When set, the number
    /// of LogitBoost iterations is chosen that minimizes the root mean squared
    /// error instead of the misclassification error.
    /// </summary>    
    public LMT<T> ErrorOnProbabilities (bool c) {
      ((LMT)Impl).setErrorOnProbabilities(c);
      return this;
    }

    /// <summary>
    /// Set a fixed number of iterations for LogitBoost. If >= 0, this sets a
    /// fixed number of LogitBoost iterations that is used everywhere in the tree. If
    /// < 0, the number is cross-validated.
    /// </summary>    
    public LMT<T> NumBoostingIterations (int c) {
      ((LMT)Impl).setNumBoostingIterations(c);
      return this;
    }

    /// <summary>
    /// Set the minimum number of instances at which a node is considered for
    /// splitting. The default value is 15.
    /// </summary>    
    public LMT<T> MinNumInstances (int c) {
      ((LMT)Impl).setMinNumInstances(c);
      return this;
    }

    /// <summary>
    /// Set the beta value used for weight trimming in LogitBoost. Only instances
    /// carrying (1 - beta)% of the weight from previous iteration are used in the
    /// next iteration. Set to 0 for no weight trimming. The default value is 0.
    /// </summary>    
    public LMT<T> WeightTrimBeta (double n) {
      ((LMT)Impl).setWeightTrimBeta(n);
      return this;
    }

    /// <summary>
    /// The AIC is used to determine when to stop LogitBoost iterations. The
    /// default is not to use AIC.
    /// </summary>    
    public LMT<T> UseAIC (bool c) {
      ((LMT)Impl).setUseAIC(c);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LMT<T> Debug (bool debug) {
      ((LMT)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}