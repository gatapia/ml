using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that assumes instances form time-series data and
  /// replaces attribute values in the current instance with the difference between
  /// the current value and the equivalent attribute attribute value of some
  /// previous (or future) instance. For instances where the time-shifted value is
  /// unknown either the instance may be dropped, or missing values used. Skips the
  /// class attribute if it is set.
  /// </summary>
  public class TimeSeriesDelta<T> : BaseFilter<T>
  {
    public TimeSeriesDelta(Runtime<T> rt) : base(rt, new TimeSeriesDelta()) {}

    /// <summary>
    /// 
    /// </summary>    
    public TimeSeriesDelta<T> InputFormat (Runtime<T> value) {
      ((TimeSeriesDelta)Impl).setInputFormat(value.Instances);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public TimeSeriesDelta<T> AttributeIndices (string value) {
      ((TimeSeriesDelta)Impl).setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// Invert matching sense. ie calculate for all non-specified columns.
    /// </summary>    
    public TimeSeriesDelta<T> InvertSelection (bool value) {
      ((TimeSeriesDelta)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// For instances at the beginning or end of the dataset where the translated
    /// values are not known, use missing values (default is to remove those
    /// instances)
    /// </summary>    
    public TimeSeriesDelta<T> FillWithMissing (bool value) {
      ((TimeSeriesDelta)Impl).setFillWithMissing(value);
      return this;
    }

    /// <summary>
    /// The number of instances forward/backward to merge values between. A
    /// negative number indicates taking values from a past instance.
    /// </summary>    
    public TimeSeriesDelta<T> InstanceRange (int value) {
      ((TimeSeriesDelta)Impl).setInstanceRange(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public TimeSeriesDelta<T> AttributeIndicesArray (int[] value) {
      ((TimeSeriesDelta)Impl).setAttributeIndicesArray(value);
      return this;
    }

        
        
  }
}