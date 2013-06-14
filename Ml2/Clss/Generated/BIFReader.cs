using System.Linq;
using weka.classifiers.bayes.net;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Builds a description of a Bayes Net classifier stored in XML BIF 0.3
  /// format.<br/><br/>For more details on XML BIF see:<br/><br/>Fabio Cozman, Marek
  /// Druzdzel, Daniel Garcia (1998). XML BIF version 0.3. URL
  /// http://www-2.cs.cmu.edu/~fgcozman/Research/InterchangeFormat/.<br/><br/>Options:<br/><br/>-D
  /// = 	Do not use ADTree data structure<br/><br/>-B &lt;BIF file&gt; = 	BIF
  /// file to compare with<br/><br/>-Q
  /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
  /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
  /// </summary>
  public class BIFReader<T> : BaseClassifier<T, BIFReader> where T : new()
  {
    public BIFReader(Runtime<T> rt) : base(rt, new BIFReader()) {}

    /// <summary>
    /// 
    /// </summary>    
    public BIFReader<T> BIFFile (string sBIFFile) {
      ((BIFReader)Impl).setBIFFile(sBIFFile);
      return this;
    }

    /// <summary>
    /// When ADTree (the data structure for increasing speed on counts, not to be
    /// confused with the classifier under the same name) is used learning time
    /// goes down typically. However, because ADTrees are memory intensive, memory
    /// problems may occur. Switching this option off makes the structure learning
    /// algorithms slower, and run with less memory. By default, ADTrees are used.
    /// </summary>    
    public BIFReader<T> UseADTree (bool bUseADTree) {
      ((BIFReader)Impl).setUseADTree(bUseADTree);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public BIFReader<T> Debug (bool debug) {
      ((BIFReader)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}