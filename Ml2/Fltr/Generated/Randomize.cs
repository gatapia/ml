using weka.core;
using weka.filters.unsupervised.instance;

namespace Ml2.Fltr
{
  /// <summary>
  /// Randomly shuffles the order of instances passed through it. The random
  /// number generator is reset with the seed value whenever a new set of instances
  /// is passed in.
  /// </summary>
  public class Randomize<T> : BaseFilter<T>
  {
    public Randomize(Runtime<T> rt) : base(rt, new Randomize()) {}

    /// <summary>
    /// Seed for the random number generator.
    /// </summary>    
    public Randomize<T> RandomSeed (int value) {
      ((Randomize)impl).setRandomSeed(value);
      return this;
    }

        
        
  }
}