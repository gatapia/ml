using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Filter that can set and unset the class
  /// index.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-C
  /// &lt;num|first|last|0&gt; = 	The index of the class attribute. Index starts with 1,
  /// 'first'<br/>	and 'last' are accepted, '0' unsets the class index.<br/>	(default: last)
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

        
        
  }
}