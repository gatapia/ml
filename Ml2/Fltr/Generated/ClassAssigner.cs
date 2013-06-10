using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Filter that can set and unset the class index.
  /// </summary>
  public class ClassAssigner<T> : BaseFilter<T>
  {
    public ClassAssigner(Runtime<T> rt) : base(rt, new ClassAssigner()) {}

    /// <summary>
    /// The index of the class attribute, starts with 1, 'first' and 'last' are
    /// accepted as well, '0' unsets the class index.
    /// </summary>    
    public ClassAssigner<T> ClassIndex (string value) {
      ((ClassAssigner)impl).setClassIndex(value);
      return this;
    }
    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public ClassAssigner<T> Debug (bool value) {
      ((ClassAssigner)impl).setDebug(value);
      return this;
    }
        
  }
}