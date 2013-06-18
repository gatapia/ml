using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// This filter takes a dataset and outputs a specified fold for cross
  /// validation. If you want the folds to be stratified use the supervised
  /// version.<br/><br/>Options:<br/><br/>-V = 	Specifies if inverse of selection is to be
  /// output.<br/><br/>-N &lt;number of folds&gt; = 	Specifies number of folds
  /// dataset is split into. <br/>	(default 10)<br/><br/>-F &lt;fold&gt; =
  /// 	Specifies which fold is selected. (default 1)<br/><br/>-S &lt;seed&gt; = 	Specifies
  /// random number seed. (default 0, no randomizing)<br/>
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

        
        
  }
}