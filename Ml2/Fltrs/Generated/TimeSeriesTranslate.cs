using weka.filters.unsupervised.attribute;

namespace Ml2.Fltrs
{
  /// <summary>
  /// An instance filter that assumes instances form time-series data and
  /// replaces attribute values in the current instance with the equivalent attribute
  /// values of some previous (or future) instance. For instances where the
  /// desired value is unknown either the instance may be dropped, or missing values
  /// used. Skips the class attribute if it is set.
  /// </summary>
  public class TimeSeriesTranslate<T> : BaseFilter<T>
  {
    public TimeSeriesTranslate(Runtime<T> rt) : base(rt, new TimeSeriesTranslate()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public TimeSeriesTranslate<T> AttributeIndices (string value) {
      ((TimeSeriesTranslate)impl).setAttributeIndices(value);
      return this;
    }
    /// <summary>
    /// Invert matching sense. ie calculate for all non-specified columns.
    /// </summary>    
    public TimeSeriesTranslate<T> InvertSelection (bool value) {
      ((TimeSeriesTranslate)impl).setInvertSelection(value);
      return this;
    }
    /// <summary>
    /// For instances at the beginning or end of the dataset where the translated
    /// values are not known, use missing values (default is to remove those
    /// instances)
    /// </summary>    
    public TimeSeriesTranslate<T> FillWithMissing (bool value) {
      ((TimeSeriesTranslate)impl).setFillWithMissing(value);
      return this;
    }
    /// <summary>
    /// The number of instances forward/backward to merge values between. A
    /// negative number indicates taking values from a past instance.
    /// </summary>    
    public TimeSeriesTranslate<T> InstanceRange (int value) {
      ((TimeSeriesTranslate)impl).setInstanceRange(value);
      return this;
    }
        
  }
}