using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that changes a percentage of a given attributes
  /// values. The attribute must be nominal. Missing value can be treated as value
  /// itself.
  /// </summary>
  public class AddNoise<T> : BaseFilter<T>
  {
    public AddNoise(Runtime<T> rt) : base(rt, new AddNoise()) {}

    /// <summary>
    /// Index of the attribute that is to changed.
    /// </summary>    
    public AddNoise<T> AttributeIndex (string value) {
      ((AddNoise)Impl).setAttributeIndex(value);
      return this;
    }

    /// <summary>
    /// Flag to set if missing values are used.
    /// </summary>    
    public AddNoise<T> UseMissing (bool value) {
      ((AddNoise)Impl).setUseMissing(value);
      return this;
    }

    /// <summary>
    /// Percentage of introduced noise to data.
    /// </summary>    
    public AddNoise<T> Percent (int value) {
      ((AddNoise)Impl).setPercent(value);
      return this;
    }

    /// <summary>
    /// Random number seed.
    /// </summary>    
    public AddNoise<T> RandomSeed (int value) {
      ((AddNoise)Impl).setRandomSeed(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public AddNoise<T> InputFormat (Runtime<T> value) {
      ((AddNoise)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}