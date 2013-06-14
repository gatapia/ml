using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that 'cleanses' the numeric data from values that are too small,
  /// too big or very close to a certain value (e.g., 0) and sets these values
  /// to a pre-defined default.<br/><br/>Options:<br/><br/>-D = 	Turns on output
  /// of debugging information.<br/>-min &lt;double&gt; = 	The minimum threshold.
  /// (default -Double.MAX_VALUE)<br/>-min-default &lt;double&gt; = 	The
  /// replacement for values smaller than the minimum threshold.<br/>	(default
  /// -Double.MAX_VALUE)<br/>-max &lt;double&gt; = 	The maximum threshold. (default
  /// Double.MAX_VALUE)<br/>-max-default &lt;double&gt; = 	The replacement for values
  /// larger than the maximum threshold.<br/>	(default
  /// Double.MAX_VALUE)<br/>-closeto &lt;double&gt; = 	The number values are checked for closeness. (default
  /// 0)<br/>-closeto-default &lt;double&gt; = 	The replacement for values that
  /// are close to '-closeto'.<br/>	(default 0)<br/>-closeto-tolerance
  /// &lt;double&gt; = 	The tolerance below which numbers are considered being close to
  /// <br/>	to each other. (default 1E-6)<br/>-decimals &lt;int&gt; = 	The number of
  /// decimals to round to, -1 means no rounding at all.<br/>	(default -1)<br/>-R
  /// &lt;col1,col2,...&gt; = 	The list of columns to cleanse, e.g., first-last
  /// or first-3,5-last.<br/>	(default first-last)<br/>-V = 	Inverts the matching
  /// sense.<br/>-include-class = 	Whether to include the class in the
  /// cleansing.<br/>	The class column will always be skipped, if this flag is
  /// not<br/>	present. (default no)
  /// </summary>
  public class NumericCleaner<T> : BaseFilter<T, NumericCleaner> where T : new()
  {
    public NumericCleaner(Runtime<T> rt) : base(rt, new NumericCleaner()) {}

    /// <summary>
    /// The minimum threshold below values are replaced by a default.
    /// </summary>    
    public NumericCleaner<T> MinThreshold (double value) {
      ((NumericCleaner)Impl).setMinThreshold(value);
      return this;
    }

    /// <summary>
    /// The default value to replace values that are below the minimum threshold.
    /// </summary>    
    public NumericCleaner<T> MinDefault (double value) {
      ((NumericCleaner)Impl).setMinDefault(value);
      return this;
    }

    /// <summary>
    /// The maximum threshold above values are replaced by a default.
    /// </summary>    
    public NumericCleaner<T> MaxThreshold (double value) {
      ((NumericCleaner)Impl).setMaxThreshold(value);
      return this;
    }

    /// <summary>
    /// The default value to replace values that are above the maximum threshold.
    /// </summary>    
    public NumericCleaner<T> MaxDefault (double value) {
      ((NumericCleaner)Impl).setMaxDefault(value);
      return this;
    }

    /// <summary>
    /// The number values are checked for whether they are too close to and get
    /// replaced by a default.
    /// </summary>    
    public NumericCleaner<T> CloseTo (double value) {
      ((NumericCleaner)Impl).setCloseTo(value);
      return this;
    }

    /// <summary>
    /// The default value to replace values with that are too close.
    /// </summary>    
    public NumericCleaner<T> CloseToDefault (double value) {
      ((NumericCleaner)Impl).setCloseToDefault(value);
      return this;
    }

    /// <summary>
    /// The value below which values are considered close to.
    /// </summary>    
    public NumericCleaner<T> CloseToTolerance (double value) {
      ((NumericCleaner)Impl).setCloseToTolerance(value);
      return this;
    }

    /// <summary>
    /// The selection of columns to use in the cleansing processs, first and last
    /// are valid indices.
    /// </summary>    
    public NumericCleaner<T> AttributeIndices (string value) {
      ((NumericCleaner)Impl).setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// If enabled the selection of the columns is inverted.
    /// </summary>    
    public NumericCleaner<T> InvertSelection (bool value) {
      ((NumericCleaner)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// If disabled, the class attribute will be always left out of the cleaning
    /// process.
    /// </summary>    
    public NumericCleaner<T> IncludeClass (bool value) {
      ((NumericCleaner)Impl).setIncludeClass(value);
      return this;
    }

    /// <summary>
    /// The number of decimals to round to, -1 means no rounding at all.
    /// </summary>    
    public NumericCleaner<T> Decimals (int value) {
      ((NumericCleaner)Impl).setDecimals(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public NumericCleaner<T> Debug (bool value) {
      ((NumericCleaner)Impl).setDebug(value);
      return this;
    }

        
        
  }
}