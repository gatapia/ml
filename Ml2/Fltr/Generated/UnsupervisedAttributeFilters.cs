// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  public class UnsupervisedAttributeFilters<T> where T : new()
  {
    private readonly Runtime<T> rt;    
    public UnsupervisedAttributeFilters(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// An instance filter that adds a new attribute to the dataset. The new
    /// attribute will contain all missing values.
    /// </summary>
    public Add<T> Add() { return new Add<T>(rt); }

    /// <summary>
    /// A filter that adds a new nominal attribute representing the cluster
    /// assigned to each instance by the specified clustering algorithm. Either the
    /// clustering algorithm gets built with the first batch of data or one specifies
    /// are serialized clusterer model file to use instead.
    /// </summary>
    public AddCluster<T> AddCluster() { return new AddCluster<T>(rt); }

    /// <summary>
    /// An instance filter that creates a new attribute by applying a
    /// mathematical expression to existing attributes. The expression can contain attribute
    /// references and numeric constants. Supported operators are : +, -, *, /, ^,
    /// log, abs, cos, exp, sqrt, floor, ceil, rint, tan, sin, (, ) Attributes are
    /// specified by prefixing with 'a', eg. a7 is attribute number 7 (starting from
    /// 1). Example expression : a1^2*a5/log(a7*4.0).
    /// </summary>
    public AddExpression<T> AddExpression() { return new AddExpression<T>(rt); }

    /// <summary>
    /// An instance filter that adds an ID attribute to the dataset. The new
    /// attribute contains a unique ID for each instance. Note: The ID is not reset for
    /// the second batch of files (using -b and -r and -s).
    /// </summary>
    public AddID<T> AddID() { return new AddID<T>(rt); }

    /// <summary>
    /// An instance filter that changes a percentage of a given attributes
    /// values. The attribute must be nominal. Missing value can be treated as value
    /// itself.
    /// </summary>
    public AddNoise<T> AddNoise() { return new AddNoise<T>(rt); }

    /// <summary>
    /// A filter that adds new attributes with user specified type and constant
    /// value. Numeric, nominal, string and date attributes can be created.
    /// Attribute name, and value can be set with environment variables. Date attributes
    /// can also specify a formatting string by which to parse the supplied date
    /// value. Alternatively, a current time stamp can be specified by supplying the
    /// special string "now" as the value for a date attribute.
    /// </summary>
    public AddUserFields<T> AddUserFields() { return new AddUserFields<T>(rt); }

    /// <summary>
    /// Adds the labels from the given list to an attribute if they are missing.
    /// The labels can also be sorted in an ascending manner. If no labels are
    /// provided then only the (optional) sorting applies.
    /// </summary>
    public AddValues<T> AddValues() { return new AddValues<T>(rt); }

    /// <summary>
    /// Centers all numeric attributes in the given dataset to have zero mean
    /// (apart from the class attribute, if set).
    /// </summary>
    public Center<T> Center() { return new Center<T>(rt); }

    /// <summary>
    /// Changes the date format used by a date attribute. This is most useful for
    /// converting to a format with less precision, for example, from an absolute
    /// date to day of year, etc. This changes the format string, and changes the
    /// date values to those that would be parsed by the new format.
    /// </summary>
    public ChangeDateFormat<T> ChangeDateFormat() { return new ChangeDateFormat<T>(rt); }

    /// <summary>
    /// Filter that can set and unset the class index.
    /// </summary>
    public ClassAssigner<T> ClassAssigner() { return new ClassAssigner<T>(rt); }

    /// <summary>
    /// A filter that uses a density-based clusterer to generate cluster
    /// membership values; filtered instances are composed of these values plus the class
    /// attribute (if set in the input data). If a (nominal) class attribute is set,
    /// the clusterer is run separately for each class. The class attribute (if
    /// set) and any user-specified attributes are ignored during the clustering
    /// operation
    /// </summary>
    public ClusterMembership<T> ClusterMembership() { return new ClusterMembership<T>(rt); }

    /// <summary>
    /// An instance filter that copies a range of attributes in the dataset. This
    /// is used in conjunction with other filters that overwrite attribute values
    /// during the course of their operation -- this filter allows the original
    /// attributes to be kept as well as the new attributes.
    /// </summary>
    public Copy<T> Copy() { return new Copy<T>(rt); }

    /// <summary>
    /// An instance filter that discretizes a range of numeric attributes in the
    /// dataset into nominal attributes. Discretization is by simple binning. Skips
    /// the class attribute if set.
    /// </summary>
    public Discretize<T> Discretize() { return new Discretize<T>(rt); }

    /// <summary>
    /// This instance filter takes a range of N numeric attributes and replaces
    /// them with N-1 numeric attributes, the values of which are the difference
    /// between consecutive attribute values from the original instance. eg: Original
    /// attribute values 0.1, 0.2, 0.3, 0.1, 0.3 New attribute values 0.1, 0.1,
    /// -0.2, 0.2 The range of attributes used is taken in numeric order. That is, a
    /// range spec of 7-11,3-5 will use the attribute ordering 3,4,5,7,8,9,10,11 for
    /// the differences, NOT 7,8,9,10,11,3,4,5.
    /// </summary>
    public FirstOrder<T> FirstOrder() { return new FirstOrder<T>(rt); }

    /// <summary>
    /// A filter for detecting outliers and extreme values based on interquartile
    /// ranges. The filter skips the class attribute. Outliers: Q3 + OF*IQR < x <=
    /// Q3 + EVF*IQR or Q1 - EVF*IQR <= x < Q1 - OF*IQR Extreme values: x > Q3 +
    /// EVF*IQR or x < Q1 - EVF*IQR Key: Q1 = 25% quartile Q3 = 75% quartile IQR =
    /// Interquartile Range, difference between Q1 and Q3 OF = Outlier Factor EVF =
    /// Extreme Value Factor
    /// </summary>
    public InterquartileRange<T> InterquartileRange() { return new InterquartileRange<T>(rt); }

    /// <summary>
    /// Converts the given set of predictor variables into a kernel matrix. The
    /// class value remains unchangedm, as long as the preprocessing filter doesn't
    /// change it. By default, the data is preprocessed with the Center filter, but
    /// the user can choose any filter (NB: one must be careful that the filter
    /// does not alter the class attribute unintentionally). With
    /// weka.filters.AllFilter the preprocessing gets disabled. For more information regarding
    /// preprocessing the data, see: K.P. Bennett, M.J. Embrechts: An Optimization
    /// Perspective on Kernel Partial Least Squares Regression. In: Advances in Learning
    /// Theory: Methods, Models and Applications, 227-249, 2003.
    /// </summary>
    public KernelFilter<T> KernelFilter() { return new KernelFilter<T>(rt); }

    /// <summary>
    /// A filter that creates a new dataset with a boolean attribute replacing a
    /// nominal attribute. In the new dataset, a value of 1 is assigned to an
    /// instance that exhibits a particular range of attribute values, a 0 to an
    /// instance that doesn't. The boolean attribute is coded as numeric by default.
    /// </summary>
    public MakeIndicator<T> MakeIndicator() { return new MakeIndicator<T>(rt); }

    /// <summary>
    /// Modify numeric attributes according to a given expression
    /// </summary>
    public MathExpression<T> MathExpression() { return new MathExpression<T>(rt); }

    /// <summary>
    /// Merges many values of a nominal attribute into one value.
    /// </summary>
    public MergeManyValues<T> MergeManyValues() { return new MergeManyValues<T>(rt); }

    /// <summary>
    /// Merges two values of a nominal attribute into one value.
    /// </summary>
    public MergeTwoValues<T> MergeTwoValues() { return new MergeTwoValues<T>(rt); }

    /// <summary>
    /// Converts all nominal attributes into binary numeric attributes. An
    /// attribute with k values is transformed into k binary attributes if the class is
    /// nominal (using the one-attribute-per-value approach). Binary attributes are
    /// left binary, if option '-A' is not given.If the class is numeric, you might
    /// want to use the supervised version of this filter.
    /// </summary>
    public NominalToBinary<T> NominalToBinary() { return new NominalToBinary<T>(rt); }

    /// <summary>
    /// Converts a nominal attribute (that is, a set number of values) to string
    /// (that is, an unspecified number of values).
    /// </summary>
    public NominalToString<T> NominalToString() { return new NominalToString<T>(rt); }

    /// <summary>
    /// Normalizes all numeric values in the given dataset (apart from the class
    /// attribute, if set). The resulting values are by default in [0,1] for the
    /// data used to compute the normalization intervals. But with the scale and
    /// translation parameters one can change that, e.g., with scale = 2.0 and
    /// translation = -1.0 you get values in the range [-1,+1].
    /// </summary>
    public Normalize<T> Normalize() { return new Normalize<T>(rt); }

    /// <summary>
    /// A filter that 'cleanses' the numeric data from values that are too small,
    /// too big or very close to a certain value (e.g., 0) and sets these values
    /// to a pre-defined default.
    /// </summary>
    public NumericCleaner<T> NumericCleaner() { return new NumericCleaner<T>(rt); }

    /// <summary>
    /// Converts all numeric attributes into binary attributes (apart from the
    /// class attribute, if set): if the value of the numeric attribute is exactly
    /// zero, the value of the new attribute will be zero. If the value of the
    /// numeric attribute is missing, the value of the new attribute will be missing.
    /// Otherwise, the value of the new attribute will be one. The new attributes will
    /// be nominal.
    /// </summary>
    public NumericToBinary<T> NumericToBinary() { return new NumericToBinary<T>(rt); }

    /// <summary>
    /// A filter for turning numeric attributes into nominal ones. Unlike
    /// discretization, it just takes all numeric values and adds them to the list of
    /// nominal values of that attribute. Useful after CSV imports, to enforce certain
    /// attributes to become nominal, e.g., the class attribute, containing values
    /// from 1 to 5.
    /// </summary>
    public NumericToNominal<T> NumericToNominal() { return new NumericToNominal<T>(rt); }

    /// <summary>
    /// Transforms numeric attributes using a given transformation method.
    /// </summary>
    public NumericTransform<T> NumericTransform() { return new NumericTransform<T>(rt); }

    /// <summary>
    /// A simple instance filter that renames the relation, all attribute names
    /// and all nominal (and string) attribute values. For exchanging sensitive
    /// datasets. Currently doesn't like string or relational attributes.
    /// </summary>
    public Obfuscate<T> Obfuscate() { return new Obfuscate<T>(rt); }

    /// <summary>
    /// Discretizes numeric attributes using equal frequency binning, where the
    /// number of bins is equal to the square root of the number of non-missing
    /// values. For more information, see: Ying Yang, Geoffrey I. Webb: Proportional
    /// k-Interval Discretization for Naive-Bayes Classifiers. In: 12th European
    /// Conference on Machine Learning, 564-575, 2001.
    /// </summary>
    public PKIDiscretize<T> PKIDiscretize() { return new PKIDiscretize<T>(rt); }

    /// <summary>
    /// A filter that uses a PartitionGenerator to generate partition membership
    /// values; filtered instances are composed of these values plus the class
    /// attribute (if set in the input data) and rendered as sparse instances.
    /// </summary>
    public PartitionMembership<T> PartitionMembership() { return new PartitionMembership<T>(rt); }

    /// <summary>
    /// A filter that applies filters on subsets of attributes and assembles the
    /// output into a new dataset. Attributes that are not covered by any of the
    /// ranges can be either retained or removed from the output.
    /// </summary>
    public PartitionedMultiFilter<T> PartitionedMultiFilter() { return new PartitionedMultiFilter<T>(rt); }

    /// <summary>
    /// Performs a principal components analysis and transformation of the data.
    /// Dimensionality reduction is accomplished by choosing enough eigenvectors to
    /// account for some percentage of the variance in the original data --
    /// default 0.95 (95%). Based on code of the attribute selection scheme
    /// 'PrincipalComponents' by Mark Hall and Gabi Schmidberger.
    /// </summary>
    public PrincipalComponents<T> PrincipalComponents() { return new PrincipalComponents<T>(rt); }

    /// <summary>
    /// Reduces the dimensionality of the data by projecting it onto a lower
    /// dimensional subspace using a random matrix with columns of unit length (i.e. It
    /// will reduce the number of attributes in the data while preserving much of
    /// its variation like PCA, but at a much less computational cost). It first
    /// applies the NominalToBinary filter to convert all attributes to numeric
    /// before reducing the dimension. It preserves the class attribute. For more
    /// information, see: Dmitriy Fradkin, David Madigan: Experiments with random
    /// projections for machine learning. In: KDD '03: Proceedings of the ninth ACM SIGKDD
    /// international conference on Knowledge discovery and data mining, New York,
    /// NY, USA, 517-522, 003.
    /// </summary>
    public RandomProjection<T> RandomProjection() { return new RandomProjection<T>(rt); }

    /// <summary>
    /// Chooses a random subset of attributes, either an absolute number or a
    /// percentage. The class is always included in the output (as the last
    /// attribute).
    /// </summary>
    public RandomSubset<T> RandomSubset() { return new RandomSubset<T>(rt); }

    /// <summary>
    /// A filter that removes a range of attributes from the dataset. Will
    /// re-order the remaining attributes if invert matching sense is turned on and the
    /// attribute column indices are not specified in ascending order.
    /// </summary>
    public Remove<T> Remove() { return new Remove<T>(rt); }

    /// <summary>
    /// Removes attributes based on a regular expression matched against their
    /// names.
    /// </summary>
    public RemoveByName<T> RemoveByName() { return new RemoveByName<T>(rt); }

    /// <summary>
    /// Removes attributes of a given type.
    /// </summary>
    public RemoveType<T> RemoveType() { return new RemoveType<T>(rt); }

    /// <summary>
    /// This filter removes attributes that do not vary at all or that vary too
    /// much. All constant attributes are deleted automatically, along with any that
    /// exceed the maximum percentage of variance parameter. The maximum variance
    /// test is only applied to nominal attributes.
    /// </summary>
    public RemoveUseless<T> RemoveUseless() { return new RemoveUseless<T>(rt); }

    /// <summary>
    /// This filter is used for renaming attribute names. Regular expressions can
    /// be used in the matching and replacing. See Javadoc of
    /// java.util.regex.Pattern class for more information:
    /// http://java.sun.com/javase/6/docs/api/java/util/regex/Pattern.html
    /// </summary>
    public RenameAttribute<T> RenameAttribute() { return new RenameAttribute<T>(rt); }

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
    public Reorder<T> Reorder() { return new Reorder<T>(rt); }

    /// <summary>
    /// Replaces all missing values for nominal and numeric attributes in a
    /// dataset with the modes and means from the training data.
    /// </summary>
    public ReplaceMissingValues<T> ReplaceMissingValues() { return new ReplaceMissingValues<T>(rt); }

    /// <summary>
    /// Replaces all missing values for nominal, string, numeric and date
    /// attributes in the dataset with user-supplied constant values.
    /// </summary>
    public ReplaceMissingWithUserConstant<T> ReplaceMissingWithUserConstant() { return new ReplaceMissingWithUserConstant<T>(rt); }

    /// <summary>
    /// A simple filter for sorting the labels of nominal attributes.
    /// </summary>
    public SortLabels<T> SortLabels() { return new SortLabels<T>(rt); }

    /// <summary>
    /// Standardizes all numeric attributes in the given dataset to have zero
    /// mean and unit variance (apart from the class attribute, if set).
    /// </summary>
    public Standardize<T> Standardize() { return new Standardize<T>(rt); }

    /// <summary>
    /// Converts a range of string attributes (unspecified number of values) to
    /// nominal (set number of values). You should ensure that all string values
    /// that will appear are represented in the first batch of the data.
    /// </summary>
    public StringToNominal<T> StringToNominal() { return new StringToNominal<T>(rt); }

    /// <summary>
    /// Converts String attributes into a set of attributes representing word
    /// occurrence (depending on the tokenizer) information from the text contained in
    /// the strings. The set of words (attributes) is determined by the first
    /// batch filtered (typically training data).
    /// </summary>
    public StringToWordVector<T> StringToWordVector() { return new StringToWordVector<T>(rt); }

    /// <summary>
    /// Swaps two values of a nominal attribute.
    /// </summary>
    public SwapValues<T> SwapValues() { return new SwapValues<T>(rt); }

    /// <summary>
    /// An instance filter that assumes instances form time-series data and
    /// replaces attribute values in the current instance with the difference between
    /// the current value and the equivalent attribute attribute value of some
    /// previous (or future) instance. For instances where the time-shifted value is
    /// unknown either the instance may be dropped, or missing values used. Skips the
    /// class attribute if it is set.
    /// </summary>
    public TimeSeriesDelta<T> TimeSeriesDelta() { return new TimeSeriesDelta<T>(rt); }

    /// <summary>
    /// An instance filter that assumes instances form time-series data and
    /// replaces attribute values in the current instance with the equivalent attribute
    /// values of some previous (or future) instance. For instances where the
    /// desired value is unknown either the instance may be dropped, or missing values
    /// used. Skips the class attribute if it is set.
    /// </summary>
    public TimeSeriesTranslate<T> TimeSeriesTranslate() { return new TimeSeriesTranslate<T>(rt); }

    
  }
}