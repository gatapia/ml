using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Produces a random subsample of a dataset using the reservoir sampling
  /// Algorithm "R" by Vitter. The original data set does not have to fit into main
  /// memory, but the reservoir does.
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

    /// <summary>
    /// 
    /// </summary>    
    public ReservoirSample<T> InputFormat (Runtime<T> instanceInfo) {
      ((ReservoirSample)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}