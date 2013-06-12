using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that adds an ID attribute to the dataset. The new
  /// attribute contains a unique ID for each instance. Note: The ID is not reset for
  /// the second batch of files (using -b and -r and -s).
  /// </summary>
  public class AddID<T> : BaseFilter<T>
  {
    public AddID(Runtime<T> rt) : base(rt, new AddID()) {}

    /// <summary>
    /// 
    /// </summary>    
    public AddID<T> InputFormat (Runtime<T> instanceInfo) {
      ((AddID)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// Set the new attribute's name.
    /// </summary>    
    public AddID<T> AttributeName (string value) {
      ((AddID)Impl).setAttributeName(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public AddID<T> IDIndex (string value) {
      ((AddID)Impl).setIDIndex(value);
      return this;
    }

        
        
  }
}