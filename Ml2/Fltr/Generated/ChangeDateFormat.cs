using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Changes the date format used by a date attribute. This is most useful for
  /// converting to a format with less precision, for example, from an absolute
  /// date to day of year, etc. This changes the format string, and changes the
  /// date values to those that would be parsed by the new
  /// format.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index (default
  /// last).<br/>-F &lt;value index&gt; = 	Sets the output date format string (default
  /// corresponds to ISO-8601).
  /// </summary>
  public class ChangeDateFormat<T> : BaseFilter<T, ChangeDateFormat> where T : new()
  {
    public ChangeDateFormat(Runtime<T> rt) : base(rt, new ChangeDateFormat()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be of type date
    /// ("first" and "last" are valid values)
    /// </summary>    
    public ChangeDateFormat<T> AttributeIndex (string attIndex) {
      ((ChangeDateFormat)Impl).setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The date format to change to. This should be a format understood by
    /// Java's SimpleDateFormat class.
    /// </summary>    
    public ChangeDateFormat<T> DateFormat (string dateFormat) {
      ((ChangeDateFormat)Impl).setDateFormat(dateFormat);
      return this;
    }

        
        
  }
}