using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter for turning numeric attributes into nominal ones. Unlike
  /// discretization, it just takes all numeric values and adds them to the list of
  /// nominal values of that attribute. Useful after CSV imports, to enforce certain
  /// attributes to become nominal, e.g., the class attribute, containing values
  /// from 1 to 5.
  /// </summary>
  public class NumericToNominal<T> : BaseFilter<T>
  {
    public NumericToNominal(Runtime<T> rt) : base(rt, new NumericToNominal()) {}

    /// <summary>
    /// Set attribute selection mode. If false, only selected (numeric)
    /// attributes in the range will be 'nominalized'; if true, only non-selected attributes
    /// will be 'nominalized'.
    /// </summary>    
    public NumericToNominal<T> InvertSelection (bool value) {
      ((NumericToNominal)impl).setInvertSelection(value);
      return this;
    }
    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public NumericToNominal<T> AttributeIndices (string value) {
      ((NumericToNominal)impl).setAttributeIndices(value);
      return this;
    }
    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public NumericToNominal<T> Debug (bool value) {
      ((NumericToNominal)impl).setDebug(value);
      return this;
    }
        
  }
}