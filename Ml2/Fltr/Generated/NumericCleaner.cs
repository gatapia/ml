using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr.Generated
{
  /// <summary>
  /// A filter that 'cleanses' the numeric data from values that are too small,
  /// too big or very close to a certain value (e.g., 0) and sets these values
  /// to a pre-defined default.
  /// </summary>
  public class NumericCleaner<T> : BaseFilter<T>
  {
    public NumericCleaner(Runtime<T> rt) : base(rt, new NumericCleaner()) {}

    /// <summary>
    /// The minimum threshold below values are replaced by a default.
    /// </summary>    
    public NumericCleaner<T> MinThreshold (double value) {
      ((NumericCleaner)impl).setMinThreshold(value);
      return this;
    }
    /// <summary>
    /// The default value to replace values that are below the minimum threshold.
    /// </summary>    
    public NumericCleaner<T> MinDefault (double value) {
      ((NumericCleaner)impl).setMinDefault(value);
      return this;
    }
    /// <summary>
    /// The maximum threshold above values are replaced by a default.
    /// </summary>    
    public NumericCleaner<T> MaxThreshold (double value) {
      ((NumericCleaner)impl).setMaxThreshold(value);
      return this;
    }
    /// <summary>
    /// The default value to replace values that are above the maximum threshold.
    /// </summary>    
    public NumericCleaner<T> MaxDefault (double value) {
      ((NumericCleaner)impl).setMaxDefault(value);
      return this;
    }
    /// <summary>
    /// The number values are checked for whether they are too close to and get
    /// replaced by a default.
    /// </summary>    
    public NumericCleaner<T> CloseTo (double value) {
      ((NumericCleaner)impl).setCloseTo(value);
      return this;
    }
    /// <summary>
    /// The default value to replace values with that are too close.
    /// </summary>    
    public NumericCleaner<T> CloseToDefault (double value) {
      ((NumericCleaner)impl).setCloseToDefault(value);
      return this;
    }
    /// <summary>
    /// The value below which values are considered close to.
    /// </summary>    
    public NumericCleaner<T> CloseToTolerance (double value) {
      ((NumericCleaner)impl).setCloseToTolerance(value);
      return this;
    }
    /// <summary>
    /// The selection of columns to use in the cleansing processs, first and last
    /// are valid indices.
    /// </summary>    
    public NumericCleaner<T> AttributeIndices (string value) {
      ((NumericCleaner)impl).setAttributeIndices(value);
      return this;
    }
    /// <summary>
    /// If enabled the selection of the columns is inverted.
    /// </summary>    
    public NumericCleaner<T> InvertSelection (bool value) {
      ((NumericCleaner)impl).setInvertSelection(value);
      return this;
    }
    /// <summary>
    /// If disabled, the class attribute will be always left out of the cleaning
    /// process.
    /// </summary>    
    public NumericCleaner<T> IncludeClass (bool value) {
      ((NumericCleaner)impl).setIncludeClass(value);
      return this;
    }
    /// <summary>
    /// The number of decimals to round to, -1 means no rounding at all.
    /// </summary>    
    public NumericCleaner<T> Decimals (int value) {
      ((NumericCleaner)impl).setDecimals(value);
      return this;
    }
    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public NumericCleaner<T> Debug (bool value) {
      ((NumericCleaner)impl).setDebug(value);
      return this;
    }
        
  }
}