using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// Discretizes numeric attributes using equal frequency binning, where the
  /// number of bins is equal to the square root of the number of non-missing
  /// values. For more information, see: Ying Yang, Geoffrey I. Webb: Proportional
  /// k-Interval Discretization for Naive-Bayes Classifiers. In: 12th European
  /// Conference on Machine Learning, 564-575, 2001.
  /// </summary>
  public class PKIDiscretize<T> : BaseFilter<T>
  {
    public PKIDiscretize(Runtime<T> rt) : base(rt, new PKIDiscretize()) {}

    /// <summary>
    /// 
    /// </summary>    
    public PKIDiscretize<T> InputFormat (Runtime<T> value) {
      ((PKIDiscretize)Impl).setInputFormat(value.Instances);
      return this;
    }

    /// <summary>
    /// Ignored.
    /// </summary>    
    public PKIDiscretize<T> FindNumBins (bool value) {
      ((PKIDiscretize)Impl).setFindNumBins(value);
      return this;
    }

    /// <summary>
    /// Always true.
    /// </summary>    
    public PKIDiscretize<T> UseEqualFrequency (bool value) {
      ((PKIDiscretize)Impl).setUseEqualFrequency(value);
      return this;
    }

    /// <summary>
    /// Ignored.
    /// </summary>    
    public PKIDiscretize<T> Bins (int value) {
      ((PKIDiscretize)Impl).setBins(value);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public PKIDiscretize<T> AttributeIndices (string value) {
      ((PKIDiscretize)Impl).setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected (numeric)
    /// attributes in the range will be discretized; if true, only non-selected attributes
    /// will be discretized.
    /// </summary>    
    public PKIDiscretize<T> InvertSelection (bool value) {
      ((PKIDiscretize)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// Make resulting attributes binary.
    /// </summary>    
    public PKIDiscretize<T> MakeBinary (bool value) {
      ((PKIDiscretize)Impl).setMakeBinary(value);
      return this;
    }

    /// <summary>
    /// Use bin numbers (eg BXofY) rather than ranges for for discretized
    /// attributes
    /// </summary>    
    public PKIDiscretize<T> UseBinNumbers (bool value) {
      ((PKIDiscretize)Impl).setUseBinNumbers(value);
      return this;
    }

    /// <summary>
    /// Sets the desired weight of instances per interval for equal-frequency
    /// binning.
    /// </summary>    
    public PKIDiscretize<T> DesiredWeightOfInstancesPerInterval (double value) {
      ((PKIDiscretize)Impl).setDesiredWeightOfInstancesPerInterval(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public PKIDiscretize<T> AttributeIndicesArray (int[] value) {
      ((PKIDiscretize)Impl).setAttributeIndicesArray(value);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public PKIDiscretize<T> IgnoreClass (bool value) {
      ((PKIDiscretize)Impl).setIgnoreClass(value);
      return this;
    }

        
        
  }
}