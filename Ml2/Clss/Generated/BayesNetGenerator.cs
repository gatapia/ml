using System.Linq;
using weka.classifiers.bayes.net;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Bayes Network learning using various search algorithms and quality
  /// measures. Base class for a Bayes Network classifier. Provides datastructures
  /// (network structure, conditional probability distributions, etc.) and facilities
  /// common to Bayes Network learning algorithms like K2 and B. For more
  /// information see: http://www.cs.waikato.ac.nz/~remco/weka.pdf
  /// </summary>
  public class BayesNetGenerator<T> : BaseClassifier<T, BayesNetGenerator>
  {
    public BayesNetGenerator(Runtime<T> rt) : base(rt, new BayesNetGenerator()) {}

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> Distribution (int nTargetNode, double[][] P) {
      ((BayesNetGenerator)Impl).setDistribution(nTargetNode, P);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> Evidence (int iNode, int iValue) {
      ((BayesNetGenerator)Impl).setEvidence(iNode, iValue);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> Data (Runtime<T> instances) {
      ((BayesNetGenerator)Impl).setData(instances.Instances);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> Distribution (string sName, double[][] P) {
      ((BayesNetGenerator)Impl).setDistribution(sName, P);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> NodeName (int nTargetNode, string sName) {
      ((BayesNetGenerator)Impl).setNodeName(nTargetNode, sName);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> Position (int iNode, int nX, int nY) {
      ((BayesNetGenerator)Impl).setPosition(iNode, nX, nY);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> Position (int nNode, int nX, int nY, weka.core.FastVector nodes) {
      ((BayesNetGenerator)Impl).setPosition(nNode, nX, nY, nodes);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> Margin (int iNode, double[] fMarginP) {
      ((BayesNetGenerator)Impl).setMargin(iNode, fMarginP);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator<T> BIFFile (string sBIFFile) {
      ((BayesNetGenerator)Impl).setBIFFile(sBIFFile);
      return this;
    }

    /// <summary>
    /// When ADTree (the data structure for increasing speed on counts, not to be
    /// confused with the classifier under the same name) is used learning time
    /// goes down typically. However, because ADTrees are memory intensive, memory
    /// problems may occur. Switching this option off makes the structure learning
    /// algorithms slower, and run with less memory. By default, ADTrees are used.
    /// </summary>    
    public BayesNetGenerator<T> UseADTree (bool bUseADTree) {
      ((BayesNetGenerator)Impl).setUseADTree(bUseADTree);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public BayesNetGenerator<T> Debug (bool debug) {
      ((BayesNetGenerator)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}