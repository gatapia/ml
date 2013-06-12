using weka.core;
using weka.classifiers.functions;

namespace Ml2.Clss
{
  /// <summary>
  /// Implements stochastic gradient descent for learning a linear binary class
  /// SVM or binary class logistic regression on text data. Operates directly
  /// (and only) on String attributes. Other types of input attributes are accepted
  /// but ignored during training and classification.
  /// </summary>
  public class SGDText<T> : BaseClassifier<T>
  {
    public SGDText(Runtime<T> rt) : base(rt, new SGDText()) {}

    /// <summary>
    /// If true, ignores all words that are on the stoplist.
    /// </summary>    
    public SGDText<T> UseStopList (bool value) {
      ((SGDText)Impl).setUseStopList(value);
      return this;
    }

    /// <summary>
    /// The loss function to use. Hinge loss (SVM), log loss (logistic
    /// regression) or squared loss (regression).
    /// </summary>    
    public SGDText<T> LossFunction (ELossFunction value) {
      ((SGDText)Impl).setLossFunction(new SelectedTag((int) value, SGDText.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// Fit a logistic regression to the output of SVM for producing probability
    /// estimates
    /// </summary>    
    public SGDText<T> OutputProbsForSVM (bool value) {
      ((SGDText)Impl).setOutputProbsForSVM(value);
      return this;
    }

    /// <summary>
    /// The regularization constant. (default = 0.0001)
    /// </summary>    
    public SGDText<T> Lambda (double value) {
      ((SGDText)Impl).setLambda(value);
      return this;
    }

    /// <summary>
    /// The learning rate.
    /// </summary>    
    public SGDText<T> LearningRate (double value) {
      ((SGDText)Impl).setLearningRate(value);
      return this;
    }

    /// <summary>
    /// The number of epochs to perform (batch learning). The total number of
    /// iterations is epochs * num instances.
    /// </summary>    
    public SGDText<T> Epochs (int value) {
      ((SGDText)Impl).setEpochs(value);
      return this;
    }

    /// <summary>
    /// Use word frequencies rather than binary bag of words representation
    /// </summary>    
    public SGDText<T> UseWordFrequencies (bool value) {
      ((SGDText)Impl).setUseWordFrequencies(value);
      return this;
    }

    /// <summary>
    /// How often (number of instances) to prune the dictionary of low frequency
    /// terms. 0 means don't prune. Setting a positive integer n means prune after
    /// every n instances
    /// </summary>    
    public SGDText<T> PeriodicPruning (int value) {
      ((SGDText)Impl).setPeriodicPruning(value);
      return this;
    }

    /// <summary>
    /// Ignore any words that don't occur at least min frequency times in the
    /// training data. If periodic pruning is turned on, then the dictionary is pruned
    /// according to this value
    /// </summary>    
    public SGDText<T> MinWordFrequency (double value) {
      ((SGDText)Impl).setMinWordFrequency(value);
      return this;
    }

    /// <summary>
    /// If true then document length is normalized according to the settings for
    /// norm and lnorm
    /// </summary>    
    public SGDText<T> NormalizeDocLength (bool value) {
      ((SGDText)Impl).setNormalizeDocLength(value);
      return this;
    }

    /// <summary>
    /// The norm of the instances after normalization.
    /// </summary>    
    public SGDText<T> Norm (double value) {
      ((SGDText)Impl).setNorm(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public SGDText<T> LNorm (double value) {
      ((SGDText)Impl).setLNorm(value);
      return this;
    }

    /// <summary>
    /// Whether to convert all tokens to lowercase
    /// </summary>    
    public SGDText<T> LowercaseTokens (bool value) {
      ((SGDText)Impl).setLowercaseTokens(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public SGDText<T> Bias (double value) {
      ((SGDText)Impl).setBias(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public SGDText<T> Seed (int value) {
      ((SGDText)Impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SGDText<T> Debug (bool value) {
      ((SGDText)Impl).setDebug(value);
      return this;
    }

        
    public enum ELossFunction {
      Hinge_loss_SVM = 0,
      Log_loss_logistic_regression = 1
    }

        
  }
}