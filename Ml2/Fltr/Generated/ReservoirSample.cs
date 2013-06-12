using weka.core;
using weka.filters.unsupervised.instance;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// Produces a random subsample of a dataset using the reservoir sampling
  /// Algorithm "R" by Vitter. The original data set does not have to fit into main
  /// memory, but the reservoir does.
  /// </summary>
  public class ReservoirSample<T> : BaseFilter<T>
  {
    public ReservoirSample(Runtime<T> rt) : base(rt, new ReservoirSample()) {}

    /// <summary>
    /// The seed used for random sampling.
    /// </summary>    
    public ReservoirSample<T> RandomSeed (int value) {
      ((ReservoirSample)Impl).setRandomSeed(value);
      return this;
    }

    /// <summary>
    /// Size of the subsample (reservoir). i.e. the number of instances.
    /// </summary>    
    public ReservoirSample<T> SampleSize (int value) {
      ((ReservoirSample)Impl).setSampleSize(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public ReservoirSample<T> InputFormat (Runtime<T> value) {
      ((ReservoirSample)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}