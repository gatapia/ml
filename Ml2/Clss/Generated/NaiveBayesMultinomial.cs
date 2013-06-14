using System.Linq;
using weka.classifiers.bayes;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a multinomial Naive Bayes classifier. For
  /// more information see,<br/><br/>Andrew Mccallum, Kamal Nigam: A Comparison of
  /// Event Models for Naive Bayes Text Classification. In: AAAI-98 Workshop on
  /// 'Learning for Text Categorization', 1998.<br/><br/>The core equation for
  /// this classifier:<br/><br/>P[Ci|D] = (P[D|Ci] x P[Ci]) / P[D] (Bayes
  /// rule)<br/><br/>where Ci is class i and D is a document.<br/><br/>Options:<br/><br/>-D
  /// = 	If set, classifier is run in debug mode and<br/>	may output additional
  /// info to the console
  /// </summary>
  public class NaiveBayesMultinomial<T> : BaseClassifier<T, NaiveBayesMultinomial> where T : new()
  {
    public NaiveBayesMultinomial(Runtime<T> rt) : base(rt, new NaiveBayesMultinomial()) {}

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public NaiveBayesMultinomial<T> Debug (bool debug) {
      ((NaiveBayesMultinomial)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}