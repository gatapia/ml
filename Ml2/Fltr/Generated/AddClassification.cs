using weka.filters.supervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter for adding the classification, the class distribution and an
  /// error flag to a dataset with a classifier. The classifier is either trained on
  /// the data itself or provided as serialized model.
  /// </summary>
  public class AddClassification<T> : BaseFilter<T, AddClassification>
  {
    public AddClassification(Runtime<T> rt) : base(rt, new AddClassification()) {}

    /// <summary>
    /// Whether to add an attribute with the actual classification.
    /// </summary>    
    public AddClassification<T> OutputClassification (bool value) {
      ((AddClassification)Impl).setOutputClassification(value);
      return this;
    }

    /// <summary>
    /// Whether to remove the old class attribute.
    /// </summary>    
    public AddClassification<T> RemoveOldClass (bool value) {
      ((AddClassification)Impl).setRemoveOldClass(value);
      return this;
    }

    /// <summary>
    /// Whether to add attributes with the distribution for all classes (for
    /// numeric classes this will be identical to the attribute output with
    /// 'outputClassification').
    /// </summary>    
    public AddClassification<T> OutputDistribution (bool value) {
      ((AddClassification)Impl).setOutputDistribution(value);
      return this;
    }

    /// <summary>
    /// Whether to add an attribute indicating whether the classifier output a
    /// wrong classification (for numeric classes this is the numeric difference).
    /// </summary>    
    public AddClassification<T> OutputErrorFlag (bool value) {
      ((AddClassification)Impl).setOutputErrorFlag(value);
      return this;
    }

    /// <summary>
    /// The classifier to use for classification.
    /// </summary>    
    public AddClassification<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> value) {
      ((AddClassification)Impl).setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public AddClassification<T> Debug (bool value) {
      ((AddClassification)Impl).setDebug(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public AddClassification<T> InputFormat (Runtime<T> instanceInfo) {
      ((AddClassification)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}