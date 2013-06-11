using weka.core;
using weka.classifiers.lazy;

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
    public IBk<T> KNN (int value) {
      ((IBk)impl).setKNN(value);
      return this;
    }

    /// <summary>
    /// Gets the maximum number of instances allowed in the training pool. The
    /// addition of new instances above this value will result in old instances being
    /// removed. A value of 0 signifies no limit to the number of training
    /// instances.
    /// </summary>    
    public IBk<T> WindowSize (int value) {
      ((IBk)impl).setWindowSize(value);
      return this;
    }

    /// <summary>
    /// Gets the distance weighting method used.
    /// </summary>    
    public IBk<T> DistanceWeighting (EDistanceWeighting value) {
      ((IBk)impl).setDistanceWeighting(new SelectedTag((int) value, IBk.TAGS_WEIGHTING));
      return this;
    }

    /// <summary>
    /// Whether hold-one-out cross-validation will be used to select the best k
    /// value.
    /// </summary>    
    public IBk<T> CrossValidate (bool value) {
      ((IBk)impl).setCrossValidate(value);
      return this;
    }

    /// <summary>
    /// Whether the mean squared error is used rather than mean absolute error
    /// when doing cross-validation for regression problems.
    /// </summary>    
    public IBk<T> MeanSquared (bool value) {
      ((IBk)impl).setMeanSquared(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public IBk<T> Debug (bool value) {
      ((IBk)impl).setDebug(value);
      return this;
    }

        
    public enum EDistanceWeighting {
      No_distance_weighting = 1,
      Weight_by_one_div_distance = 2,
      Weight_by_one_distance = 4
    }

        
  }
}