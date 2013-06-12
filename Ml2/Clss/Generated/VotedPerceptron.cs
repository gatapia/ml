using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Implementation of the voted perceptron algorithm by Freund and Schapire.
  /// Globally replaces all missing values, and transforms nominal attributes
  /// into binary ones. For more information, see: Y. Freund, R. E. Schapire: Large
  /// margin classification using the perceptron algorithm. In: 11th Annual
  /// Conference on Computational Learning Theory, New York, NY, 209-217, 1998.
  /// </summary>
  public class VotedPerceptron<T> : BaseClassifier<T>
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
    public VotedPerceptron<T> Seed (int v) {
      ((VotedPerceptron)Impl).setSeed(v);
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