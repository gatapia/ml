using weka.core;
using weka.filters.unsupervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that removes a given percentage of a dataset.
  /// </summary>
  public class RemovePercentage<T> : BaseFilter<T>
  {
    public RemovePercentage(Runtime<T> rt) : base(rt, new RemovePercentage()) {}

    /// <summary>
    /// The percentage of the data to select.
    /// </summary>    
    public RemovePercentage<T> Percentage (double value) {
      ((weka.filters.unsupervised.instance.RemovePercentage)impl).setPercentage(value);
      return this;
    }

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public RemovePercentage<T> InvertSelection (bool value) {
      ((weka.filters.unsupervised.instance.RemovePercentage)impl).setInvertSelection(value);
      return this;
    }

        
        
  }
}