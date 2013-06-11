using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// This filter is used for renaming attribute names. Regular expressions can
  /// be used in the matching and replacing. See Javadoc of
  /// java.util.regex.Pattern class for more information:
  /// http://java.sun.com/javase/6/docs/api/java/util/regex/Pattern.html
  /// </summary>
  public class RenameAttribute<T> : BaseFilter<T>
  {
    public RenameAttribute(Runtime<T> rt) : base(rt, new RenameAttribute()) {}

    /// <summary>
    /// The regular expression that the attribute names must match.
    /// </summary>    
    public RenameAttribute<T> Find (string value) {
      ((RenameAttribute)impl).setFind(value);
      return this;
    }

    /// <summary>
    /// The regular expression to use for replacing the matching attribute names
    /// with.
    /// </summary>    
    public RenameAttribute<T> Replace (string value) {
      ((RenameAttribute)impl).setReplace(value);
      return this;
    }

    /// <summary>
    /// If set to true, then all occurrences of the match will be replaced;
    /// otherwise only the first.
    /// </summary>    
    public RenameAttribute<T> ReplaceAll (bool value) {
      ((RenameAttribute)impl).setReplaceAll(value);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on; this is a comma separated list of
    /// attribute indices, with "first" and "last" valid values; specify an
    /// inclusive range with "-"; eg: "first-3,5,6-10,last".
    /// </summary>    
    public RenameAttribute<T> AttributeIndices (string value) {
      ((RenameAttribute)impl).setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// If set to true, the selection will be inverted; eg: the attribute indices
    /// '2-4' then mean everything apart from '2-4'.
    /// </summary>    
    public RenameAttribute<T> InvertSelection (bool value) {
      ((RenameAttribute)impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public RenameAttribute<T> Debug (bool value) {
      ((RenameAttribute)impl).setDebug(value);
      return this;
    }

        
        
  }
}