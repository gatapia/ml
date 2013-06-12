using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
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
    /// 
    /// </summary>    
    public TimeSeriesTranslate<T> InputFormat (Runtime<T> instanceInfo) {
      ((TimeSeriesTranslate)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public TimeSeriesTranslate<T> AttributeIndices (string rangeList) {
      ((TimeSeriesTranslate)Impl).setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Invert matching sense. ie calculate for all non-specified columns.
    /// </summary>    
    public TimeSeriesTranslate<T> InvertSelection (bool invert) {
      ((TimeSeriesTranslate)Impl).setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// For instances at the beginning or end of the dataset where the translated
    /// values are not known, use missing values (default is to remove those
    /// instances)
    /// </summary>    
    public TimeSeriesTranslate<T> FillWithMissing (bool newFillWithMissing) {
      ((TimeSeriesTranslate)Impl).setFillWithMissing(newFillWithMissing);
      return this;
    }

    /// <summary>
    /// The number of instances forward/backward to merge values between. A
    /// negative number indicates taking values from a past instance.
    /// </summary>    
    public TimeSeriesTranslate<T> InstanceRange (int newInstanceRange) {
      ((TimeSeriesTranslate)Impl).setInstanceRange(newInstanceRange);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public TimeSeriesTranslate<T> AttributeIndicesArray (int[] attributes) {
      ((TimeSeriesTranslate)Impl).setAttributeIndicesArray(attributes);
      return this;
    }

        
        
  }
}