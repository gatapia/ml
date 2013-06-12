using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// This instance filter takes a range of N numeric attributes and replaces
  /// them with N-1 numeric attributes, the values of which are the difference
  /// between consecutive attribute values from the original instance. eg: Original
  /// attribute values 0.1, 0.2, 0.3, 0.1, 0.3 New attribute values 0.1, 0.1,
  /// -0.2, 0.2 The range of attributes used is taken in numeric order. That is, a
  /// range spec of 7-11,3-5 will use the attribute ordering 3,4,5,7,8,9,10,11 for
  /// the differences, NOT 7,8,9,10,11,3,4,5.
  /// </summary>
  public class FirstOrder<T> : BaseFilter<T>
  {
    public FirstOrder(Runtime<T> rt) : base(rt, new FirstOrder()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public FirstOrder<T> AttributeIndices (string rangeList) {
      ((FirstOrder)Impl).setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public FirstOrder<T> InputFormat (Runtime<T> instanceInfo) {
      ((FirstOrder)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public FirstOrder<T> AttributeIndicesArray (int[] attributes) {
      ((FirstOrder)Impl).setAttributeIndicesArray(attributes);
      return this;
    }

        
        
  }
}