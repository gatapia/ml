using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for using linear regression for prediction. Uses the Akaike
  /// criterion for model selection, and is able to deal with weighted instances.
  /// </summary>
  public class LinearRegression<T> : BaseClassifier<T, LinearRegression>
  {
    public LinearRegression(Runtime<T> rt) : base(rt, new LinearRegression()) {}

    /// <summary>
    /// Set the method used to select attributes for use in the linear
    /// regression. Available methods are: no attribute selection, attribute selection using
    /// M5's method (step through the attributes removing the one with the smallest
    /// standardised coefficient until no improvement is observed in the estimate
    /// of the error given by the Akaike information criterion), and a greedy
    /// selection using the Akaike information metric.
    /// </summary>    
    public LinearRegression<T> AttributeSelectionMethod (EAttributeSelectionMethod method) {
      ((LinearRegression)Impl).setAttributeSelectionMethod(new weka.core.SelectedTag((int) method, LinearRegression.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// The value of the Ridge parameter.
    /// </summary>    
    public LinearRegression<T> Ridge (double newRidge) {
      ((LinearRegression)Impl).setRidge(newRidge);
      return this;
    }

    /// <summary>
    /// Eliminate colinear attributes.
    /// </summary>    
    public LinearRegression<T> EliminateColinearAttributes (bool newEliminateColinearAttributes) {
      ((LinearRegression)Impl).setEliminateColinearAttributes(newEliminateColinearAttributes);
      return this;
    }

    /// <summary>
    /// If enabled, dataset header, means and stdevs get discarded to conserve
    /// memory; also, the model cannot be printed out.
    /// </summary>    
    public LinearRegression<T> Minimal (bool value) {
      ((LinearRegression)Impl).setMinimal(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LinearRegression<T> Debug (bool debug) {
      ((LinearRegression)Impl).setDebug(debug);
      return this;
    }

        
    public enum EAttributeSelectionMethod {
      No_attribute_selection = 1,
      M5_method = 0,
      Greedy_method = 2
    }

        
  }
}