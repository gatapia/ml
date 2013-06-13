using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that removes instances which are incorrectly classified. Useful
  /// for removing outliers.
  /// </summary>
  public class RemoveMisclassified<T> : BaseFilter<T, RemoveMisclassified>
  {
    public RemoveMisclassified(Runtime<T> rt) : base(rt, new RemoveMisclassified()) {}

    /// <summary>
    /// The classifier upon which to base the misclassifications.
    /// </summary>    
    public RemoveMisclassified<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> classifier) {
      ((RemoveMisclassified)Impl).setClassifier(classifier.Impl);
      return this;
    }

    /// <summary>
    /// Index of the class upon which to base the misclassifications. If < 0 will
    /// use any current set class or default to the last attribute.
    /// </summary>    
    public RemoveMisclassified<T> ClassIndex (int classIndex) {
      ((RemoveMisclassified)Impl).setClassIndex(classIndex);
      return this;
    }

    /// <summary>
    /// The number of cross-validation folds to use. If < 2 then no
    /// cross-validation will be performed.
    /// </summary>    
    public RemoveMisclassified<T> NumFolds (int numOfFolds) {
      ((RemoveMisclassified)Impl).setNumFolds(numOfFolds);
      return this;
    }

    /// <summary>
    /// Threshold for the max allowable error when predicting a numeric class.
    /// Should be >= 0.
    /// </summary>    
    public RemoveMisclassified<T> Threshold (double threshold) {
      ((RemoveMisclassified)Impl).setThreshold(threshold);
      return this;
    }

    /// <summary>
    /// The maximum number of iterations to perform. < 1 means filter will go
    /// until fully cleansed.
    /// </summary>    
    public RemoveMisclassified<T> MaxIterations (int iterations) {
      ((RemoveMisclassified)Impl).setMaxIterations(iterations);
      return this;
    }

    /// <summary>
    /// Whether or not to invert the selection. If true, correctly classified
    /// instances will be discarded.
    /// </summary>    
    public RemoveMisclassified<T> Invert (bool invert) {
      ((RemoveMisclassified)Impl).setInvert(invert);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public RemoveMisclassified<T> InputFormat (Runtime<T> instanceInfo) {
      ((RemoveMisclassified)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}