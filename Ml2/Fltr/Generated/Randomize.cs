using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Randomly shuffles the order of instances passed through it. The random
  /// number generator is reset with the seed value whenever a new set of instances
  /// is passed in.
  /// </summary>
  public class Randomize<T> : BaseFilter<T, Randomize>
  {
    public Randomize(Runtime<T> rt) : base(rt, new Randomize()) {}

    /// <summary>
    /// Seed for the random number generator.
    /// </summary>    
    public Randomize<T> RandomSeed (int newRandomSeed) {
      ((Randomize)Impl).setRandomSeed(newRandomSeed);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Randomize<T> InputFormat (Runtime<T> instanceInfo) {
      ((Randomize)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}