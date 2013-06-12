using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Simple EM (expectation maximisation) class. EM assigns a probability
  /// distribution to each instance which indicates the probability of it belonging
  /// to each of the clusters. EM can decide how many clusters to create by cross
  /// validation, or you may specify apriori how many clusters to generate. The
  /// cross validation performed to determine the number of clusters is done in
  /// the following steps: 1. the number of clusters is set to 1 2. the training
  /// set is split randomly into 10 folds. 3. EM is performed 10 times using the 10
  /// folds the usual CV way. 4. the loglikelihood is averaged over all 10
  /// results. 5. if loglikelihood has increased the number of clusters is increased
  /// by 1 and the program continues at step 2. The number of folds is fixed to
  /// 10, as long as the number of instances in the training set is not smaller 10.
  /// If this is the case the number of folds is set equal to the number of
  /// instances.
  /// </summary>
  public class EM<T> : BaseClusterer<T>
  {    
    public EM(Runtime<T> rt) : base(rt, new EM()) {}

    /// <summary>
    /// If set to true, clusterer may output additional info to the console.
    /// </summary>    
    public EM<T> Debug (bool v) {
      ((EM)Impl).setDebug(v);
      return this;
    }

    /// <summary>
    /// maximum number of iterations
    /// </summary>    
    public EM<T> MaxIterations (int i) {
      ((EM)Impl).setMaxIterations(i);
      return this;
    }

    /// <summary>
    /// The number of folds to use when cross-validating to find the best number
    /// of clusters (default = 10)
    /// </summary>    
    public EM<T> NumFolds (int folds) {
      ((EM)Impl).setNumFolds(folds);
      return this;
    }

    /// <summary>
    /// The minimum improvement in log likelihood required to perform another
    /// iteration of the E and M steps
    /// </summary>    
    public EM<T> MinLogLikelihoodImprovementIterating (double min) {
      ((EM)Impl).setMinLogLikelihoodImprovementIterating(min);
      return this;
    }

    /// <summary>
    /// The minimum improvement in cross-validated log likelihood required in
    /// order to consider increasing the number of clusters when cross-validiting to
    /// find the best number of clusters
    /// </summary>    
    public EM<T> MinLogLikelihoodImprovementCV (double min) {
      ((EM)Impl).setMinLogLikelihoodImprovementCV(min);
      return this;
    }

    /// <summary>
    /// set number of clusters. -1 to select number of clusters automatically by
    /// cross validation.
    /// </summary>    
    public EM<T> NumClusters (int n) {
      ((EM)Impl).setNumClusters(n);
      return this;
    }

    /// <summary>
    /// The maximum number of clusters to consider during cross-validation to
    /// select the best number of clusters
    /// </summary>    
    public EM<T> MaximumNumberOfClusters (int n) {
      ((EM)Impl).setMaximumNumberOfClusters(n);
      return this;
    }

    /// <summary>
    /// set minimum allowable standard deviation
    /// </summary>    
    public EM<T> MinStdDev (double m) {
      ((EM)Impl).setMinStdDev(m);
      return this;
    }

    /// <summary>
    /// Use old format for model output. The old format is better when there are
    /// many clusters. The new format is better when there are fewer clusters and
    /// many attributes.
    /// </summary>    
    public EM<T> DisplayModelInOldFormat (bool d) {
      ((EM)Impl).setDisplayModelInOldFormat(d);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use. Set equal to the number
    /// of available cpu/cores
    /// </summary>    
    public EM<T> NumExecutionSlots (int slots) {
      ((EM)Impl).setNumExecutionSlots(slots);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EM<T> MinStdDevPerAtt (double[] m) {
      ((EM)Impl).setMinStdDevPerAtt(m);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public EM<T> Seed (int value) {
      ((EM)Impl).setSeed(value);
      return this;
    }

            

        
  }
}