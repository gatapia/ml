// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  public class UnsuppervisedInstanceFilters<T>
  {
    private readonly Runtime<T> rt;    
    public UnsuppervisedInstanceFilters(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// An instance filter that converts all incoming instances into sparse
    /// format.
    /// </summary>
    public NonSparseToSparse<T> NonSparseToSparse() { return new NonSparseToSparse<T>(rt); }

    /// <summary>
    /// Randomly shuffles the order of instances passed through it. The random
    /// number generator is reset with the seed value whenever a new set of instances
    /// is passed in.
    /// </summary>
    public Randomize<T> Randomize() { return new Randomize<T>(rt); }

    /// <summary>
    /// This filter takes a dataset and outputs a specified fold for cross
    /// validation. If you want the folds to be stratified use the supervised version.
    /// </summary>
    public RemoveFolds<T> RemoveFolds() { return new RemoveFolds<T>(rt); }

    /// <summary>
    /// Determines which values (frequent or infrequent ones) of an (nominal)
    /// attribute are retained and filters the instances accordingly. In case of
    /// values with the same frequency, they are kept in the way they appear in the
    /// original instances object. E.g. if you have the values "1,2,3,4" with the
    /// frequencies "10,5,5,3" and you chose to keep the 2 most common values, the
    /// values "1,2" would be returned, since the value "2" comes before "3", even
    /// though they have the same frequency.
    /// </summary>
    public RemoveFrequentValues<T> RemoveFrequentValues() { return new RemoveFrequentValues<T>(rt); }

    /// <summary>
    /// A filter that removes instances which are incorrectly classified. Useful
    /// for removing outliers.
    /// </summary>
    public RemoveMisclassified<T> RemoveMisclassified() { return new RemoveMisclassified<T>(rt); }

    /// <summary>
    /// A filter that removes a given percentage of a dataset.
    /// </summary>
    public RemovePercentage<T> RemovePercentage() { return new RemovePercentage<T>(rt); }

    /// <summary>
    /// A filter that removes a given range of instances of a dataset.
    /// </summary>
    public RemoveRange<T> RemoveRange() { return new RemoveRange<T>(rt); }

    /// <summary>
    /// Filters instances according to the value of an attribute.
    /// </summary>
    public RemoveWithValues<T> RemoveWithValues() { return new RemoveWithValues<T>(rt); }

    /// <summary>
    /// Produces a random subsample of a dataset using either sampling with
    /// replacement or without replacement. The original dataset must fit entirely in
    /// memory. The number of instances in the generated dataset may be specified.
    /// When used in batch mode, subsequent batches are NOT resampled.
    /// </summary>
    public Resample<T> Resample() { return new Resample<T>(rt); }

    /// <summary>
    /// Produces a random subsample of a dataset using the reservoir sampling
    /// Algorithm "R" by Vitter. The original data set does not have to fit into main
    /// memory, but the reservoir does.
    /// </summary>
    public ReservoirSample<T> ReservoirSample() { return new ReservoirSample<T>(rt); }

    /// <summary>
    /// An instance filter that converts all incoming sparse instances into
    /// non-sparse format.
    /// </summary>
    public SparseToNonSparse<T> SparseToNonSparse() { return new SparseToNonSparse<T>(rt); }

    /// <summary>
    /// Filters instances according to a user-specified expression. Grammar:
    /// boolexpr_list ::= boolexpr_list boolexpr_part | boolexpr_part; boolexpr_part
    /// ::= boolexpr:e {: parser.setResult(e); :} ; boolexpr ::= BOOLEAN | true |
    /// false | expr < expr | expr <= expr | expr > expr | expr >= expr | expr = expr
    /// | ( boolexpr ) | not boolexpr | boolexpr and boolexpr | boolexpr or
    /// boolexpr | ATTRIBUTE is STRING ; expr ::= NUMBER | ATTRIBUTE | ( expr ) | opexpr |
    /// funcexpr ; opexpr ::= expr + expr | expr - expr | expr * expr | expr /
    /// expr ; funcexpr ::= abs ( expr ) | sqrt ( expr ) | log ( expr ) | exp ( expr )
    /// | sin ( expr ) | cos ( expr ) | tan ( expr ) | rint ( expr ) | floor (
    /// expr ) | pow ( expr for base , expr for exponent ) | ceil ( expr ) ; Notes: -
    /// NUMBER any integer or floating point number (but not in scientific
    /// notation!) - STRING any string surrounded by single quotes; the string may not
    /// contain a single quote though. - ATTRIBUTE the following placeholders are
    /// recognized for attribute values: - CLASS for the class value in case a class
    /// attribute is set. - ATTxyz with xyz a number from 1 to # of attributes in the
    /// dataset, representing the value of indexed attribute. Examples: -
    /// extracting only mammals and birds from the 'zoo' UCI dataset: (CLASS is 'mammal') or
    /// (CLASS is 'bird') - extracting only animals with at least 2 legs from the
    /// 'zoo' UCI dataset: (ATT14 >= 2) - extracting only instances with
    /// non-missing 'wage-increase-second-year' from the 'labor' UCI dataset: not
    /// ismissing(ATT3)
    /// </summary>
    public SubsetByExpression<T> SubsetByExpression() { return new SubsetByExpression<T>(rt); }

    
  }
}