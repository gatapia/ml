using weka.core;
using weka.filters.supervised.instance;
using System.Linq;

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
      ((StratifiedRemoveFolds)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// The number of folds to split the dataset into.
    /// </summary>    
    public StratifiedRemoveFolds<T> NumFolds (int value) {
      ((StratifiedRemoveFolds)Impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// The fold which is selected.
    /// </summary>    
    public StratifiedRemoveFolds<T> Fold (int value) {
      ((StratifiedRemoveFolds)Impl).setFold(value);
      return this;
    }

    /// <summary>
    /// the random number seed for shuffling the dataset. If seed is negative,
    /// shuffling will not be performed.
    /// </summary>    
    public StratifiedRemoveFolds<T> Seed (long value) {
      ((StratifiedRemoveFolds)Impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StratifiedRemoveFolds<T> InputFormat (Runtime<T> value) {
      ((StratifiedRemoveFolds)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}