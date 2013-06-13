using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that converts all incoming sparse instances into
  /// non-sparse format.
  /// </summary>
  public class SparseToNonSparse<T> : BaseFilter<T, SparseToNonSparse>
  {
    public SparseToNonSparse(Runtime<T> rt) : base(rt, new SparseToNonSparse()) {}

    /// <summary>
    /// 
    /// </summary>    
    public SparseToNonSparse<T> InputFormat (Runtime<T> instanceInfo) {
      ((SparseToNonSparse)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}