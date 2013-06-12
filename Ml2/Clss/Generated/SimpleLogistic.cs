using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Classifier for building linear logistic regression models. LogitBoost
  /// with simple regression functions as base learners is used for fitting the
  /// logistic models. The optimal number of LogitBoost iterations to perform is
  /// cross-validated, which leads to automatic attribute selection. For more
  /// information see: Niels Landwehr, Mark Hall, Eibe Frank (2005). Logistic Model
  /// Trees. Marc Sumner, Eibe Frank, Mark Hall: Speeding up Logistic Model Tree
  /// Induction. In: 9th European Conference on Principles and Practice of Knowledge
  /// Discovery in Databases, 675-683, 2005.
  /// </summary>
  public class SimpleLogistic<T> : BaseClassifier<T>
  {
    public SimpleLogistic(Runtime<T> rt) : base(rt, new SimpleLogistic()) {}

    /// <summary>
    /// Set fixed number of iterations for LogitBoost. If >= 0, this sets the
    /// number of LogitBoost iterations to perform. If < 0, the number is
    /// cross-validated or a stopping criterion on the training set is used (depending on the
    /// value of useCrossValidation).
    /// </summary>    
    public SimpleLogistic<T> NumBoostingIterations (int n) {
      ((SimpleLogistic)Impl).setNumBoostingIterations(n);
      return this;
    }

    /// <summary>
    /// Sets whether the number of LogitBoost iterations is to be cross-validated
    /// or the stopping criterion on the training set should be used. If not set
    /// (and no fixed number of iterations was given), the number of LogitBoost
    /// iterations is used that minimizes the error on the training set
    /// (misclassification error or error on probabilities depending on errorOnProbabilities).
    /// </summary>    
    public SimpleLogistic<T> UseCrossValidation (bool l) {
      ((SimpleLogistic)Impl).setUseCrossValidation(l);
      return this;
    }

    /// <summary>
    /// Use error on the probabilties as error measure when determining the best
    /// number of LogitBoost iterations. If set, the number of LogitBoost
    /// iterations is chosen that minimizes the root mean squared error (either on the
    /// training set or in the cross-validation, depending on useCrossValidation).
    /// </summary>    
    public SimpleLogistic<T> ErrorOnProbabilities (bool l) {
      ((SimpleLogistic)Impl).setErrorOnProbabilities(l);
      return this;
    }

    /// <summary>
    /// Sets the maximum number of iterations for LogitBoost. Default value is
    /// 500, for very small/large datasets a lower/higher value might be preferable.
    /// </summary>    
    public SimpleLogistic<T> MaxBoostingIterations (int n) {
      ((SimpleLogistic)Impl).setMaxBoostingIterations(n);
      return this;
    }

    /// <summary>
    /// If heuristicStop > 0, the heuristic for greedy stopping while
    /// cross-validating the number of LogitBoost iterations is enabled. This means LogitBoost
    /// is stopped if no new error minimum has been reached in the last
    /// heuristicStop iterations. It is recommended to use this heuristic, it gives a large
    /// speed-up especially on small datasets. The default value is 50.
    /// </summary>    
    public SimpleLogistic<T> HeuristicStop (int n) {
      ((SimpleLogistic)Impl).setHeuristicStop(n);
      return this;
    }

    /// <summary>
    /// Set the beta value used for weight trimming in LogitBoost. Only instances
    /// carrying (1 - beta)% of the weight from previous iteration are used in the
    /// next iteration. Set to 0 for no weight trimming. The default value is 0.
    /// </summary>    
    public SimpleLogistic<T> WeightTrimBeta (double n) {
      ((SimpleLogistic)Impl).setWeightTrimBeta(n);
      return this;
    }

    /// <summary>
    /// The AIC is used to determine when to stop LogitBoost iterations (instead
    /// of cross-validation or training error).
    /// </summary>    
    public SimpleLogistic<T> UseAIC (bool c) {
      ((SimpleLogistic)Impl).setUseAIC(c);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SimpleLogistic<T> Debug (bool debug) {
      ((SimpleLogistic)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}