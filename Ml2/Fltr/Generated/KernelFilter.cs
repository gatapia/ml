using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Converts the given set of predictor variables into a kernel matrix. The
  /// class value remains unchangedm, as long as the preprocessing filter doesn't
  /// change it. By default, the data is preprocessed with the Center filter, but
  /// the user can choose any filter (NB: one must be careful that the filter
  /// does not alter the class attribute unintentionally). With
  /// weka.filters.AllFilter the preprocessing gets disabled. For more information regarding
  /// preprocessing the data, see: K.P. Bennett, M.J. Embrechts: An Optimization
  /// Perspective on Kernel Partial Least Squares Regression. In: Advances in Learning
  /// Theory: Methods, Models and Applications, 227-249, 2003.
  /// </summary>
  public class KernelFilter<T> : BaseFilter<T>
  {
    public KernelFilter(Runtime<T> rt) : base(rt, new KernelFilter()) {}

    /// <summary>
    /// Turns time-consuming checks off - use with caution.
    /// </summary>    
    public KernelFilter<T> ChecksTurnedOff (bool value) {
      ((KernelFilter)impl).setChecksTurnedOff(value);
      return this;
    }
    /// <summary>
    /// The class index of the dataset to initialize the filter with (first and
    /// last are valid).
    /// </summary>    
    public KernelFilter<T> InitFileClassIndex (string value) {
      ((KernelFilter)impl).setInitFileClassIndex(value);
      return this;
    }
    /// <summary>
    /// The factor for the kernel, with A = # of attributes and N = # of
    /// instances.
    /// </summary>    
    public KernelFilter<T> KernelFactorExpression (string value) {
      ((KernelFilter)impl).setKernelFactorExpression(value);
      return this;
    }
    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public KernelFilter<T> Debug (bool value) {
      ((KernelFilter)impl).setDebug(value);
      return this;
    }
        
  }
}