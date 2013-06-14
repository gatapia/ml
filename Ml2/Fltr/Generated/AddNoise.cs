using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that changes a percentage of a given attributes
  /// values. The attribute must be nominal. Missing value can be treated as value
  /// itself.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Index of the attribute to
  /// be changed <br/>	(default last attribute)<br/>-M = 	Treat missing values as
  /// an extra value <br/><br/>-P &lt;num&gt; = 	Specify the percentage of noise
  /// introduced <br/>	to the data (default 10)<br/>-S &lt;num&gt; = 	Specify
  /// the random number seed (default 1)
  /// </summary>
  public class AddNoise<T> : BaseFilter<T, AddNoise> where T : new()
  {
    public AddNoise(Runtime<T> rt) : base(rt, new AddNoise()) {}

    /// <summary>
    /// Index of the attribute that is to changed.
    /// </summary>    
    public AddNoise<T> AttributeIndex (string attIndex) {
      ((AddNoise)Impl).setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// Flag to set if missing values are used.
    /// </summary>    
    public AddNoise<T> UseMissing (bool newUseMissing) {
      ((AddNoise)Impl).setUseMissing(newUseMissing);
      return this;
    }

    /// <summary>
    /// Percentage of introduced noise to data.
    /// </summary>    
    public AddNoise<T> Percent (int newPercent) {
      ((AddNoise)Impl).setPercent(newPercent);
      return this;
    }

    /// <summary>
    /// Random number seed.
    /// </summary>    
    public AddNoise<T> RandomSeed (int newSeed) {
      ((AddNoise)Impl).setRandomSeed(newSeed);
      return this;
    }

        
        
  }
}