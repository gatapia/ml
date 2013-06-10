using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Adds the labels from the given list to an attribute if they are missing.
  /// The labels can also be sorted in an ascending manner. If no labels are
  /// provided then only the (optional) sorting applies.
  /// </summary>
  public class AddValues<T> : BaseFilter<T>
  {
    public AddValues(Runtime<T> rt) : base(rt, new AddValues()) {}

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public AddValues<T> AttributeIndex (string value) {
      ((AddValues)impl).setAttributeIndex(value);
      return this;
    }
    /// <summary>
    /// Comma-separated list of lables to add.
    /// </summary>    
    public AddValues<T> Labels (string value) {
      ((AddValues)impl).setLabels(value);
      return this;
    }
    /// <summary>
    /// Whether to sort the labels alphabetically.
    /// </summary>    
    public AddValues<T> Sort (bool value) {
      ((AddValues)impl).setSort(value);
      return this;
    }
        
  }
}