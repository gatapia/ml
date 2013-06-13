using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that copies a range of attributes in the dataset. This
  /// is used in conjunction with other filters that overwrite attribute values
  /// during the course of their operation -- this filter allows the original
  /// attributes to be kept as well as the new attributes.
  /// </summary>
  public class Copy<T> : BaseFilter<T, Copy> where T : new()
  {
    public Copy(Runtime<T> rt) : base(rt, new Copy()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public Copy<T> AttributeIndices (string rangeList) {
      ((Copy)Impl).setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Sets copy selected vs unselected action. If set to false, only the
    /// specified attributes will be copied; If set to true, non-specified attributes
    /// will be copied.
    /// </summary>    
    public Copy<T> InvertSelection (bool invert) {
      ((Copy)Impl).setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Copy<T> InputFormat (Runtime<T> instanceInfo) {
      ((Copy)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Copy<T> AttributeIndicesArray (int[] attributes) {
      ((Copy)Impl).setAttributeIndicesArray(attributes);
      return this;
    }

        
        
  }
}