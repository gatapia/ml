using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
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

    /// <summary>
    /// The type of attribute to remove.
    /// </summary>    
    public RemoveType<T> AttributeType (EAttributeType value) {
      ((RemoveType)impl).setAttributeType(new SelectedTag((int) value, RemoveType.TAGS_ATTRIBUTETYPE));
      return this;
    }

        
    public enum EAttributeType {
      Delete_nominal_attributes = 1,
      Delete_numeric_attributes = 0,
      Delete_string_attributes = 2,
      Delete_date_attributes = 3,
      Delete_relational_attributes = 4
    }

        
  }
}