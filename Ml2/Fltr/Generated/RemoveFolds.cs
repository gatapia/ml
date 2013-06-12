using weka.core;
using weka.filters.unsupervised.instance;
using System.Linq;

namespace Ml2.Fltr
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
      ((RemoveFolds)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// The number of folds to split the dataset into.
    /// </summary>    
    public RemoveFolds<T> NumFolds (int value) {
      ((RemoveFolds)Impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// The fold which is selected.
    /// </summary>    
    public RemoveFolds<T> Fold (int value) {
      ((RemoveFolds)Impl).setFold(value);
      return this;
    }

    /// <summary>
    /// the random number seed for shuffling the dataset. If seed is negative,
    /// shuffling will not be performed.
    /// </summary>    
    public RemoveFolds<T> Seed (long value) {
      ((RemoveFolds)Impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public RemoveFolds<T> InputFormat (Runtime<T> value) {
      ((RemoveFolds)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}