using weka.core;
using weka.classifiers.bayes;

namespace Ml2.Clss
{
  /// <summary>
  /// Multinomial naive bayes for text data. Operates directly (and only) on
  /// String attributes. Other types of input attributes are accepted but ignored
  /// during training and classification
  /// </summary>
  public class NaiveBayesMultinomialText<T> : BaseClassifier<T>
  {
    public NaiveBayesMultinomialText(Runtime<T> rt) : base(rt, new NaiveBayesMultinomialText()) {}

    /// <summary>
    /// If true, ignores all words that are on the stoplist.
    /// </summary>    
    public NaiveBayesMultinomialText<T> UseStopList (bool value) {
      ((NaiveBayesMultinomialText)Impl).setUseStopList(value);
      return this;
    }

    /// <summary>
    /// Use word frequencies rather than binary bag of words representation
    /// </summary>    
    public NaiveBayesMultinomialText<T> UseWordFrequencies (bool value) {
      ((NaiveBayesMultinomialText)Impl).setUseWordFrequencies(value);
      return this;
    }

    /// <summary>
    /// How often (number of instances) to prune the dictionary of low frequency
    /// terms. 0 means don't prune. Setting a positive integer n means prune after
    /// every n instances
    /// </summary>    
    public NaiveBayesMultinomialText<T> PeriodicPruning (int value) {
      ((NaiveBayesMultinomialText)Impl).setPeriodicPruning(value);
      return this;
    }

    /// <summary>
    /// Ignore any words that don't occur at least min frequency times in the
    /// training data. If periodic pruning is turned on, then the dictionary is pruned
    /// according to this value
    /// </summary>    
    public NaiveBayesMultinomialText<T> MinWordFrequency (double value) {
      ((NaiveBayesMultinomialText)Impl).setMinWordFrequency(value);
      return this;
    }

    /// <summary>
    /// If true then document length is normalized according to the settings for
    /// norm and lnorm
    /// </summary>    
    public NaiveBayesMultinomialText<T> NormalizeDocLength (bool value) {
      ((NaiveBayesMultinomialText)Impl).setNormalizeDocLength(value);
      return this;
    }

    /// <summary>
    /// The norm of the instances after normalization.
    /// </summary>    
    public NaiveBayesMultinomialText<T> Norm (double value) {
      ((NaiveBayesMultinomialText)Impl).setNorm(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public NaiveBayesMultinomialText<T> LNorm (double value) {
      ((NaiveBayesMultinomialText)Impl).setLNorm(value);
      return this;
    }

    /// <summary>
    /// Whether to convert all tokens to lowercase
    /// </summary>    
    public NaiveBayesMultinomialText<T> LowercaseTokens (bool value) {
      ((NaiveBayesMultinomialText)Impl).setLowercaseTokens(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public NaiveBayesMultinomialText<T> Debug (bool value) {
      ((NaiveBayesMultinomialText)Impl).setDebug(value);
      return this;
    }

        
        
  }
}