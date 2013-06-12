using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that converts all incoming instances into sparse
  /// format.
  /// </summary>
  public class NonSparseToSparse<T> : BaseFilter<T>
  {
    public NonSparseToSparse(Runtime<T> rt) : base(rt, new NonSparseToSparse()) {}

    /// <summary>
    /// Treat missing values in the same way as zeros.
    /// </summary>    
    public NonSparseToSparse<T> TreatMissingValuesAsZero (bool m) {
      ((NonSparseToSparse)Impl).setTreatMissingValuesAsZero(m);
      return this;
    }

    /// <summary>
    /// Insert a dummy value before the first declared value for all nominal
    /// attributes. Useful when converting market basket data that has been encoded for
    /// Apriori to sparse format. Typically used in conjuction with treat missing
    /// values as zero.
    /// </summary>    
    public NonSparseToSparse<T> InsertDummyNominalFirstValue (bool d) {
      ((NonSparseToSparse)Impl).setInsertDummyNominalFirstValue(d);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public NonSparseToSparse<T> InputFormat (Runtime<T> instanceInfo) {
      ((NonSparseToSparse)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}