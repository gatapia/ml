using weka.core;
using weka.associations;

// ReSharper disable once CheckNamespace
namespace Ml2.Asstn
{
  /// <summary>
  /// Class for running an arbitrary associator on data that has been passed
  /// through an arbitrary filter. Like the associator, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their structure.
  /// </summary>
  public class FilteredAssociator<T> : BaseAssociation<T, FilteredAssociator> where T : new()
  {
    public FilteredAssociator(Runtime<T> rt) : base(rt, new FilteredAssociator()) {}

    /// <summary>
    /// The filter to be used.
    /// </summary>    
    public FilteredAssociator<T> Filter (Fltr.BaseFilter<T, weka.filters.Filter> value) {
      ((FilteredAssociator)Impl).setFilter(value.Impl);
      return this;
    }    

    /// <summary>
    /// Index of the class attribute. If set to -1, the last attribute is taken
    /// as class attribute.
    /// </summary>    
    public FilteredAssociator<T> ClassIndex (int value) {
      ((FilteredAssociator)Impl).setClassIndex(value);
      return this;
    }    

    /// <summary>
    /// The base associator to be used.
    /// </summary>    
    public FilteredAssociator<T> Associator (Asstn.BaseAssociation<T, weka.associations.AbstractAssociator> value) {
      ((FilteredAssociator)Impl).setAssociator(value.Impl);
      return this;
    }    

          
        
  }
}