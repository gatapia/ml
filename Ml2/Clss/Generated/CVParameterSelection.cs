using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for performing parameter selection by cross-validation for any
  /// classifier. For more information, see: R. Kohavi (1995). Wrappers for
  /// Performance Enhancement and Oblivious Decision Graphs. Department of Computer
  /// Science, Stanford University.
  /// </summary>
  public class CVParameterSelection<T> : BaseClassifier<T>
  {
    public CVParameterSelection(Runtime<T> rt) : base(rt, new CVParameterSelection()) {}

    /// <summary>
    /// Get the number of folds used for cross-validation.
    /// </summary>    
    public CVParameterSelection<T> NumFolds (int value) {
      ((CVParameterSelection)impl).setNumFolds(value);
      return this;
    }

    /// <summary>
    /// The random number seed to be used.
    /// </summary>    
    public CVParameterSelection<T> Seed (int value) {
      ((CVParameterSelection)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public CVParameterSelection<T> Debug (bool value) {
      ((CVParameterSelection)impl).setDebug(value);
      return this;
    }

        
  }
}