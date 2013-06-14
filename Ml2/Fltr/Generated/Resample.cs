using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Produces a random subsample of a dataset using either sampling with
  /// replacement or without replacement. The original dataset must fit entirely in
  /// memory. The number of instances in the generated dataset may be specified.
  /// When used in batch mode, subsequent batches are NOT
  /// resampled.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Specify the random number seed (default
  /// 1)<br/>-Z &lt;num&gt; = 	The size of the output dataset, as a percentage
  /// of<br/>	the input dataset (default 100)<br/>-no-replacement = 	Disables
  /// replacement of instances<br/>	(default: with replacement)<br/>-V = 	Inverts the
  /// selection - only available with '-no-replacement'.
  /// </summary>
  public class Resample<T> : BaseFilter<T, Resample> where T : new()
  {
    public Resample(Runtime<T> rt) : base(rt, new Resample()) {}

    /// <summary>
    /// The seed used for random sampling.
    /// </summary>    
    public Resample<T> RandomSeed (int newSeed) {
      ((Resample)Impl).setRandomSeed(newSeed);
      return this;
    }

    /// <summary>
    /// Size of the subsample as a percentage of the original dataset.
    /// </summary>    
    public Resample<T> SampleSizePercent (double newSampleSizePercent) {
      ((Resample)Impl).setSampleSizePercent(newSampleSizePercent);
      return this;
    }

    /// <summary>
    /// Disables the replacement of instances.
    /// </summary>    
    public Resample<T> NoReplacement (bool value) {
      ((Resample)Impl).setNoReplacement(value);
      return this;
    }

    /// <summary>
    /// Inverts the selection (only if instances are drawn WITHOUT replacement).
    /// </summary>    
    public Resample<T> InvertSelection (bool value) {
      ((Resample)Impl).setInvertSelection(value);
      return this;
    }

        
        
  }
}