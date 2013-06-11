using weka.core;
using weka.filters.unsupervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that removes instances which are incorrectly classified. Useful
  /// for removing outliers.
  /// </summary>
  public class RemoveMisclassified<T> : BaseFilter<T>
  {
    public RemoveMisclassified(Runtime<T> rt) : base(rt, new RemoveMisclassified()) {}

    /// <summary>
    /// Index of the class upon which to base the misclassifications. If < 0 will
    /// use any current set class or default to the last attribute.
    /// </summary>    
    public RemoveMisclassified<T> ClassIndex (int value) {
      ((weka.filters.unsupervised.instance.RemoveMisclassified)impl).setClassIndex(value);
      return this;
    }

    /// <summary>
    /// The number of cross-validation folds to use. If < 2 then no
    /// cross-validation will be performed.
    /// </summary>    
    public RemoveMisclassified<T> NumFolds (int value) {
      ((weka.filters.unsupervised.instance.RemoveMisclassified)impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// Threshold for the max allowable error when predicting a numeric class.
    /// Should be >= 0.
    /// </summary>    
    public RemoveMisclassified<T> Threshold (double value) {
      ((weka.filters.unsupervised.instance.RemoveMisclassified)impl).setThreshold(value);
      return this;
    }

    /// <summary>
    /// The maximum number of iterations to perform. < 1 means filter will go
    /// until fully cleansed.
    /// </summary>    
    public RemoveMisclassified<T> MaxIterations (int value) {
      ((weka.filters.unsupervised.instance.RemoveMisclassified)impl).setMaxIterations(value);
      return this;
    }

    /// <summary>
    /// Whether or not to invert the selection. If true, correctly classified
    /// instances will be discarded.
    /// </summary>    
    public RemoveMisclassified<T> Invert (bool value) {
      ((weka.filters.unsupervised.instance.RemoveMisclassified)impl).setInvert(value);
      return this;
    }

        
        
  }
}