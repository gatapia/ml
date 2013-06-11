using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Converts a range of string attributes (unspecified number of values) to
  /// nominal (set number of values). You should ensure that all string values
  /// that will appear are represented in the first batch of the data.
  /// </summary>
  public class StringToNominal<T> : BaseFilter<T>
  {
    public StringToNominal(Runtime<T> rt) : base(rt, new StringToNominal()) {}

    /// <summary>
    /// Sets which attributes to process. This attributes must be string
    /// attributes ("first" and "last" are valid values as well as ranges and lists)
    /// </summary>    
    public StringToNominal<T> AttributeRange (string value) {
      ((weka.filters.unsupervised.attribute.StringToNominal)impl).setAttributeRange(value);
      return this;
    }

        
        
  }
}