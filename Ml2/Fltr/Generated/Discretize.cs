using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that discretizes a range of numeric attributes in the
  /// dataset into nominal attributes. Discretization is by simple binning. Skips
  /// the class attribute if
  /// set.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before the filter
  /// is<br/>	applied to the data.<br/>	(default: no)<br/>-B &lt;num&gt; = 	Specifies the
  /// (maximum) number of bins to divide numeric attributes into.<br/>	(default =
  /// 10)<br/>-M &lt;num&gt; = 	Specifies the desired weight of instances per bin
  /// for<br/>	equal-frequency binning. If this is set to a positive<br/>	number
  /// then the -B option will be ignored.<br/>	(default = -1)<br/>-F = 	Use
  /// equal-frequency instead of equal-width discretization.<br/>-O = 	Optimize number
  /// of bins using leave-one-out estimate<br/>	of estimated entropy (for
  /// equal-width discretization).<br/>	If this is set then the -B option will be
  /// ignored.<br/>-R &lt;col1,col2-col4,...&gt; = 	Specifies list of columns to
  /// Discretize. First and last are valid indexes.<br/>	(default: first-last)<br/>-V =
  /// 	Invert matching sense of column indexes.<br/>-D = 	Output binary
  /// attributes for discretized attributes.<br/>-Y = 	Use bin numbers rather than ranges
  /// for discretized attributes.
  /// </summary>
  public class Discretize<T> : BaseFilter<T, Discretize> where T : new()
  {
    public Discretize(Runtime<T> rt) : base(rt, new Discretize()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public Discretize<T> AttributeIndices (string rangeList) {
      ((Discretize)Impl).setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Number of bins.
    /// </summary>    
    public Discretize<T> Bins (int numBins) {
      ((Discretize)Impl).setBins(numBins);
      return this;
    }

    /// <summary>
    /// If set to true, equal-frequency binning will be used instead of
    /// equal-width binning.
    /// </summary>    
    public Discretize<T> UseEqualFrequency (bool newUseEqualFrequency) {
      ((Discretize)Impl).setUseEqualFrequency(newUseEqualFrequency);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected (numeric)
    /// attributes in the range will be discretized; if true, only non-selected attributes
    /// will be discretized.
    /// </summary>    
    public Discretize<T> InvertSelection (bool invert) {
      ((Discretize)Impl).setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Make resulting attributes binary.
    /// </summary>    
    public Discretize<T> MakeBinary (bool makeBinary) {
      ((Discretize)Impl).setMakeBinary(makeBinary);
      return this;
    }

    /// <summary>
    /// Use bin numbers (eg BXofY) rather than ranges for for discretized
    /// attributes
    /// </summary>    
    public Discretize<T> UseBinNumbers (bool useBinNumbers) {
      ((Discretize)Impl).setUseBinNumbers(useBinNumbers);
      return this;
    }

    /// <summary>
    /// Optimize number of equal-width bins using leave-one-out. Doesn't work for
    /// equal-frequency binning
    /// </summary>    
    public Discretize<T> FindNumBins (bool newFindNumBins) {
      ((Discretize)Impl).setFindNumBins(newFindNumBins);
      return this;
    }

    /// <summary>
    /// Sets the desired weight of instances per interval for equal-frequency
    /// binning.
    /// </summary>    
    public Discretize<T> DesiredWeightOfInstancesPerInterval (double newDesiredNumber) {
      ((Discretize)Impl).setDesiredWeightOfInstancesPerInterval(newDesiredNumber);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Discretize<T> AttributeIndicesArray (int[] attributes) {
      ((Discretize)Impl).setAttributeIndicesArray(attributes);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Discretize<T> IgnoreClass (bool newIgnoreClass) {
      ((Discretize)Impl).setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}