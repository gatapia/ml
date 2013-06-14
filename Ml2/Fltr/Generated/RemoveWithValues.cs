using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Filters instances according to the value of an attribute.
  /// </summary>
  public class RemoveWithValues<T> : BaseFilter<T, RemoveWithValues> where T : new()
  {
    public RemoveWithValues(Runtime<T> rt) : base(rt, new RemoveWithValues()) {}

    /// <summary>
    /// Choose attribute to be used for selection (default last).
    /// </summary>    
    public RemoveWithValues<T> AttributeIndex (string attIndex) {
      ((RemoveWithValues)Impl).setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// When selecting on nominal attributes, removes header references to
    /// excluded values.
    /// </summary>    
    public RemoveWithValues<T> ModifyHeader (bool newModifyHeader) {
      ((RemoveWithValues)Impl).setModifyHeader(newModifyHeader);
      return this;
    }

    /// <summary>
    /// Invert matching sense.
    /// </summary>    
    public RemoveWithValues<T> InvertSelection (bool invert) {
      ((RemoveWithValues)Impl).setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public RemoveWithValues<T> NominalIndicesArr (int[] values) {
      ((RemoveWithValues)Impl).setNominalIndicesArr(values);
      return this;
    }

    /// <summary>
    /// Numeric value to be used for selection on numeric attribute. Instances
    /// with values smaller than given value will be selected.
    /// </summary>    
    public RemoveWithValues<T> SplitPoint (double value) {
      ((RemoveWithValues)Impl).setSplitPoint(value);
      return this;
    }

    /// <summary>
    /// Range of label indices to be used for selection on nominal attribute.
    /// First and last are valid indexes.
    /// </summary>    
    public RemoveWithValues<T> NominalIndices (string rangeList) {
      ((RemoveWithValues)Impl).setNominalIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Missing values count as a match. This setting is independent of the
    /// invertSelection option.
    /// </summary>    
    public RemoveWithValues<T> MatchMissingValues (bool newMatchMissingValues) {
      ((RemoveWithValues)Impl).setMatchMissingValues(newMatchMissingValues);
      return this;
    }

    /// <summary>
    /// Whether to apply the filtering process to instances that are input after
    /// the first (training) batch. The default is false so instances in subsequent
    /// batches can potentially get 'consumed' by the filter.
    /// </summary>    
    public RemoveWithValues<T> DontFilterAfterFirstBatch (bool b) {
      ((RemoveWithValues)Impl).setDontFilterAfterFirstBatch(b);
      return this;
    }

        
        
  }
}