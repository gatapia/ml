using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Produces a random subsample of a dataset using the reservoir sampling
  /// Algorithm "R" by Vitter. The original data set does not have to fit into main
  /// memory, but the reservoir does. <br/><br/>Options:<br/><br/>-S &lt;num&gt;
  /// = 	Specify the random number seed (default 1)<br/>-Z &lt;num&gt; = 	The
  /// size of the output dataset - number of instances<br/>	(default 100)
  /// </summary>
  public class ReservoirSample<T> : BaseFilter<T, ReservoirSample> where T : new()
  {
    public ReservoirSample(Runtime<T> rt) : base(rt, new ReservoirSample()) {}

    /// <summary>
    /// The seed used for random sampling.
    /// </summary>    
    public ReservoirSample<T> RandomSeed (int newSeed) {
      ((ReservoirSample)Impl).setRandomSeed(newSeed);
      return this;
    }

    /// <summary>
    /// Size of the subsample (reservoir). i.e. the number of instances.
    /// </summary>    
    public ReservoirSample<T> SampleSize (int newSampleSize) {
      ((ReservoirSample)Impl).setSampleSize(newSampleSize);
      return this;
    }

        
        
  }
}