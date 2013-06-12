using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
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
      ((InterquartileRange)Impl).setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// The factor for determining the thresholds for outliers.
    /// </summary>    
    public InterquartileRange<T> OutlierFactor (double value) {
      ((InterquartileRange)Impl).setOutlierFactor(value);
      return this;
    }

    /// <summary>
    /// The factor for determining the thresholds for extreme values.
    /// </summary>    
    public InterquartileRange<T> ExtremeValuesFactor (double value) {
      ((InterquartileRange)Impl).setExtremeValuesFactor(value);
      return this;
    }

    /// <summary>
    /// Whether to tag extreme values also as outliers.
    /// </summary>    
    public InterquartileRange<T> ExtremeValuesAsOutliers (bool value) {
      ((InterquartileRange)Impl).setExtremeValuesAsOutliers(value);
      return this;
    }

    /// <summary>
    /// Generates Outlier/ExtremeValue attribute pair for each numeric attribute,
    /// not just a single pair for all numeric attributes together.
    /// </summary>    
    public InterquartileRange<T> DetectionPerAttribute (bool value) {
      ((InterquartileRange)Impl).setDetectionPerAttribute(value);
      return this;
    }

    /// <summary>
    /// Generates an additional attribute 'Offset' that contains the multiplier
    /// the value is off the median: value = median + 'multiplier' * IQR
    /// </summary>    
    public InterquartileRange<T> OutputOffsetMultiplier (bool value) {
      ((InterquartileRange)Impl).setOutputOffsetMultiplier(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InterquartileRange<T> AttributeIndicesArray (int[] value) {
      ((InterquartileRange)Impl).setAttributeIndicesArray(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public InterquartileRange<T> Debug (bool value) {
      ((InterquartileRange)Impl).setDebug(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InterquartileRange<T> InputFormat (Runtime<T> instanceInfo) {
      ((InterquartileRange)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}