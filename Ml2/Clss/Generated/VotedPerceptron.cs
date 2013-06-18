using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Implementation of the voted perceptron algorithm by Freund and Schapire.
  /// Globally replaces all missing values, and transforms nominal attributes
  /// into binary ones.<br/><br/>For more information, see:<br/><br/>Y. Freund, R.
  /// E. Schapire: Large margin classification using the perceptron algorithm. In:
  /// 11th Annual Conference on Computational Learning Theory, New York, NY,
  /// 209-217, 1998.<br/><br/>Options:<br/><br/>-I &lt;int&gt; = 	The number of
  /// iterations to be performed.<br/>	(default 1)<br/>-E &lt;double&gt; = 	The
  /// exponent for the polynomial kernel.<br/>	(default 1)<br/>-S &lt;int&gt; = 	The
  /// seed for the random number generation.<br/>	(default 1)<br/>-M &lt;int&gt; =
  /// 	The maximum number of alterations allowed.<br/>	(default 10000)
  /// </summary>
  public class VotedPerceptron<T> : BaseClassifier<T, VotedPerceptron> where T : new()
  {
    public VotedPerceptron(Runtime<T> rt) : base(rt, new VotedPerceptron()) {}

    /// <summary>
    /// The maximum number of alterations to the perceptron.
    /// </summary>    
    public VotedPerceptron<T> MaxK (int v) {
      ((VotedPerceptron)Impl).setMaxK(v);
      return this;
    }

    /// <summary>
    /// Number of iterations to be performed.
    /// </summary>    
    public VotedPerceptron<T> NumIterations (int v) {
      ((VotedPerceptron)Impl).setNumIterations(v);
      return this;
    }

    /// <summary>
    /// Exponent for the polynomial kernel.
    /// </summary>    
    public VotedPerceptron<T> Exponent (double v) {
      ((VotedPerceptron)Impl).setExponent(v);
      return this;
    }

    /// <summary>
    /// Seed for the random number generator.
    /// </summary>    
    public VotedPerceptron<T> Seed (int seed) {
      throw new System.NotSupportedException("Seeds are handled internally by the system for reproducability.")
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public VotedPerceptron<T> Debug (bool debug) {
      ((VotedPerceptron)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}