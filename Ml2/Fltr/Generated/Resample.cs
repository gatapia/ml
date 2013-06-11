using weka.core;
using weka.filters.unsupervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// Produces a random subsample of a dataset using either sampling with
  /// replacement or without replacement. The original dataset must fit entirely in
  /// memory. The number of instances in the generated dataset may be specified.
  /// When used in batch mode, subsequent batches are NOT resampled.
  /// </summary>
  public class Resample<T> : BaseFilter<T>
  {
    public Resample(Runtime<T> rt) : base(rt, new Resample()) {}

    /// <summary>
    /// The seed used for random sampling.
    /// </summary>    
    public Resample<T> RandomSeed (int value) {
      ((Resample)impl).setRandomSeed(value);
      return this;
    }

    /// <summary>
    /// Size of the subsample as a percentage of the original dataset.
    /// </summary>    
    public Resample<T> SampleSizePercent (double value) {
      ((Resample)impl).setSampleSizePercent(value);
      return this;
    }

    /// <summary>
    /// Disables the replacement of instances.
    /// </summary>    
    public Resample<T> NoReplacement (bool value) {
      ((Resample)impl).setNoReplacement(value);
      return this;
    }

    /// <summary>
    /// Inverts the selection (only if instances are drawn WITHOUT replacement).
    /// </summary>    
    public Resample<T> InvertSelection (bool value) {
      ((Resample)impl).setInvertSelection(value);
      return this;
    }

        
        
  }
}