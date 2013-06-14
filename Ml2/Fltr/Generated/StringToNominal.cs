using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Converts a range of string attributes (unspecified number of values) to
  /// nominal (set number of values). You should ensure that all string values
  /// that will appear are represented in the first batch of the
  /// data.<br/><br/>Options:<br/><br/>-R &lt;col&gt; = 	Sets the range of attribute indices
  /// (default last).<br/>-V &lt;col&gt; = 	Invert the range specified by -R.
  /// </summary>
  public class StringToNominal<T> : BaseFilter<T, StringToNominal> where T : new()
  {
    public StringToNominal(Runtime<T> rt) : base(rt, new StringToNominal()) {}

    /// <summary>
    /// Sets which attributes to process. This attributes must be string
    /// attributes ("first" and "last" are valid values as well as ranges and lists)
    /// </summary>    
    public StringToNominal<T> AttributeRange (params int[] attributes) {
      ((StringToNominal)Impl).setAttributeRange(System.String.Join(",", attributes.Select(a => a + 1)));
      return this;
    }

        
        
  }
}