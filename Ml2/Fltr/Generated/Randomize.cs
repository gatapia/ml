using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Randomly shuffles the order of instances passed through it. The random
  /// number generator is reset with the seed value whenever a new set of instances
  /// is passed in.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Specify the
  /// random number seed (default 42)
  /// </summary>
  public class Randomize<T> : BaseFilter<T, Randomize> where T : new()
  {
    public Randomize(Runtime<T> rt) : base(rt, new Randomize()) {}

        
        
  }
}