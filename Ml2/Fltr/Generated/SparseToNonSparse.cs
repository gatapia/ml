using weka.core;
using weka.filters.unsupervised.instance;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that converts all incoming sparse instances into
  /// non-sparse format.
  /// </summary>
  public class SparseToNonSparse<T> : BaseFilter<T>
  {
    public SparseToNonSparse(Runtime<T> rt) : base(rt, new SparseToNonSparse()) {}

    /// <summary>
    /// 
    /// </summary>    
    public SparseToNonSparse<T> InputFormat (Runtime<T> value) {
      ((SparseToNonSparse)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}