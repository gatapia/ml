using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Class for running an arbitrary clusterer on data that has been passed
  /// through an arbitrary filter. Like the clusterer, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their structure.
  /// </summary>
  public class Filtered<T> : BaseClusterer<T, FilteredClusterer> where T : new()
  {    
    public Filtered(Runtime<T> rt) : base(rt, new FilteredClusterer()) {}

    /// <summary>
    /// The filter to be used.
    /// </summary>    
    public Filtered<T> Filter (Fltr.BaseFilter<T, weka.filters.Filter> filter) {
      ((FilteredClusterer)Impl).setFilter(filter.Impl);
      return this;
    }

    /// <summary>
    /// The base clusterer to be used.
    /// </summary>    
    public Filtered<T> Clusterer (Clstr.BaseClusterer<T, weka.clusterers.Clusterer> value) {
      ((FilteredClusterer)Impl).setClusterer(value.Impl);
      return this;
    }

            

        
  }
}