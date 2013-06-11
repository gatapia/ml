using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Changes the date format used by a date attribute. This is most useful for
  /// converting to a format with less precision, for example, from an absolute
  /// date to day of year, etc. This changes the format string, and changes the
  /// date values to those that would be parsed by the new format.
  /// </summary>
  public class ChangeDateFormat<T> : BaseFilter<T>
  {
    public ChangeDateFormat(Runtime<T> rt) : base(rt, new ChangeDateFormat()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be of type date
    /// ("first" and "last" are valid values)
    /// </summary>    
    public ChangeDateFormat<T> AttributeIndex (string value) {
      ((weka.filters.unsupervised.attribute.ChangeDateFormat)impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// The date format to change to. This should be a format understood by
    /// Java's SimpleDateFormat class.
    /// </summary>    
    public ChangeDateFormat<T> DateFormat (string value) {
      ((weka.filters.unsupervised.attribute.ChangeDateFormat)impl).setDateFormat(value);
      return this;
    }

        
        
  }
}