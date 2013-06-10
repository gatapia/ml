using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that generates output with a new order of the attributes. Useful
  /// if one wants to move an attribute to the end to use it as class attribute
  /// (e.g. with using "-R 2-last,1"). But it's not only possible to change the
  /// order of all the attributes, but also to leave out attributes. E.g. if you
  /// have 10 attributes, you can generate the following output order:
  /// 1,3,5,7,9,10 or 10,1-5. You can also duplicate attributes, e.g. for further processing
  /// later on: e.g. 1,1,1,4,4,4,2,2,2 where the second and the third column of
  /// each attribute are processed differently and the first one, i.e. the
  /// original one is kept. One can simply inverse the order of the attributes via
  /// 'last-first'. After appyling the filter, the index of the class attribute is
  /// the last attribute.
  /// </summary>
  public class Reorder<T> : BaseFilter<T>
  {
    public Reorder(Runtime<T> rt) : base(rt, new Reorder()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public Reorder<T> AttributeIndices (string value) {
      ((Reorder)impl).setAttributeIndices(value);
      return this;
    }
        
  }
}