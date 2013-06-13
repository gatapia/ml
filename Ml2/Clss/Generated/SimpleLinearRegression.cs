using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Learns a simple linear regression model. Picks the attribute that results
  /// in the lowest squared error. Missing values are not allowed. Can only deal
  /// with numeric attributes.
  /// </summary>
  public class SimpleLinearRegression<T> : BaseClassifier<T, SimpleLinearRegression> where T : new()
  {
    public SimpleLinearRegression(Runtime<T> rt) : base(rt, new SimpleLinearRegression()) {}

    /// <summary>
    /// 
    /// </summary>    
    public SimpleLinearRegression<T> SuppressErrorMessage (bool s) {
      ((SimpleLinearRegression)Impl).setSuppressErrorMessage(s);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SimpleLinearRegression<T> Debug (bool debug) {
      ((SimpleLinearRegression)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}