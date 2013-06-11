using weka.core;
using weka.clusterers;

namespace Ml2.Clstr
{
  /// <summary>
  /// Class for running an arbitrary clusterer on data that has been passed
  /// through an arbitrary filter. Like the clusterer, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their structure.
  /// </summary>
  public class Filtered<T> : BaseClusterer<T>
  {    
    public Filtered(Runtime<T> rt) : base(rt, new FilteredClusterer()) {}

            

        
  }
}