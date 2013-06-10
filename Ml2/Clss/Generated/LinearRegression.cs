using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for using linear regression for prediction. Uses the Akaike
  /// criterion for model selection, and is able to deal with weighted instances.
  /// </summary>
  public class LinearRegression<T> : BaseClassifier<T>
  {
    public LinearRegression(Runtime<T> rt) : base(rt, new LinearRegression()) {}

    /// <summary>
    /// The value of the Ridge parameter.
    /// </summary>    
    public LinearRegression<T> Ridge (double value) {
      ((LinearRegression)impl).setRidge(value);
      return this;
    }

    /// <summary>
    /// Eliminate colinear attributes.
    /// </summary>    
    public LinearRegression<T> EliminateColinearAttributes (bool value) {
      ((LinearRegression)impl).setEliminateColinearAttributes(value);
      return this;
    }

    /// <summary>
    /// If enabled, dataset header, means and stdevs get discarded to conserve
    /// memory; also, the model cannot be printed out.
    /// </summary>    
    public LinearRegression<T> Minimal (bool value) {
      ((LinearRegression)impl).setMinimal(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LinearRegression<T> Debug (bool value) {
      ((LinearRegression)impl).setDebug(value);
      return this;
    }

        
  }
}