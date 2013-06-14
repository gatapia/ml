using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// This filter takes a dataset and outputs a specified fold for cross
  /// validation. If you want the folds to be stratified use the supervised version.
  /// </summary>
  public class RemoveFolds<T> : BaseFilter<T, RemoveFolds> where T : new()
  {
    public RemoveFolds(Runtime<T> rt) : base(rt, new RemoveFolds()) {}

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public RemoveFolds<T> InvertSelection (bool inverse) {
      ((RemoveFolds)Impl).setInvertSelection(inverse);
      return this;
    }

    /// <summary>
    /// The number of folds to split the dataset into.
    /// </summary>    
    public RemoveFolds<T> NumFolds (int numFolds) {
      ((RemoveFolds)Impl).setNumFolds(numFolds);
      return this;
    }

    /// <summary>
    /// The fold which is selected.
    /// </summary>    
    public RemoveFolds<T> Fold (int fold) {
      ((RemoveFolds)Impl).setFold(fold);
      return this;
    }

    /// <summary>
    /// the random number seed for shuffling the dataset. If seed is negative,
    /// shuffling will not be performed.
    /// </summary>    
    public RemoveFolds<T> Seed (long seed) {
      ((RemoveFolds)Impl).setSeed(seed);
      return this;
    }

        
        
  }
}