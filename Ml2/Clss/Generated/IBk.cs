using System.Linq;
using weka.classifiers.lazy;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// K-nearest neighbours classifier. Can select appropriate value of K based
  /// on cross-validation. Can also do distance weighting.<br/><br/>For more
  /// information, see<br/><br/>D. Aha, D. Kibler (1991). Instance-based learning
  /// algorithms. Machine Learning. 6:37-66.<br/><br/>Options:<br/><br/>-I = 	Weight
  /// neighbours by the inverse of their distance<br/>	(use when k > 1)<br/>-F =
  /// 	Weight neighbours by 1 - their distance<br/>	(use when k > 1)<br/>-K
  /// &lt;number of neighbors&gt; = 	Number of nearest neighbours (k) used in
  /// classification.<br/>	(Default = 1)<br/>-E = 	Minimise mean squared error rather
  /// than mean absolute<br/>	error when using -X option with numeric
  /// prediction.<br/>-W &lt;window size&gt; = 	Maximum number of training instances
  /// maintained.<br/>	Training instances are dropped FIFO. (Default = no window)<br/>-X =
  /// 	Select the number of nearest neighbours between 1<br/>	and the k value
  /// specified using hold-one-out evaluation<br/>	on the training data (use when k
  /// > 1)<br/>-A = 	The nearest neighbour search algorithm to use (default:
  /// weka.core.neighboursearch.LinearNNSearch).<br/>
  /// </summary>
  public class IBk<T> : BaseClassifier<T, IBk> where T : new()
  {
    public IBk(Runtime<T> rt) : base(rt, new IBk()) {}

    /// <summary>
    /// 
    /// </summary>    
    public IBk<T> KNN (int k) {
      ((IBk)Impl).setKNN(k);
      return this;
    }

    /// <summary>
    /// Gets the maximum number of instances allowed in the training pool. The
    /// addition of new instances above this value will result in old instances being
    /// removed. A value of 0 signifies no limit to the number of training
    /// instances.
    /// </summary>    
    public IBk<T> WindowSize (int newWindowSize) {
      ((IBk)Impl).setWindowSize(newWindowSize);
      return this;
    }

    /// <summary>
    /// Gets the distance weighting method used.
    /// </summary>    
    public IBk<T> DistanceWeighting (EDistanceWeighting newMethod) {
      ((IBk)Impl).setDistanceWeighting(new weka.core.SelectedTag((int) newMethod, IBk.TAGS_WEIGHTING));
      return this;
    }

    /// <summary>
    /// Whether hold-one-out cross-validation will be used to select the best k
    /// value.
    /// </summary>    
    public IBk<T> CrossValidate (bool newCrossValidate) {
      ((IBk)Impl).setCrossValidate(newCrossValidate);
      return this;
    }

    /// <summary>
    /// Whether the mean squared error is used rather than mean absolute error
    /// when doing cross-validation for regression problems.
    /// </summary>    
    public IBk<T> MeanSquared (bool newMeanSquared) {
      ((IBk)Impl).setMeanSquared(newMeanSquared);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public IBk<T> Debug (bool debug) {
      ((IBk)Impl).setDebug(debug);
      return this;
    }

        
    public enum EDistanceWeighting {
      No_distance_weighting = 1,
      Weight_by_one_div_distance = 2,
      Weight_by_one_distance = 4
    }

        
  }
}