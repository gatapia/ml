using weka.filters.unsupervised.instance;

namespace Ml2.Fltrs
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
    public NonSparseToSparse<T> TreatMissingValuesAsZero (bool value) {
      ((NonSparseToSparse)impl).setTreatMissingValuesAsZero(value);
      return this;
    }
    /// <summary>
    /// Insert a dummy value before the first declared value for all nominal
    /// attributes. Useful when converting market basket data that has been encoded for
    /// Apriori to sparse format. Typically used in conjuction with treat missing
    /// values as zero.
    /// </summary>    
    public NonSparseToSparse<T> InsertDummyNominalFirstValue (bool value) {
      ((NonSparseToSparse)impl).setInsertDummyNominalFirstValue(value);
      return this;
    }
        
  }
}