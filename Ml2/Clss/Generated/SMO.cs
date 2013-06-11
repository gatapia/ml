using weka.core;
using weka.classifiers.functions;

namespace Ml2.Clss
{
  /// <summary>
  /// Implements John Platt's sequential minimal optimization algorithm for
  /// training a support vector classifier. This implementation globally replaces
  /// all missing values and transforms nominal attributes into binary ones. It
  /// also normalizes all attributes by default. (In that case the coefficients in
  /// the output are based on the normalized data, not the original data --- this
  /// is important for interpreting the classifier.) Multi-class problems are
  /// solved using pairwise classification (1-vs-1 and if logistic models are built
  /// pairwise coupling according to Hastie and Tibshirani, 1998). To obtain
  /// proper probability estimates, use the option that fits logistic regression
  /// models to the outputs of the support vector machine. In the multi-class case
  /// the predicted probabilities are coupled using Hastie and Tibshirani's
  /// pairwise coupling method. Note: for improved speed normalization should be turned
  /// off when operating on SparseInstances. For more information on the SMO
  /// algorithm, see J. Platt: Fast Training of Support Vector Machines using
  /// Sequential Minimal Optimization. In B. Schoelkopf and C. Burges and A. Smola,
  /// editors, Advances in Kernel Methods - Support Vector Learning, 1998. S.S.
  /// Keerthi, S.K. Shevade, C. Bhattacharyya, K.R.K. Murthy (2001). Improvements to
  /// Platt's SMO Algorithm for SVM Classifier Design. Neural Computation.
  /// 13(3):637-649. Trevor Hastie, Robert Tibshirani: Classification by Pairwise
  /// Coupling. In: Advances in Neural Information Processing Systems, 1998.
  /// </summary>
  public class SMO<T> : BaseClassifier<T>
  {
    public SMO(Runtime<T> rt) : base(rt, new SMO()) {}

    /// <summary>
    /// Turns time-consuming checks off - use with caution.
    /// </summary>    
    public SMO<T> ChecksTurnedOff (bool value) {
      ((SMO)impl).setChecksTurnedOff(value);
      return this;
    }

    /// <summary>
    /// The complexity parameter C.
    /// </summary>    
    public SMO<T> C (double value) {
      ((SMO)impl).setC(value);
      return this;
    }

    /// <summary>
    /// The tolerance parameter (shouldn't be changed).
    /// </summary>    
    public SMO<T> ToleranceParameter (double value) {
      ((SMO)impl).setToleranceParameter(value);
      return this;
    }

    /// <summary>
    /// The epsilon for round-off error (shouldn't be changed).
    /// </summary>    
    public SMO<T> Epsilon (double value) {
      ((SMO)impl).setEpsilon(value);
      return this;
    }

    /// <summary>
    /// Determines how/if the data will be transformed.
    /// </summary>    
    public SMO<T> FilterType (EFilterType value) {
      ((SMO)impl).setFilterType(new SelectedTag((int) value, SMO.TAGS_FILTER));
      return this;
    }

    /// <summary>
    /// Whether to fit logistic models to the outputs (for proper probability
    /// estimates).
    /// </summary>    
    public SMO<T> BuildLogisticModels (bool value) {
      ((SMO)impl).setBuildLogisticModels(value);
      return this;
    }

    /// <summary>
    /// The number of folds for cross-validation used to generate training data
    /// for logistic models (-1 means use training data).
    /// </summary>    
    public SMO<T> NumFolds (int value) {
      ((SMO)impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// Random number seed for the cross-validation.
    /// </summary>    
    public SMO<T> RandomSeed (int value) {
      ((SMO)impl).setRandomSeed(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SMO<T> Debug (bool value) {
      ((SMO)impl).setDebug(value);
      return this;
    }

        
    public enum EFilterType {
      Normalize_training_data = 0,
      Standardize_training_data = 1,
      No_normalization_div_standardization = 2
    }

        
  }
}