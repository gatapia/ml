using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a multinomial logistic regression model with
  /// a ridge estimator. There are some modifications, however, compared to the
  /// paper of leCessie and van Houwelingen(1992): If there are k classes for n
  /// instances with m attributes, the parameter matrix B to be calculated will be
  /// an m*(k-1) matrix. The probability for class j with the exception of the
  /// last class is Pj(Xi) = exp(XiBj)/((sum[j=1..(k-1)]exp(Xi*Bj))+1) The last
  /// class has probability 1-(sum[j=1..(k-1)]Pj(Xi)) 	=
  /// 1/((sum[j=1..(k-1)]exp(Xi*Bj))+1) The (negative) multinomial log-likelihood is thus: L =
  /// -sum[i=1..n]{ 	sum[j=1..(k-1)](Yij * ln(Pj(Xi))) 	+(1 - (sum[j=1..(k-1)]Yij)) 	* ln(1 -
  /// sum[j=1..(k-1)]Pj(Xi)) 	} + ridge * (B^2) In order to find the matrix B
  /// for which L is minimised, a Quasi-Newton Method is used to search for the
  /// optimized values of the m*(k-1) variables. Note that before we use the
  /// optimization procedure, we 'squeeze' the matrix B into a m*(k-1) vector. For
  /// details of the optimization procedure, please check weka.core.Optimization
  /// class. Although original Logistic Regression does not deal with instance
  /// weights, we modify the algorithm a little bit to handle the instance weights. For
  /// more information see: le Cessie, S., van Houwelingen, J.C. (1992). Ridge
  /// Estimators in Logistic Regression. Applied Statistics. 41(1):191-201. Note:
  /// Missing values are replaced using a ReplaceMissingValuesFilter, and nominal
  /// attributes are transformed into numeric attributes using a
  /// NominalToBinaryFilter.
  /// </summary>
  public class Logistic<T> : BaseClassifier<T, Logistic>
  {
    public Logistic(Runtime<T> rt) : base(rt, new Logistic()) {}

    /// <summary>
    /// Output debug information to the console.
    /// </summary>    
    public Logistic<T> Debug (bool debug) {
      ((Logistic)Impl).setDebug(debug);
      return this;
    }

    /// <summary>
    /// Use conjugate gradient descent rather than BFGS updates; faster for
    /// problems with many parameters.
    /// </summary>    
    public Logistic<T> UseConjugateGradientDescent (bool useConjugateGradientDescent) {
      ((Logistic)Impl).setUseConjugateGradientDescent(useConjugateGradientDescent);
      return this;
    }

    /// <summary>
    /// Set the Ridge value in the log-likelihood.
    /// </summary>    
    public Logistic<T> Ridge (double ridge) {
      ((Logistic)Impl).setRidge(ridge);
      return this;
    }

    /// <summary>
    /// Maximum number of iterations to perform.
    /// </summary>    
    public Logistic<T> MaxIts (int newMaxIts) {
      ((Logistic)Impl).setMaxIts(newMaxIts);
      return this;
    }

        
        
  }
}