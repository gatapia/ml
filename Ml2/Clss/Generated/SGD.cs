using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Implements stochastic gradient descent for learning various linear models
  /// (binary class SVM, binary class logistic regression, squared loss, Huber
  /// loss and epsilon-insensitive loss linear regression). Globally replaces all
  /// missing values and transforms nominal attributes into binary ones. It also
  /// normalizes all attributes, so the coefficients in the output are based on
  /// the normalized data. For numeric class attributes, the squared, Huber or
  /// epsilon-insensitve loss function must be used. Epsilon-insensitive and Huber
  /// loss may require a much higher learning rate.
  /// </summary>
  public class SGD<T> : BaseClassifier<T>
  {
    public SGD(Runtime<T> rt) : base(rt, new SGD()) {}

    /// <summary>
    /// The loss function to use. Hinge loss (SVM), log loss (logistic
    /// regression) or squared loss (regression).
    /// </summary>    
    public SGD<T> LossFunction (ELossFunction function) {
      ((SGD)Impl).setLossFunction(new weka.core.SelectedTag((int) function, SGD.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// The regularization constant. (default = 0.0001)
    /// </summary>    
    public SGD<T> Lambda (double lambda) {
      ((SGD)Impl).setLambda(lambda);
      return this;
    }

    /// <summary>
    /// The learning rate. If normalization is turned off (as it is automatically
    /// for streaming data), thenthe default learning rate will need to be reduced
    /// (try 0.0001).
    /// </summary>    
    public SGD<T> LearningRate (double lr) {
      ((SGD)Impl).setLearningRate(lr);
      return this;
    }

    /// <summary>
    /// The number of epochs to perform (batch learning). The total number of
    /// iterations is epochs * num instances.
    /// </summary>    
    public SGD<T> Epochs (int e) {
      ((SGD)Impl).setEpochs(e);
      return this;
    }

    /// <summary>
    /// The epsilon threshold for epsilon insensitive and Huber loss. An error
    /// with absolute value less that this threshold has loss of 0 for epsilon
    /// insensitive loss. For Huber loss this is the boundary between the quadratic and
    /// linear parts of the loss function.
    /// </summary>    
    public SGD<T> Epsilon (double e) {
      ((SGD)Impl).setEpsilon(e);
      return this;
    }

    /// <summary>
    /// Turn normalization off
    /// </summary>    
    public SGD<T> DontNormalize (bool m) {
      ((SGD)Impl).setDontNormalize(m);
      return this;
    }

    /// <summary>
    /// Turn off global replacement of missing values
    /// </summary>    
    public SGD<T> DontReplaceMissing (bool m) {
      ((SGD)Impl).setDontReplaceMissing(m);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public SGD<T> Seed (int seed) {
      ((SGD)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SGD<T> Debug (bool debug) {
      ((SGD)Impl).setDebug(debug);
      return this;
    }

        
    public enum ELossFunction {
      Hinge_loss_SVM = 0,
      Log_loss_logistic_regression = 1,
      Squared_loss_regression = 2,
      Epsilon_insensitive_loss_SVM_regression = 3,
      Huber_loss_robust_regression = 4
    }

        
  }
}