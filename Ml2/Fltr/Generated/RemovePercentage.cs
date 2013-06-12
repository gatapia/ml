using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
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
    public RemovePercentage<T> Percentage (double percent) {
      ((RemovePercentage)Impl).setPercentage(percent);
      return this;
    }

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public RemovePercentage<T> InvertSelection (bool inverse) {
      ((RemovePercentage)Impl).setInvertSelection(inverse);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public RemovePercentage<T> InputFormat (Runtime<T> instanceInfo) {
      ((RemovePercentage)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}