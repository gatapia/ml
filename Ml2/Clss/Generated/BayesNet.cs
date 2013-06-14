using System.Linq;
using weka.classifiers.bayes;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Bayes Network learning using various search algorithms and quality
  /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
  /// (network structure, conditional probability distributions, etc.) and
  /// facilities common to Bayes Network learning algorithms like K2 and
  /// B.<br/><br/>For more information
  /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-D = 	Do not use ADTree data
  /// structure<br/><br/>-B &lt;BIF file&gt; = 	BIF file to compare with<br/><br/>-Q
  /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
  /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
  /// </summary>
  public class BayesNet<T> : BaseClassifier<T, BayesNet> where T : new()
  {
    public BayesNet(Runtime<T> rt) : base(rt, new BayesNet()) {}

    /// <summary>
    /// 
    /// </summary>    
    public BayesNet<T> BIFFile (string sBIFFile) {
      ((BayesNet)Impl).setBIFFile(sBIFFile);
      return this;
    }

    /// <summary>
    /// When ADTree (the data structure for increasing speed on counts, not to be
    /// confused with the classifier under the same name) is used learning time
    /// goes down typically. However, because ADTrees are memory intensive, memory
    /// problems may occur. Switching this option off makes the structure learning
    /// algorithms slower, and run with less memory. By default, ADTrees are used.
    /// </summary>    
    public BayesNet<T> UseADTree (bool bUseADTree) {
      ((BayesNet)Impl).setUseADTree(bUseADTree);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public BayesNet<T> Debug (bool debug) {
      ((BayesNet)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}