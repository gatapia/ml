using weka.filters.supervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// This filter takes a dataset and outputs a specified fold for cross
  /// validation. If you do not want the folds to be stratified use the unsupervised
  /// version.
  /// </summary>
  public class StratifiedRemoveFolds<T> : BaseFilter<T>
  {
    public StratifiedRemoveFolds(Runtime<T> rt) : base(rt, new StratifiedRemoveFolds()) {}

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public StratifiedRemoveFolds<T> InvertSelection (bool value) {
      ((StratifiedRemoveFolds)impl).setInvertSelection(value);
      return this;
    }
    /// <summary>
    /// The number of folds to split the dataset into.
    /// </summary>    
    public StratifiedRemoveFolds<T> NumFolds (int value) {
      ((StratifiedRemoveFolds)impl).setNumFolds(value);
      return this;
    }
    /// <summary>
    /// The fold which is selected.
    /// </summary>    
    public StratifiedRemoveFolds<T> Fold (int value) {
      ((StratifiedRemoveFolds)impl).setFold(value);
      return this;
    }
        
  }
}