using weka.core;
using weka.filters.unsupervised.instance;
using System.Linq;

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
      ((RemovePercentage)Impl).setPercentage(value);
      return this;
    }

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public RemovePercentage<T> InvertSelection (bool value) {
      ((RemovePercentage)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public RemovePercentage<T> InputFormat (Runtime<T> value) {
      ((RemovePercentage)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}