using weka.filters.supervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// Produces a random subsample of a dataset. The original dataset must fit
  /// entirely in memory. This filter allows you to specify the maximum "spread"
  /// between the rarest and most common class. For example, you may specify that
  /// there be at most a 2:1 difference in class frequencies. When used in batch
  /// mode, subsequent batches are NOT resampled.
  /// </summary>
  public class SpreadSubsample<T> : BaseFilter<T>
  {
    public SpreadSubsample(Runtime<T> rt) : base(rt, new SpreadSubsample()) {}

    /// <summary>
    /// Sets the random number seed for subsampling.
    /// </summary>    
    public SpreadSubsample<T> RandomSeed (int value) {
      ((SpreadSubsample)impl).setRandomSeed(value);
      return this;
    }
    /// <summary>
    /// The maximum class distribution spread. (0 = no maximum spread, 1 =
    /// uniform distribution, 10 = allow at most a 10:1 ratio between the classes).
    /// </summary>    
    public SpreadSubsample<T> DistributionSpread (double value) {
      ((SpreadSubsample)impl).setDistributionSpread(value);
      return this;
    }
    /// <summary>
    /// The maximum count for any class value (0 = unlimited).
    /// </summary>    
    public SpreadSubsample<T> MaxCount (double value) {
      ((SpreadSubsample)impl).setMaxCount(value);
      return this;
    }
    /// <summary>
    /// Wether instance weights will be adjusted to maintain total weight per
    /// class.
    /// </summary>    
    public SpreadSubsample<T> AdjustWeights (bool value) {
      ((SpreadSubsample)impl).setAdjustWeights(value);
      return this;
    }
        
  }
}