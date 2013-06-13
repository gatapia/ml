using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for performing parameter selection by cross-validation for any
  /// classifier. For more information, see: R. Kohavi (1995). Wrappers for
  /// Performance Enhancement and Oblivious Decision Graphs. Department of Computer
  /// Science, Stanford University.
  /// </summary>
  public class CVParameterSelection<T> : BaseClassifier<T, CVParameterSelection> where T : new()
  {
    public CVParameterSelection(Runtime<T> rt) : base(rt, new CVParameterSelection()) {}

    /// <summary>
    /// Get the number of folds used for cross-validation.
    /// </summary>    
    public CVParameterSelection<T> NumFolds (int numFolds) {
      ((CVParameterSelection)Impl).setNumFolds(numFolds);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public CVParameterSelection<T> Seed (int seed) {
      ((CVParameterSelection)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public CVParameterSelection<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((CVParameterSelection)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public CVParameterSelection<T> Debug (bool debug) {
      ((CVParameterSelection)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}