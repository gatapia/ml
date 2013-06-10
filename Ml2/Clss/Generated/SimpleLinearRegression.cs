using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// Learns a simple linear regression model. Picks the attribute that results
  /// in the lowest squared error. Missing values are not allowed. Can only deal
  /// with numeric attributes.
  /// </summary>
  public class SimpleLinearRegression<T> : BaseClassifier<T>
  {
    public SimpleLinearRegression(Runtime<T> rt) : base(rt, new SimpleLinearRegression()) {}

    /// <summary>
    /// 
    /// </summary>    
    public SimpleLinearRegression<T> SuppressErrorMessage (bool value) {
      ((SimpleLinearRegression)impl).setSuppressErrorMessage(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SimpleLinearRegression<T> Debug (bool value) {
      ((SimpleLinearRegression)impl).setDebug(value);
      return this;
    }

        
  }
}