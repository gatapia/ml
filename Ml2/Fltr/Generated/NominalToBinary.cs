using weka.core;
using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Converts all nominal attributes into binary numeric attributes. An
  /// attribute with k values is transformed into k binary attributes if the class is
  /// nominal (using the one-attribute-per-value approach). Binary attributes are
  /// left binary, if option '-A' is not given.If the class is numeric, you might
  /// want to use the supervised version of this filter.
  /// </summary>
  public class NominalToBinary<T> : BaseFilter<T>
  {
    public NominalToBinary(Runtime<T> rt) : base(rt, new NominalToBinary()) {}

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public NominalToBinary<T> AttributeIndices (string value) {
      ((weka.filters.unsupervised.attribute.NominalToBinary)impl).setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// Whether resulting binary attributes will be nominal.
    /// </summary>    
    public NominalToBinary<T> BinaryAttributesNominal (bool value) {
      ((weka.filters.unsupervised.attribute.NominalToBinary)impl).setBinaryAttributesNominal(value);
      return this;
    }

    /// <summary>
    /// Whether all nominal values are turned into new attributes, not only if
    /// there are more than 2.
    /// </summary>    
    public NominalToBinary<T> TransformAllValues (bool value) {
      ((weka.filters.unsupervised.attribute.NominalToBinary)impl).setTransformAllValues(value);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected (numeric)
    /// attributes in the range will be discretized; if true, only non-selected attributes
    /// will be discretized.
    /// </summary>    
    public NominalToBinary<T> InvertSelection (bool value) {
      ((weka.filters.unsupervised.attribute.NominalToBinary)impl).setInvertSelection(value);
      return this;
    }

        
        
  }
}