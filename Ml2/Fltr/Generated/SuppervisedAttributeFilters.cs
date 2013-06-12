// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  public class SuppervisedAttributeFilters<T>
  {
    private readonly Runtime<T> rt;    
    public SuppervisedAttributeFilters(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// A filter for adding the classification, the class distribution and an
    /// error flag to a dataset with a classifier. The classifier is either trained on
    /// the data itself or provided as serialized model.
    /// </summary>
    public AddClassification<T> AddClassification() { return new AddClassification<T>(rt); }

    /// <summary>
    /// A supervised attribute filter that can be used to select attributes. It
    /// is very flexible and allows various search and evaluation methods to be
    /// combined.
    /// </summary>
    public AttributeSelection<T> AttributeSelection() { return new AttributeSelection<T>(rt); }

    /// <summary>
    /// Changes the order of the classes so that the class values are no longer
    /// of in the order specified in the header. The values will be in the order
    /// specified by the user -- it could be either in ascending/descending order by
    /// the class frequency or in random order. Note that this filter currently does
    /// not change the header, only the class values of the instances, so there is
    /// not much point in using it in conjunction with the FilteredClassifier. The
    /// value can also be converted back using 'originalValue(double value)'
    /// procedure.
    /// </summary>
    public ClassOrder<T> ClassOrder() { return new ClassOrder<T>(rt); }

    /// <summary>
    /// An instance filter that discretizes a range of numeric attributes in the
    /// dataset into nominal attributes. Discretization is by Fayyad & Irani's MDL
    /// method (the default). For more information, see: Usama M. Fayyad, Keki B.
    /// Irani: Multi-interval discretization of continuousvalued attributes for
    /// classification learning. In: Thirteenth International Joint Conference on
    /// Articial Intelligence, 1022-1027, 1993. Igor Kononenko: On Biases in Estimating
    /// Multi-Valued Attributes. In: 14th International Joint Conference on
    /// Articial Intelligence, 1034-1040, 1995.
    /// </summary>
    public Discretize<T> Discretize() { return new Discretize<T>(rt); }

    /// <summary>
    /// Converts all nominal attributes into binary numeric attributes. An
    /// attribute with k values is transformed into k binary attributes if the class is
    /// nominal (using the one-attribute-per-value approach). Binary attributes are
    /// left binary, if option '-A' is not given.If the class is numeric, k - 1 new
    /// binary attributes are generated in the manner described in "Classification
    /// and Regression Trees" by Breiman et al. (i.e. taking the average class
    /// value associated with each attribute value into account) For more information,
    /// see: L. Breiman, J.H. Friedman, R.A. Olshen, C.J. Stone (1984).
    /// Classification and Regression Trees. Wadsworth Inc.
    /// </summary>
    public NominalToBinary<T> NominalToBinary() { return new NominalToBinary<T>(rt); }

    
  }
}