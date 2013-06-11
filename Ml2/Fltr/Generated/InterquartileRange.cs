using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter for detecting outliers and extreme values based on interquartile
  /// ranges. The filter skips the class attribute. Outliers: Q3 + OF*IQR < x <=
  /// Q3 + EVF*IQR or Q1 - EVF*IQR <= x < Q1 - OF*IQR Extreme values: x > Q3 +
  /// EVF*IQR or x < Q1 - EVF*IQR Key: Q1 = 25% quartile Q3 = 75% quartile IQR =
  /// Interquartile Range, difference between Q1 and Q3 OF = Outlier Factor EVF =
  /// Extreme Value Factor
  /// </summary>
  public class InterquartileRange<T> : BaseFilter<T>
  {
    public InterquartileRange(Runtime<T> rt) : base(rt, new InterquartileRange()) {}

    /// <summary>
    /// Specify range of attributes to act on; this is a comma separated list of
    /// attribute indices, with "first" and "last" valid values; specify an
    /// inclusive range with "-", eg: "first-3,5,6-10,last".
    /// </summary>    
    public InterquartileRange<T> AttributeIndices (string value) {
      ((weka.filters.unsupervised.attribute.InterquartileRange)impl).setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// The factor for determining the thresholds for outliers.
    /// </summary>    
    public InterquartileRange<T> OutlierFactor (double value) {
      ((weka.filters.unsupervised.attribute.InterquartileRange)impl).setOutlierFactor(value);
      return this;
    }

    /// <summary>
    /// The factor for determining the thresholds for extreme values.
    /// </summary>    
    public InterquartileRange<T> ExtremeValuesFactor (double value) {
      ((weka.filters.unsupervised.attribute.InterquartileRange)impl).setExtremeValuesFactor(value);
      return this;
    }

    /// <summary>
    /// Whether to tag extreme values also as outliers.
    /// </summary>    
    public InterquartileRange<T> ExtremeValuesAsOutliers (bool value) {
      ((weka.filters.unsupervised.attribute.InterquartileRange)impl).setExtremeValuesAsOutliers(value);
      return this;
    }

    /// <summary>
    /// Generates Outlier/ExtremeValue attribute pair for each numeric attribute,
    /// not just a single pair for all numeric attributes together.
    /// </summary>    
    public InterquartileRange<T> DetectionPerAttribute (bool value) {
      ((weka.filters.unsupervised.attribute.InterquartileRange)impl).setDetectionPerAttribute(value);
      return this;
    }

    /// <summary>
    /// Generates an additional attribute 'Offset' that contains the multiplier
    /// the value is off the median: value = median + 'multiplier' * IQR
    /// </summary>    
    public InterquartileRange<T> OutputOffsetMultiplier (bool value) {
      ((weka.filters.unsupervised.attribute.InterquartileRange)impl).setOutputOffsetMultiplier(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public InterquartileRange<T> Debug (bool value) {
      ((weka.filters.unsupervised.attribute.InterquartileRange)impl).setDebug(value);
      return this;
    }

        
        
  }
}