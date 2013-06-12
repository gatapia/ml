using weka.core;
using weka.filters.unsupervised.instance;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// Filters instances according to the value of an attribute.
  /// </summary>
  public class RemoveWithValues<T> : BaseFilter<T>
  {
    public RemoveWithValues(Runtime<T> rt) : base(rt, new RemoveWithValues()) {}

    /// <summary>
    /// Choose attribute to be used for selection (default last).
    /// </summary>    
    public RemoveWithValues<T> AttributeIndex (string value) {
      ((RemoveWithValues)Impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// When selecting on nominal attributes, removes header references to
    /// excluded values.
    /// </summary>    
    public RemoveWithValues<T> ModifyHeader (bool value) {
      ((RemoveWithValues)Impl).setModifyHeader(value);
      return this;
    }

    /// <summary>
    /// Invert matching sense.
    /// </summary>    
    public RemoveWithValues<T> InvertSelection (bool value) {
      ((RemoveWithValues)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public RemoveWithValues<T> NominalIndicesArr (int[] value) {
      ((RemoveWithValues)Impl).setNominalIndicesArr(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public RemoveWithValues<T> InputFormat (Runtime<T> value) {
      ((RemoveWithValues)Impl).setInputFormat(value.Instances);
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
    public RemoveWithValues<T> NominalIndices (string value) {
      ((RemoveWithValues)Impl).setNominalIndices(value);
      return this;
    }

    /// <summary>
    /// Missing values count as a match. This setting is independent of the
    /// invertSelection option.
    /// </summary>    
    public RemoveWithValues<T> MatchMissingValues (bool value) {
      ((RemoveWithValues)Impl).setMatchMissingValues(value);
      return this;
    }

    /// <summary>
    /// Whether to apply the filtering process to instances that are input after
    /// the first (training) batch. The default is false so instances in subsequent
    /// batches can potentially get 'consumed' by the filter.
    /// </summary>    
    public RemoveWithValues<T> DontFilterAfterFirstBatch (bool value) {
      ((RemoveWithValues)Impl).setDontFilterAfterFirstBatch(value);
      return this;
    }

        
        
  }
}