using weka.core;
using weka.associations;

namespace Ml2.Asstn
{
  /// <summary>
  /// Class for running an arbitrary associator on data that has been passed
  /// through an arbitrary filter. Like the associator, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their structure.
  /// </summary>
  public class FilteredAssociator<T> : BaseAssociation<T>
  {
    public FilteredAssociator(Runtime<T> rt) : base(rt, new FilteredAssociator()) {}

    /// <summary>
    /// Index of the class attribute. If set to -1, the last attribute is taken
    /// as class attribute.
    /// </summary>    
    public FilteredAssociator<T> ClassIndex (int value) {
      ((weka.associations.FilteredAssociator)impl).setClassIndex(value);
      return this;
    }

          
        
  }
}