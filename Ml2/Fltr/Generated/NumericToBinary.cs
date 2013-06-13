using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Converts all numeric attributes into binary attributes (apart from the
  /// class attribute, if set): if the value of the numeric attribute is exactly
  /// zero, the value of the new attribute will be zero. If the value of the
  /// numeric attribute is missing, the value of the new attribute will be missing.
  /// Otherwise, the value of the new attribute will be one. The new attributes will
  /// be nominal.
  /// </summary>
  public class NumericToBinary<T> : BaseFilter<T, NumericToBinary>
  {
    public NumericToBinary(Runtime<T> rt) : base(rt, new NumericToBinary()) {}

    /// <summary>
    /// 
    /// </summary>    
    public NumericToBinary<T> InputFormat (Runtime<T> instanceInfo) {
      ((NumericToBinary)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public NumericToBinary<T> IgnoreClass (bool newIgnoreClass) {
      ((NumericToBinary)Impl).setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}