using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for selecting a classifier from among several using cross
  /// validation on the training data or the performance on the training data. Performance
  /// is measured based on percent correct (classification) or mean-squared
  /// error (regression).
  /// </summary>
  public class MultiScheme<T> : BaseClassifier<T>
  {
    public MultiScheme(Runtime<T> rt) : base(rt, new MultiScheme()) {}

    /// <summary>
    /// The number of folds used for cross-validation (if 0, performance on
    /// training data will be used).
    /// </summary>    
    public MultiScheme<T> NumFolds (int numFolds) {
      ((MultiScheme)Impl).setNumFolds(numFolds);
      return this;
    }

    /// <summary>
    /// The seed used for randomizing the data for cross-validation.
    /// </summary>    
    public MultiScheme<T> Seed (int seed) {
      ((MultiScheme)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// Whether debug information is output to console.
    /// </summary>    
    public MultiScheme<T> Debug (bool debug) {
      ((MultiScheme)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}