using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Removes attributes of a given type.<br/><br/>Options:<br/><br/>-T
  /// &lt;nominal|numeric|string|date|relational&gt; = 	Attribute type to delete. Valid
  /// options are "nominal", <br/>	"numeric", "string", "date" and
  /// "relational".<br/>	(default "string")<br/>-V = 	Invert matching sense (i.e. only keep
  /// specified columns)
  /// </summary>
  public class RemoveType<T> : BaseFilter<T, RemoveType> where T : new()
  {
    public RemoveType(Runtime<T> rt) : base(rt, new RemoveType()) {}

    /// <summary>
    /// Determines whether action is to select or delete. If set to true, only
    /// the specified attributes will be kept; If set to false, specified attributes
    /// will be deleted.
    /// </summary>    
    public RemoveType<T> InvertSelection (bool invert) {
      ((RemoveType)Impl).setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// The type of attribute to remove.
    /// </summary>    
    public RemoveType<T> AttributeType (EAttributeType type) {
      ((RemoveType)Impl).setAttributeType(new weka.core.SelectedTag((int) type, RemoveType.TAGS_ATTRIBUTETYPE));
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