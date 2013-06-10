using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Transforms numeric attributes using a given transformation method.
  /// </summary>
  public class NumericTransform<T> : BaseFilter<T>
  {
    public NumericTransform(Runtime<T> rt) : base(rt, new NumericTransform()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public NumericTransform<T> AttributeIndices (string value) {
      ((NumericTransform)impl).setAttributeIndices(value);
      return this;
    }
    /// <summary>
    /// Whether to process the inverse of the given attribute ranges.
    /// </summary>    
    public NumericTransform<T> InvertSelection (bool value) {
      ((NumericTransform)impl).setInvertSelection(value);
      return this;
    }
    /// <summary>
    /// Name of the class containing the method used for the transformation.
    /// </summary>    
    public NumericTransform<T> ClassName (string value) {
      ((NumericTransform)impl).setClassName(value);
      return this;
    }
    /// <summary>
    /// Name of the method used for the transformation.
    /// </summary>    
    public NumericTransform<T> MethodName (string value) {
      ((NumericTransform)impl).setMethodName(value);
      return this;
    }
        
  }
}