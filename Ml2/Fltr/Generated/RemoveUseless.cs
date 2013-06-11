using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// This filter removes attributes that do not vary at all or that vary too
  /// much. All constant attributes are deleted automatically, along with any that
  /// exceed the maximum percentage of variance parameter. The maximum variance
  /// test is only applied to nominal attributes.
  /// </summary>
  public class RemoveUseless<T> : BaseFilter<T>
  {
    public RemoveUseless(Runtime<T> rt) : base(rt, new RemoveUseless()) {}

    /// <summary>
    /// Set the threshold for the highest variance allowed before a nominal
    /// attribute will be deleted.Specifically, if (number_of_distinct_values /
    /// total_number_of_values * 100) is greater than this value then the attribute will be
    /// removed.
    /// </summary>    
    public RemoveUseless<T> MaximumVariancePercentageAllowed (double value) {
      ((RemoveUseless)impl).setMaximumVariancePercentageAllowed(value);
      return this;
    }

        
        
  }
}