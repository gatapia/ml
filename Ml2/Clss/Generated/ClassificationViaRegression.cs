using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for doing classification using regression methods. Class is
  /// binarized and one regression model is built for each class value. For more
  /// information, see, for example E. Frank, Y. Wang, S. Inglis, G. Holmes, I.H. Witten
  /// (1998). Using model trees for classification. Machine Learning.
  /// 32(1):63-76.
  /// </summary>
  public class ClassificationViaRegression<T> : BaseClassifier<T>
  {
    public ClassificationViaRegression(Runtime<T> rt) : base(rt, new ClassificationViaRegression()) {}

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public ClassificationViaRegression<T> Debug (bool value) {
      ((ClassificationViaRegression)impl).setDebug(value);
      return this;
    }

        
  }
}