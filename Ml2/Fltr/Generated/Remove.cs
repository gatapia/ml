using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that removes a range of attributes from the dataset. Will
  /// re-order the remaining attributes if invert matching sense is turned on and the
  /// attribute column indices are not specified in ascending order.
  /// </summary>
  public class Remove<T> : BaseFilter<T>
  {
    public Remove(Runtime<T> rt) : base(rt, new Remove()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public Remove<T> AttributeIndices (string value) {
      ((Remove)impl).setAttributeIndices(value);
      return this;
    }
    /// <summary>
    /// Determines whether action is to select or delete. If set to true, only
    /// the specified attributes will be kept; If set to false, specified attributes
    /// will be deleted.
    /// </summary>    
    public Remove<T> InvertSelection (bool value) {
      ((Remove)impl).setInvertSelection(value);
      return this;
    }
        
  }
}