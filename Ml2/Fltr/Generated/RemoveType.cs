using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr.Generated
{
  /// <summary>
  /// Removes attributes of a given type.
  /// </summary>
  public class RemoveType<T> : BaseFilter<T>
  {
    public RemoveType(Runtime<T> rt) : base(rt, new RemoveType()) {}

    /// <summary>
    /// Determines whether action is to select or delete. If set to true, only
    /// the specified attributes will be kept; If set to false, specified attributes
    /// will be deleted.
    /// </summary>    
    public RemoveType<T> InvertSelection (bool value) {
      ((RemoveType)impl).setInvertSelection(value);
      return this;
    }
        
  }
}