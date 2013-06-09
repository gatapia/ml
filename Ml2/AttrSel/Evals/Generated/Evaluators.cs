using weka.core;

namespace Ml2.AttrSel.Evals
{
  public class Evaluators
  {
    /// <summary>
    /// CfsSubsetEval : Evaluates the worth of a subset of attributes by
    /// considering the individual predictive ability of each feature along with the degree
    /// of redundancy between them. Subsets of features that are highly correlated
    /// with the class while having low intercorrelation are preferred. For more
    /// information see: M. A. Hall (1998). Correlation-based Feature Subset
    /// Selection for Machine Learning. Hamilton, New Zealand.
    /// </summary>
    public CfsSubset CfsSubset() { return new CfsSubset(); }

    /// <summary>
    /// CorrelationAttributeEval : Evaluates the worth of an attribute by
    /// measuring the correlation (Pearson's) between it and the class. Nominal attributes
    /// are considered on a value by value basis by treating each value as an
    /// indicator. An overall correlation for a nominal attribute is arrived at via a
    /// weighted average.
    /// </summary>
    public CorrelationAttribute CorrelationAttribute() { return new CorrelationAttribute(); }

    /// <summary>
    /// GainRatioAttributeEval : Evaluates the worth of an attribute by measuring
    /// the gain ratio with respect to the class. GainR(Class, Attribute) =
    /// (H(Class) - H(Class | Attribute)) / H(Attribute).
    /// </summary>
    public GainRatioAttribute GainRatioAttribute() { return new GainRatioAttribute(); }

    /// <summary>
    /// InfoGainAttributeEval : Evaluates the worth of an attribute by measuring
    /// the information gain with respect to the class. InfoGain(Class,Attribute) =
    /// H(Class) - H(Class | Attribute).
    /// </summary>
    public InfoGainAttribute InfoGainAttribute() { return new InfoGainAttribute(); }

    /// <summary>
    /// OneRAttributeEval : Evaluates the worth of an attribute by using the OneR
    /// classifier.
    /// </summary>
    public OneRAttribute OneRAttribute() { return new OneRAttribute(); }

    /// <summary>
    /// Performs a principal components analysis and transformation of the data.
    /// Use in conjunction with a Ranker search. Dimensionality reduction is
    /// accomplished by choosing enough eigenvectors to account for some percentage of
    /// the variance in the original data---default 0.95 (95%). Attribute noise can
    /// be filtered by transforming to the PC space, eliminating some of the worst
    /// eigenvectors, and then transforming back to the original space.
    /// </summary>
    public PrincipalComponents PrincipalComponents() { return new PrincipalComponents(); }

    /// <summary>
    /// ReliefFAttributeEval : Evaluates the worth of an attribute by repeatedly
    /// sampling an instance and considering the value of the given attribute for
    /// the nearest instance of the same and different class. Can operate on both
    /// discrete and continuous class data. For more information see: Kenji Kira,
    /// Larry A. Rendell: A Practical Approach to Feature Selection. In: Ninth
    /// International Workshop on Machine Learning, 249-256, 1992. Igor Kononenko:
    /// Estimating Attributes: Analysis and Extensions of RELIEF. In: European Conference
    /// on Machine Learning, 171-182, 1994. Marko Robnik-Sikonja, Igor Kononenko:
    /// An adaptation of Relief for attribute estimation in regression. In:
    /// Fourteenth International Conference on Machine Learning, 296-304, 1997.
    /// </summary>
    public ReliefFAttribute ReliefFAttribute() { return new ReliefFAttribute(); }

    /// <summary>
    /// SymmetricalUncertAttributeEval : Evaluates the worth of an attribute by
    /// measuring the symmetrical uncertainty with respect to the class.
    /// SymmU(Class, Attribute) = 2 * (H(Class) - H(Class | Attribute)) / H(Class) +
    /// H(Attribute).
    /// </summary>
    public SymmetricalUncertAttribute SymmetricalUncertAttribute() { return new SymmetricalUncertAttribute(); }

    /// <summary>
    /// WrapperSubsetEval: Evaluates attribute sets by using a learning scheme.
    /// Cross validation is used to estimate the accuracy of the learning scheme for
    /// a set of attributes. For more information see: Ron Kohavi, George H. John
    /// (1997). Wrappers for feature subset selection. Artificial Intelligence.
    /// 97(1-2):273-324.
    /// </summary>
    public WrapperSubset WrapperSubset() { return new WrapperSubset(); }

    
  }
}