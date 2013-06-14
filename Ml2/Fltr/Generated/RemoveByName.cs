using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Removes attributes based on a regular expression matched against their
  /// names.
  /// </summary>
  public class RemoveByName<T> : BaseFilter<T, RemoveByName> where T : new()
  {
    public RemoveByName(Runtime<T> rt) : base(rt, new RemoveByName()) {}

    /// <summary>
    /// The regular expression to match the attribute names against.
    /// </summary>    
    public RemoveByName<T> Expression (string value) {
      ((RemoveByName)Impl).setExpression(value);
      return this;
    }

    /// <summary>
    /// Determines whether action is to select or delete. If set to true, only
    /// the specified attributes will be kept; If set to false, specified attributes
    /// will be deleted.
    /// </summary>    
    public RemoveByName<T> InvertSelection (bool value) {
      ((RemoveByName)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public RemoveByName<T> Debug (bool value) {
      ((RemoveByName)Impl).setDebug(value);
      return this;
    }

        
        
  }
}