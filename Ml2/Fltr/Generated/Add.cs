using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
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
      ((weka.filters.unsupervised.attribute.Add)impl).setAttributeName(value);
      return this;
    }

    /// <summary>
    /// The list of value labels (nominal attribute creation only). The list must
    /// be comma-separated, eg: "red,green,blue". If this is empty, the created
    /// attribute will be numeric.
    /// </summary>    
    public Add<T> NominalLabels (string value) {
      ((weka.filters.unsupervised.attribute.Add)impl).setNominalLabels(value);
      return this;
    }

    /// <summary>
    /// Defines the type of the attribute to generate.
    /// </summary>    
    public Add<T> AttributeType (EAttributeType value) {
      ((weka.filters.unsupervised.attribute.Add)impl).setAttributeType(new SelectedTag((int) value, weka.filters.unsupervised.attribute.Add.TAGS_TYPE));
      return this;
    }

    /// <summary>
    /// The position (starting from 1) where the attribute will be inserted
    /// (first and last are valid indices).
    /// </summary>    
    public Add<T> AttributeIndex (string value) {
      ((weka.filters.unsupervised.attribute.Add)impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// The format of the date values (see ISO-8601).
    /// </summary>    
    public Add<T> DateFormat (string value) {
      ((weka.filters.unsupervised.attribute.Add)impl).setDateFormat(value);
      return this;
    }

        
    public enum EAttributeType {
      Numeric_attribute = 0,
      Nominal_attribute = 1,
      String_attribute = 2,
      Date_attribute = 3
    }

        
  }
}