using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Filter that can set and unset the class index.
  /// </summary>
  public class ClassAssigner<T> : BaseFilter<T, ClassAssigner> where T : new()
  {
    public ClassAssigner(Runtime<T> rt) : base(rt, new ClassAssigner()) {}

    /// <summary>
    /// The index of the class attribute, starts with 1, 'first' and 'last' are
    /// accepted as well, '0' unsets the class index.
    /// </summary>    
    public ClassAssigner<T> ClassIndex (string value) {
      ((ClassAssigner)Impl).setClassIndex(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public ClassAssigner<T> Debug (bool value) {
      ((ClassAssigner)Impl).setDebug(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public ClassAssigner<T> InputFormat (Runtime<T> instanceInfo) {
      ((ClassAssigner)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}