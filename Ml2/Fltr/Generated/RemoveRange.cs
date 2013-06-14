using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that removes a given range of instances of a
  /// dataset.<br/><br/>Options:<br/><br/>-R &lt;inst1,inst2-inst4,...&gt; = 	Specifies list of
  /// instances to select. First and last<br/>	are valid indexes.
  /// (required)<br/><br/>-V = 	Specifies if inverse of selection is to be output.<br/>
  /// </summary>
  public class RemoveRange<T> : BaseFilter<T, RemoveRange> where T : new()
  {
    public RemoveRange(Runtime<T> rt) : base(rt, new RemoveRange()) {}

    /// <summary>
    /// The range of instances to select. First and last are valid indexes.
    /// </summary>    
    public RemoveRange<T> InstancesIndices (string rangeList) {
      ((RemoveRange)Impl).setInstancesIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public RemoveRange<T> InvertSelection (bool inverse) {
      ((RemoveRange)Impl).setInvertSelection(inverse);
      return this;
    }

        
        
  }
}