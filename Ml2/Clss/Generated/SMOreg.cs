using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// SMOreg implements the support vector machine for regression. The
  /// parameters can be learned using various algorithms. The algorithm is selected by
  /// setting the RegOptimizer. The most popular algorithm (RegSMOImproved) is due
  /// to Shevade, Keerthi et al and this is the default RegOptimizer. For more
  /// information see: S.K. Shevade, S.S. Keerthi, C. Bhattacharyya, K.R.K. Murthy:
  /// Improvements to the SMO Algorithm for SVM Regression. In: IEEE
  /// Transactions on Neural Networks, 1999. A.J. Smola, B. Schoelkopf (1998). A tutorial on
  /// support vector regression.
  /// </summary>
  public class SMOreg<T> : BaseClassifier<T>
  {
    public SMOreg(Runtime<T> rt) : base(rt, new SMOreg()) {}

    /// <summary>
    /// The complexity parameter C.
    /// </summary>    
    public SMOreg<T> C (double value) {
      ((SMOreg)impl).setC(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SMOreg<T> Debug (bool value) {
      ((SMOreg)impl).setDebug(value);
      return this;
    }

        
  }
}