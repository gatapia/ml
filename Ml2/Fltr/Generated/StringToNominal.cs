using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
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
    public StringToNominal<T> AttributeRange (string rangeList) {
      ((StringToNominal)Impl).setAttributeRange(rangeList);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToNominal<T> InputFormat (Runtime<T> instanceInfo) {
      ((StringToNominal)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}