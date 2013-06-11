using weka.core;
using weka.filters.unsupervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that converts all incoming sparse instances into
  /// non-sparse format.
  /// </summary>
  public class SparseToNonSparse<T> : BaseFilter<T>
  {
    public SparseToNonSparse(Runtime<T> rt) : base(rt, new SparseToNonSparse()) {}

        
        
  }
}