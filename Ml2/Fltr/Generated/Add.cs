using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that adds a new attribute to the dataset. The new
  /// attribute will contain all missing values.
  /// </summary>
  public class Add<T> : BaseFilter<T, Add> where T : new()
  {
    public Add(Runtime<T> rt) : base(rt, new Add()) {}

    /// <summary>
    /// Set the new attribute's name.
    /// </summary>    
    public Add<T> AttributeName (string name) {
      ((Add)Impl).setAttributeName(name);
      return this;
    }

    /// <summary>
    /// The list of value labels (nominal attribute creation only). The list must
    /// be comma-separated, eg: "red,green,blue". If this is empty, the created
    /// attribute will be numeric.
    /// </summary>    
    public Add<T> NominalLabels (string labelList) {
      ((Add)Impl).setNominalLabels(labelList);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Add<T> InputFormat (Runtime<T> instanceInfo) {
      ((Add)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// Defines the type of the attribute to generate.
    /// </summary>    
    public Add<T> AttributeType (EAttributeType value) {
      ((Add)Impl).setAttributeType(new weka.core.SelectedTag((int) value, Add.TAGS_TYPE));
      return this;
    }

    /// <summary>
    /// The position (starting from 1) where the attribute will be inserted
    /// (first and last are valid indices).
    /// </summary>    
    public Add<T> AttributeIndex (string attIndex) {
      ((Add)Impl).setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The format of the date values (see ISO-8601).
    /// </summary>    
    public Add<T> DateFormat (string value) {
      ((Add)Impl).setDateFormat(value);
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