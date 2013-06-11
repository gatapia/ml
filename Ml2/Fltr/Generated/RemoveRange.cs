using weka.core;
using weka.filters.unsupervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that removes a given range of instances of a dataset.
  /// </summary>
  public class RemoveRange<T> : BaseFilter<T>
  {
    public RemoveRange(Runtime<T> rt) : base(rt, new RemoveRange()) {}

    /// <summary>
    /// The range of instances to select. First and last are valid indexes.
    /// </summary>    
    public RemoveRange<T> InstancesIndices (string value) {
      ((weka.filters.unsupervised.instance.RemoveRange)impl).setInstancesIndices(value);
      return this;
    }

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public RemoveRange<T> InvertSelection (bool value) {
      ((weka.filters.unsupervised.instance.RemoveRange)impl).setInvertSelection(value);
      return this;
    }

        
        
  }
}