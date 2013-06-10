using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr.Generated
{
  /// <summary>
  /// An instance filter that adds a new attribute to the dataset. The new
  /// attribute will contain all missing values.
  /// </summary>
  public class Add<T> : BaseFilter<T>
  {
    public Add(Runtime<T> rt) : base(rt, new Add()) {}

    /// <summary>
    /// Set the new attribute's name.
    /// </summary>    
    public Add<T> AttributeName (string value) {
      ((Add)impl).setAttributeName(value);
      return this;
    }
    /// <summary>
    /// The list of value labels (nominal attribute creation only). The list must
    /// be comma-separated, eg: "red,green,blue". If this is empty, the created
    /// attribute will be numeric.
    /// </summary>    
    public Add<T> NominalLabels (string value) {
      ((Add)impl).setNominalLabels(value);
      return this;
    }
    /// <summary>
    /// The position (starting from 1) where the attribute will be inserted
    /// (first and last are valid indices).
    /// </summary>    
    public Add<T> AttributeIndex (string value) {
      ((Add)impl).setAttributeIndex(value);
      return this;
    }
    /// <summary>
    /// The format of the date values (see ISO-8601).
    /// </summary>    
    public Add<T> DateFormat (string value) {
      ((Add)impl).setDateFormat(value);
      return this;
    }
        
  }
}