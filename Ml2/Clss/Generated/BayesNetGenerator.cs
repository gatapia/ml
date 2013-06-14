using System.Linq;
using weka.classifiers.bayes.net;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Bayes Network learning using various search algorithms and quality
  /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
  /// (network structure, conditional probability distributions, etc.) and
  /// facilities common to Bayes Network learning algorithms like K2 and
  /// B.<br/><br/>For more information
  /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-B = 	Generate network (instead of
  /// instances)<br/><br/>-N &lt;integer&gt; = 	Nr of nodes<br/><br/>-A &lt;integer&gt; =
  /// 	Nr of arcs<br/><br/>-M &lt;integer&gt; = 	Nr of instances<br/><br/>-C
  /// &lt;integer&gt; = 	Cardinality of the variables<br/><br/>-S &lt;integer&gt; =
  /// 	Seed for random number generator<br/><br/>-F &lt;file&gt; = 	The BIF file to
  /// obtain the structure from.<br/>
  /// </summary>
  public class BayesNetGenerator<T> : BaseClassifier<T, BayesNetGenerator> where T : new()
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