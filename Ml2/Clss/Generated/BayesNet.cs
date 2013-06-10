using weka.classifiers.bayes;

namespace Ml2.Clss
{
  /// <summary>
  /// Bayes Network learning using various search algorithms and quality
  /// measures. Base class for a Bayes Network classifier. Provides datastructures
  /// (network structure, conditional probability distributions, etc.) and facilities
  /// common to Bayes Network learning algorithms like K2 and B. For more
  /// information see: http://www.cs.waikato.ac.nz/~remco/weka.pdf
  /// </summary>
  public class BayesNet<T> : BaseClassifier<T>
  {
    public BayesNet(Runtime<T> rt) : base(rt, new BayesNet()) {}

    /// <summary>
    /// 
    /// </summary>    
    public BayesNet<T> BIFFile (string value) {
      ((BayesNet)impl).setBIFFile(value);
      return this;
    }

    /// <summary>
    /// When ADTree (the data structure for increasing speed on counts, not to be
    /// confused with the classifier under the same name) is used learning time
    /// goes down typically. However, because ADTrees are memory intensive, memory
    /// problems may occur. Switching this option off makes the structure learning
    /// algorithms slower, and run with less memory. By default, ADTrees are used.
    /// </summary>    
    public BayesNet<T> UseADTree (bool value) {
      ((BayesNet)impl).setUseADTree(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public BayesNet<T> Debug (bool value) {
      ((BayesNet)impl).setDebug(value);
      return this;
    }

        
  }
}