using weka.core;
using weka.clusterers;

namespace Ml2.Clstr
{
  /// <summary>
  /// Class implementing the Cobweb and Classit clustering algorithms. Note:
  /// the application of node operators (merging, splitting etc.) in terms of
  /// ordering and priority differs (and is somewhat ambiguous) between the original
  /// Cobweb and Classit papers. This algorithm always compares the best host,
  /// adding a new leaf, merging the two best hosts, and splitting the best host
  /// when considering where to place a new instance. For more information see: D.
  /// Fisher (1987). Knowledge acquisition via incremental conceptual clustering.
  /// Machine Learning. 2(2):139-172. J. H. Gennari, P. Langley, D. Fisher
  /// (1990). Models of incremental concept formation. Artificial Intelligence.
  /// 40:11-61.
  /// </summary>
  public class Cobweb<T> : BaseClusterer<T>
  {    
    public Cobweb(Runtime<T> rt) : base(rt, new Cobweb()) {}

    /// <summary>
    /// set the minimum standard deviation for numeric attributes
    /// </summary>    
    public Cobweb<T> Acuity (double value) {
      ((weka.clusterers.Cobweb)impl).setAcuity(value);
      return this;
    }

    /// <summary>
    /// set the category utility threshold by which to prune nodes
    /// </summary>    
    public Cobweb<T> Cutoff (double value) {
      ((weka.clusterers.Cobweb)impl).setCutoff(value);
      return this;
    }

    /// <summary>
    /// save instance information for visualization purposes
    /// </summary>    
    public Cobweb<T> SaveInstanceData (bool value) {
      ((weka.clusterers.Cobweb)impl).setSaveInstanceData(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used. Use -1 for no randomization.
    /// </summary>    
    public Cobweb<T> Seed (int value) {
      ((weka.clusterers.Cobweb)impl).setSeed(value);
      return this;
    }

            

        
  }
}