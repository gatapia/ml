using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Class implementing the Cobweb and Classit clustering
  /// algorithms.<br/><br/>Note: the application of node operators (merging, splitting etc.) in terms
  /// of ordering and priority differs (and is somewhat ambiguous) between the
  /// original Cobweb and Classit papers. This algorithm always compares the best
  /// host, adding a new leaf, merging the two best hosts, and splitting the best
  /// host when considering where to place a new instance.<br/><br/>For more
  /// information see:<br/><br/>D. Fisher (1987). Knowledge acquisition via
  /// incremental conceptual clustering. Machine Learning. 2(2):139-172.<br/><br/>J. H.
  /// Gennari, P. Langley, D. Fisher (1990). Models of incremental concept
  /// formation. Artificial Intelligence. 40:11-61.<br/><br/>Options:<br/><br/>-A
  /// &lt;acuity&gt; = 	Acuity.<br/>	(default=1.0)<br/>-C &lt;cutoff&gt; =
  /// 	Cutoff.<br/>	(default=0.002)<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
  /// 42)
  /// </summary>
  public class Cobweb<T> : BaseClusterer<T, Cobweb> where T : new()
  {    
    public Cobweb(Runtime<T> rt) : base(rt, new Cobweb()) {}

    /// <summary>
    /// set the minimum standard deviation for numeric attributes
    /// </summary>    
    public Cobweb<T> Acuity (double a) {
      ((Cobweb)Impl).setAcuity(a);
      return this;
    }

    /// <summary>
    /// set the category utility threshold by which to prune nodes
    /// </summary>    
    public Cobweb<T> Cutoff (double c) {
      ((Cobweb)Impl).setCutoff(c);
      return this;
    }

    /// <summary>
    /// save instance information for visualization purposes
    /// </summary>    
    public Cobweb<T> SaveInstanceData (bool newsaveInstances) {
      ((Cobweb)Impl).setSaveInstanceData(newsaveInstances);
      return this;
    }

            

        
  }
}