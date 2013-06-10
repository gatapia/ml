namespace Ml2.Fltr
{
  public class SuppervisedInstanceFilters<T>
  {
    private readonly Runtime<T> rt;    
    public SuppervisedInstanceFilters(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// Produces a random subsample of a dataset using either sampling with
    /// replacement or without replacement. The original dataset must fit entirely in
    /// memory. The number of instances in the generated dataset may be specified.
    /// The dataset must have a nominal class attribute. If not, use the unsupervised
    /// version. The filter can be made to maintain the class distribution in the
    /// subsample, or to bias the class distribution toward a uniform distribution.
    /// When used in batch mode (i.e. in the FilteredClassifier), subsequent
    /// batches are NOT resampled.
    /// </summary>
    public Resample<T> Resample() { return new Resample<T>(rt); }

    /// <summary>
    /// Produces a random subsample of a dataset. The original dataset must fit
    /// entirely in memory. This filter allows you to specify the maximum "spread"
    /// between the rarest and most common class. For example, you may specify that
    /// there be at most a 2:1 difference in class frequencies. When used in batch
    /// mode, subsequent batches are NOT resampled.
    /// </summary>
    public SpreadSubsample<T> SpreadSubsample() { return new SpreadSubsample<T>(rt); }

    /// <summary>
    /// This filter takes a dataset and outputs a specified fold for cross
    /// validation. If you do not want the folds to be stratified use the unsupervised
    /// version.
    /// </summary>
    public StratifiedRemoveFolds<T> StratifiedRemoveFolds() { return new StratifiedRemoveFolds<T>(rt); }

    
  }
}