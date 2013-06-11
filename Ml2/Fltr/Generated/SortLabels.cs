using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A simple filter for sorting the labels of nominal attributes.
  /// </summary>
  public class SortLabels<T> : BaseFilter<T>
  {
    public SortLabels(Runtime<T> rt) : base(rt, new SortLabels()) {}

    /// <summary>
    /// Specify range of attributes to act on; this is a comma separated list of
    /// attribute indices, with "first" and "last" valid values; Specify an
    /// inclusive range with "-"; eg: "first-3,5,6-10,last".
    /// </summary>    
    public SortLabels<T> AttributeIndices (string value) {
      ((weka.filters.unsupervised.attribute.SortLabels)impl).setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected attributes in the
    /// range will be worked on; if true, only non-selected attributes will be
    /// processed.
    /// </summary>    
    public SortLabels<T> InvertSelection (bool value) {
      ((weka.filters.unsupervised.attribute.SortLabels)impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// The type of sorting to use.
    /// </summary>    
    public SortLabels<T> SortType (ESortType value) {
      ((weka.filters.unsupervised.attribute.SortLabels)impl).setSortType(new SelectedTag((int) value, weka.filters.unsupervised.attribute.SortLabels.TAGS_SORTTYPE));
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public SortLabels<T> Debug (bool value) {
      ((weka.filters.unsupervised.attribute.SortLabels)impl).setDebug(value);
      return this;
    }

        
    public enum ESortType {
      Case_sensitive = 0,
      Case_insensitive = 1
    }

        
  }
}