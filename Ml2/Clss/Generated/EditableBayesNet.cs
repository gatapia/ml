using weka.core;
using weka.classifiers.bayes.net;

namespace Ml2.Clss
{
  /// <summary>
  /// Bayes Network learning using various search algorithms and quality
  /// measures. Base class for a Bayes Network classifier. Provides datastructures
  /// (network structure, conditional probability distributions, etc.) and facilities
  /// common to Bayes Network learning algorithms like K2 and B. For more
  /// information see: http://www.cs.waikato.ac.nz/~remco/weka.pdf
  /// </summary>
  public class EditableBayesNet<T> : BaseClassifier<T>
  {
    public EditableBayesNet(Runtime<T> rt) : base(rt, new EditableBayesNet()) {}

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> BIFFile (string value) {
      ((EditableBayesNet)impl).setBIFFile(value);
      return this;
    }

    /// <summary>
    /// When ADTree (the data structure for increasing speed on counts, not to be
    /// confused with the classifier under the same name) is used learning time
    /// goes down typically. However, because ADTrees are memory intensive, memory
    /// problems may occur. Switching this option off makes the structure learning
    /// algorithms slower, and run with less memory. By default, ADTrees are used.
    /// </summary>    
    public EditableBayesNet<T> UseADTree (bool value) {
      ((EditableBayesNet)impl).setUseADTree(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public EditableBayesNet<T> Debug (bool value) {
      ((EditableBayesNet)impl).setDebug(value);
      return this;
    }

        
        
  }
}