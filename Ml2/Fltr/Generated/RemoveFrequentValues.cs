using weka.core;
using weka.filters.unsupervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// Determines which values (frequent or infrequent ones) of an (nominal)
  /// attribute are retained and filters the instances accordingly. In case of
  /// values with the same frequency, they are kept in the way they appear in the
  /// original instances object. E.g. if you have the values "1,2,3,4" with the
  /// frequencies "10,5,5,3" and you chose to keep the 2 most common values, the
  /// values "1,2" would be returned, since the value "2" comes before "3", even
  /// though they have the same frequency.
  /// </summary>
  public class RemoveFrequentValues<T> : BaseFilter<T>
  {
    public RemoveFrequentValues(Runtime<T> rt) : base(rt, new RemoveFrequentValues()) {}

    /// <summary>
    /// Choose attribute to be used for selection (default last).
    /// </summary>    
    public RemoveFrequentValues<T> AttributeIndex (string value) {
      ((weka.filters.unsupervised.instance.RemoveFrequentValues)impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// The number of values to retain.
    /// </summary>    
    public RemoveFrequentValues<T> NumValues (int value) {
      ((weka.filters.unsupervised.instance.RemoveFrequentValues)impl).setNumValues(value);
      return this;
    }

    /// <summary>
    /// Retains values with least instance instead of most.
    /// </summary>    
    public RemoveFrequentValues<T> UseLeastValues (bool value) {
      ((weka.filters.unsupervised.instance.RemoveFrequentValues)impl).setUseLeastValues(value);
      return this;
    }

    /// <summary>
    /// When selecting on nominal attributes, removes header references to
    /// excluded values.
    /// </summary>    
    public RemoveFrequentValues<T> ModifyHeader (bool value) {
      ((weka.filters.unsupervised.instance.RemoveFrequentValues)impl).setModifyHeader(value);
      return this;
    }

    /// <summary>
    /// Invert matching sense.
    /// </summary>    
    public RemoveFrequentValues<T> InvertSelection (bool value) {
      ((weka.filters.unsupervised.instance.RemoveFrequentValues)impl).setInvertSelection(value);
      return this;
    }

        
        
  }
}