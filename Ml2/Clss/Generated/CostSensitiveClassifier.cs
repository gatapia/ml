using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A metaclassifier that makes its base classifier cost-sensitive. Two
  /// methods can be used to introduce cost-sensitivity: reweighting training
  /// instances according to the total cost assigned to each class; or predicting the
  /// class with minimum expected misclassification cost (rather than the most
  /// likely class). Performance can often be improved by using a Bagged classifier to
  /// improve the probability estimates of the base
  /// classifier.<br/><br/>Options:<br/><br/>-M = 	Minimize expected misclassification cost. Default is
  /// to<br/>	reweight training instances according to costs per class<br/>-C &lt;cost
  /// file name&gt; = 	File name of a cost matrix to use. If this is not
  /// supplied,<br/>	a cost matrix will be loaded on demand. The name of
  /// the<br/>	on-demand file is the relation name of the training data<br/>	plus ".cost", and
  /// the path to the on-demand file is<br/>	specified with the -N option.<br/>-N
  /// &lt;directory&gt; = 	Name of a directory to search for cost files when
  /// loading<br/>	costs on demand (default current directory).<br/>-cost-matrix
  /// &lt;matrix&gt; = 	The cost matrix in Matlab single line format.<br/>-S
  /// &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is
  /// run in debug mode and<br/>	may output additional info to the
  /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
  /// weka.classifiers.rules.ZeroR)<br/><br/>Options specific to classifier weka.classifiers.rules.ZeroR:
  /// = <br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console
  /// </summary>
  public class CostSensitiveClassifier<T> : BaseClassifier<T, CostSensitiveClassifier> where T : new()
  {
    public CostSensitiveClassifier(Runtime<T> rt) : base(rt, new CostSensitiveClassifier()) {}

    /// <summary>
    /// Sets whether the minimum expected cost criteria will be used. If this is
    /// false, the training data will be reweighted according to the costs assigned
    /// to each class. If true, the minimum expected cost criteria will be used.
    /// </summary>    
    public CostSensitiveClassifier<T> MinimizeExpectedCost (bool newMinimizeExpectedCost) {
      ((CostSensitiveClassifier)Impl).setMinimizeExpectedCost(newMinimizeExpectedCost);
      return this;
    }

    /// <summary>
    /// Sets where to get the cost matrix. The two options areto use the supplied
    /// explicit cost matrix (the setting of the costMatrix property), or to load
    /// a cost matrix from a file when required (this file will be loaded from the
    /// directory set by the onDemandDirectory property and will be named
    /// relation_name.cost).
    /// </summary>    
    public CostSensitiveClassifier<T> CostMatrixSource (ECostMatrixSource newMethod) {
      ((CostSensitiveClassifier)Impl).setCostMatrixSource(new weka.core.SelectedTag((int) newMethod, CostSensitiveClassifier.TAGS_MATRIX_SOURCE));
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public CostSensitiveClassifier<T> Seed (int seed) {
      throw new System.NotSupportedException("Seeds are handled internally by the system for reproducability.")
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public CostSensitiveClassifier<T> Classifier (Clss.IBaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((CostSensitiveClassifier)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public CostSensitiveClassifier<T> Debug (bool debug) {
      ((CostSensitiveClassifier)Impl).setDebug(debug);
      return this;
    }

        
    public enum ECostMatrixSource {
      Load_cost_matrix_on_demand = 1,
      Use_explicit_cost_matrix = 2
    }

        
  }
}