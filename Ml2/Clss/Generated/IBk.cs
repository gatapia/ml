using System.Linq;
using weka.classifiers.lazy;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// K-nearest neighbours classifier. Can select appropriate value of K based
  /// on cross-validation. Can also do distance weighting. For more information,
  /// see D. Aha, D. Kibler (1991). Instance-based learning algorithms. Machine
  /// Learning. 6:37-66.
  /// </summary>
  public class IBk<T> : BaseClassifier<T>
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