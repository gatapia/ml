using weka.filters.supervised.attribute;

namespace Ml2.Fltr.Generated
{
  /// <summary>
  /// A filter for adding the classification, the class distribution and an
  /// error flag to a dataset with a classifier. The classifier is either trained on
  /// the data itself or provided as serialized model.
  /// </summary>
  public class AddClassification<T> : BaseFilter<T>
  {
    public AddClassification(Runtime<T> rt) : base(rt, new AddClassification()) {}

    /// <summary>
    /// Whether to add an attribute with the actual classification.
    /// </summary>    
    public AddClassification<T> OutputClassification (bool value) {
      ((AddClassification)impl).setOutputClassification(value);
      return this;
    }
    /// <summary>
    /// Whether to remove the old class attribute.
    /// </summary>    
    public AddClassification<T> RemoveOldClass (bool value) {
      ((AddClassification)impl).setRemoveOldClass(value);
      return this;
    }
    /// <summary>
    /// Whether to add attributes with the distribution for all classes (for
    /// numeric classes this will be identical to the attribute output with
    /// 'outputClassification').
    /// </summary>    
    public AddClassification<T> OutputDistribution (bool value) {
      ((AddClassification)impl).setOutputDistribution(value);
      return this;
    }
    /// <summary>
    /// Whether to add an attribute indicating whether the classifier output a
    /// wrong classification (for numeric classes this is the numeric difference).
    /// </summary>    
    public AddClassification<T> OutputErrorFlag (bool value) {
      ((AddClassification)impl).setOutputErrorFlag(value);
      return this;
    }
    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public AddClassification<T> Debug (bool value) {
      ((AddClassification)impl).setDebug(value);
      return this;
    }
        
  }
}