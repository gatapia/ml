using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// Replaces all missing values for nominal, string, numeric and date
  /// attributes in the dataset with user-supplied constant values.
  /// </summary>
  public class ReplaceMissingWithUserConstant<T> : BaseFilter<T>
  {
    public ReplaceMissingWithUserConstant(Runtime<T> rt) : base(rt, new ReplaceMissingWithUserConstant()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last". Can alternatively specify a
    /// comma separated list of attribute names. Note that you can't mix indices
    /// and attribute names in the same list
    /// </summary>    
    public ReplaceMissingWithUserConstant<T> Attributes (string value) {
      ((ReplaceMissingWithUserConstant)impl).setAttributes(value);
      return this;
    }
    /// <summary>
    /// The constant to replace missing values in nominal/string attributes with
    /// </summary>    
    public ReplaceMissingWithUserConstant<T> NominalStringReplacementValue (string value) {
      ((ReplaceMissingWithUserConstant)impl).setNominalStringReplacementValue(value);
      return this;
    }
    /// <summary>
    /// The constant to replace missing values in numeric attributes with
    /// </summary>    
    public ReplaceMissingWithUserConstant<T> NumericReplacementValue (string value) {
      ((ReplaceMissingWithUserConstant)impl).setNumericReplacementValue(value);
      return this;
    }
    /// <summary>
    /// The constant to replace missing values in date attributes with
    /// </summary>    
    public ReplaceMissingWithUserConstant<T> DateReplacementValue (string value) {
      ((ReplaceMissingWithUserConstant)impl).setDateReplacementValue(value);
      return this;
    }
    /// <summary>
    /// The formatting string to use for parsing the date replacement value
    /// </summary>    
    public ReplaceMissingWithUserConstant<T> DateFormat (string value) {
      ((ReplaceMissingWithUserConstant)impl).setDateFormat(value);
      return this;
    }
    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public ReplaceMissingWithUserConstant<T> IgnoreClass (bool value) {
      ((ReplaceMissingWithUserConstant)impl).setIgnoreClass(value);
      return this;
    }
        
  }
}