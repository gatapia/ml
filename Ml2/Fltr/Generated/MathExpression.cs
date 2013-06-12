using weka.core;
using weka.filters.unsupervised.attribute;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// Modify numeric attributes according to a given expression
  /// </summary>
  public class MathExpression<T> : BaseFilter<T>
  {
    public MathExpression(Runtime<T> rt) : base(rt, new MathExpression()) {}

    /// <summary>
    /// Determines whether action is to select or unselect. If set to true, only
    /// the specified attributes will be modified; If set to false, specified
    /// attributes will not be modified.
    /// </summary>    
    public MathExpression<T> InvertSelection (bool value) {
      ((MathExpression)Impl).setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// Specify the expression to apply. The 'A' letterrefers to the value of the
    /// attribute being processed. MIN,MAX,MEAN,SDrefer respectively to minimum,
    /// maximum, mean andstandard deviation of the attribute being processed. Other
    /// attribute values (numeric only) can be accessed through the variables A1,
    /// A2, A3, ... 	Supported operators are +, -, *, /, pow, log,abs, cos, exp,
    /// sqrt, tan, sin, ceil, floor, rint, (, ),A,MEAN, MAX, MIN, SD, COUNT, SUM,
    /// SUMSQUARED, ifelse 	Eg. pow(A,6)/(MEAN+MAX)*ifelse(A<0,0,sqrt(A))+ifelse(![A>9
    /// && A<15])
    /// </summary>    
    public MathExpression<T> Expression (string value) {
      ((MathExpression)Impl).setExpression(value);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public MathExpression<T> IgnoreRange (string value) {
      ((MathExpression)Impl).setIgnoreRange(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MathExpression<T> InputFormat (Runtime<T> value) {
      ((MathExpression)Impl).setInputFormat(value.Instances);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public MathExpression<T> IgnoreClass (bool value) {
      ((MathExpression)Impl).setIgnoreClass(value);
      return this;
    }

        
        
  }
}