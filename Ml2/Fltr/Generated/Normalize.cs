using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Normalizes all numeric values in the given dataset (apart from the class
  /// attribute, if set). The resulting values are by default in [0,1] for the
  /// data used to compute the normalization intervals. But with the scale and
  /// translation parameters one can change that, e.g., with scale = 2.0 and
  /// translation = -1.0 you get values in the range [-1,+1].
  /// </summary>
  public class Normalize<T> : BaseFilter<T, Normalize>
  {
    public Normalize(Runtime<T> rt) : base(rt, new Normalize()) {}

    /// <summary>
    /// 
    /// </summary>    
    public Normalize<T> InputFormat (Runtime<T> instanceInfo) {
      ((Normalize)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// The factor for scaling the output range (default: 1).
    /// </summary>    
    public Normalize<T> Scale (double value) {
      ((Normalize)Impl).setScale(value);
      return this;
    }

    /// <summary>
    /// The translation of the output range (default: 0).
    /// </summary>    
    public Normalize<T> Translation (double value) {
      ((Normalize)Impl).setTranslation(value);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Normalize<T> IgnoreClass (bool newIgnoreClass) {
      ((Normalize)Impl).setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}