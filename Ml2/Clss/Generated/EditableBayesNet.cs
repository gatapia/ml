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
  public class EditableBayesNet<T> : BaseClassifier<T>
  {
    public EditableBayesNet(Runtime<T> rt) : base(rt, new EditableBayesNet()) {}

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> Distribution (int nTargetNode, double[][] P) {
      ((EditableBayesNet)Impl).setDistribution(nTargetNode, P);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> Evidence (int iNode, int iValue) {
      ((EditableBayesNet)Impl).setEvidence(iNode, iValue);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> Data (Runtime<T> instances) {
      ((EditableBayesNet)Impl).setData(instances.Instances);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> Distribution (string sName, double[][] P) {
      ((EditableBayesNet)Impl).setDistribution(sName, P);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> NodeName (int nTargetNode, string sName) {
      ((EditableBayesNet)Impl).setNodeName(nTargetNode, sName);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> Position (int iNode, int nX, int nY) {
      ((EditableBayesNet)Impl).setPosition(iNode, nX, nY);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> Position (int nNode, int nX, int nY, weka.core.FastVector nodes) {
      ((EditableBayesNet)Impl).setPosition(nNode, nX, nY, nodes);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> Margin (int iNode, double[] fMarginP) {
      ((EditableBayesNet)Impl).setMargin(iNode, fMarginP);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet<T> BIFFile (string sBIFFile) {
      ((EditableBayesNet)Impl).setBIFFile(sBIFFile);
      return this;
    }

    /// <summary>
    /// When ADTree (the data structure for increasing speed on counts, not to be
    /// confused with the classifier under the same name) is used learning time
    /// goes down typically. However, because ADTrees are memory intensive, memory
    /// problems may occur. Switching this option off makes the structure learning
    /// algorithms slower, and run with less memory. By default, ADTrees are used.
    /// </summary>    
    public EditableBayesNet<T> UseADTree (bool bUseADTree) {
      ((EditableBayesNet)Impl).setUseADTree(bUseADTree);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public EditableBayesNet<T> Debug (bool debug) {
      ((EditableBayesNet)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}