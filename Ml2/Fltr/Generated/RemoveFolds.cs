using weka.filters.unsupervised.instance;

namespace Ml2.Fltr.Generated
{
  /// <summary>
  /// This filter takes a dataset and outputs a specified fold for cross
  /// validation. If you want the folds to be stratified use the supervised version.
  /// </summary>
  public class RemoveFolds<T> : BaseFilter<T>
  {
    public RemoveFolds(Runtime<T> rt) : base(rt, new RemoveFolds()) {}

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public RemoveFolds<T> InvertSelection (bool value) {
      ((RemoveFolds)impl).setInvertSelection(value);
      return this;
    }
    /// <summary>
    /// The number of folds to split the dataset into.
    /// </summary>    
    public RemoveFolds<T> NumFolds (int value) {
      ((RemoveFolds)impl).setNumFolds(value);
      return this;
    }
    /// <summary>
    /// The fold which is selected.
    /// </summary>    
    public RemoveFolds<T> Fold (int value) {
      ((RemoveFolds)impl).setFold(value);
      return this;
    }
        
  }
}