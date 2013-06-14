using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Chooses a random subset of attributes, either an absolute number or a
  /// percentage. The class is always included in the output (as the last
  /// attribute).
  /// </summary>
  public class RandomSubset<T> : BaseFilter<T, RandomSubset> where T : new()
  {
    public RandomSubset(Runtime<T> rt) : base(rt, new RandomSubset()) {}

    /// <summary>
    /// The number of attributes to choose: < 1 percentage, >= 1 absolute number.
    /// </summary>    
    public RandomSubset<T> NumAttributes (double value) {
      ((RandomSubset)Impl).setNumAttributes(value);
      return this;
    }

    /// <summary>
    /// The seed value for the random number generator.
    /// </summary>    
    public RandomSubset<T> Seed (int value) {
      ((RandomSubset)Impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public RandomSubset<T> Debug (bool value) {
      ((RandomSubset)Impl).setDebug(value);
      return this;
    }

        
        
  }
}