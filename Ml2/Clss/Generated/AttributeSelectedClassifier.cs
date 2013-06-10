using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// Dimensionality of training and test data is reduced by attribute
  /// selection before being passed on to a classifier.
  /// </summary>
  public class AttributeSelectedClassifier<T> : BaseClassifier<T>
  {
    public AttributeSelectedClassifier(Runtime<T> rt) : base(rt, new AttributeSelectedClassifier()) {}

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AttributeSelectedClassifier<T> Debug (bool value) {
      ((AttributeSelectedClassifier)impl).setDebug(value);
      return this;
    }

        
  }
}