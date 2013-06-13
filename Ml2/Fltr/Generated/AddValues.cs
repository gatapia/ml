using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Adds the labels from the given list to an attribute if they are missing.
  /// The labels can also be sorted in an ascending manner. If no labels are
  /// provided then only the (optional) sorting applies.
  /// </summary>
  public class AddValues<T> : BaseFilter<T, AddValues>
  {
    public AddValues(Runtime<T> rt) : base(rt, new AddValues()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public AddValues<T> AttributeIndex (string attIndex) {
      ((AddValues)Impl).setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// Comma-separated list of lables to add.
    /// </summary>    
    public AddValues<T> Labels (string value) {
      ((AddValues)Impl).setLabels(value);
      return this;
    }

    /// <summary>
    /// Whether to sort the labels alphabetically.
    /// </summary>    
    public AddValues<T> Sort (bool value) {
      ((AddValues)Impl).setSort(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public AddValues<T> InputFormat (Runtime<T> instanceInfo) {
      ((AddValues)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}