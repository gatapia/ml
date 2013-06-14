using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Adds the labels from the given list to an attribute if they are missing.
  /// The labels can also be sorted in an ascending manner. If no labels are
  /// provided then only the (optional) sorting
  /// applies.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index<br/>	(default last).<br/>-L
  /// &lt;label1,label2,...&gt; = 	Comma-separated list of labels to
  /// add.<br/>	(default: none)<br/>-S = 	Turns on the sorting of the labels.
  /// </summary>
  public class AddValues<T> : BaseFilter<T, AddValues> where T : new()
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

        
        
  }
}