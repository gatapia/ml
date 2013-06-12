using System.Linq;
using weka.classifiers.bayes;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a multinomial Naive Bayes classifier. For
  /// more information see, Andrew Mccallum, Kamal Nigam: A Comparison of Event
  /// Models for Naive Bayes Text Classification. In: AAAI-98 Workshop on 'Learning
  /// for Text Categorization', 1998. The core equation for this classifier:
  /// P[Ci|D] = (P[D|Ci] x P[Ci]) / P[D] (Bayes rule) where Ci is class i and D is a
  /// document. Incremental version of the algorithm.
  /// </summary>
  public class NaiveBayesMultinomialUpdateable<T> : BaseClassifier<T>
  {
    public NaiveBayesMultinomialUpdateable(Runtime<T> rt) : base(rt, new NaiveBayesMultinomialUpdateable()) {}

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public NaiveBayesMultinomialUpdateable<T> Debug (bool debug) {
      ((NaiveBayesMultinomialUpdateable)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}