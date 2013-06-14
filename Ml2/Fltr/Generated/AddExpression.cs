using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that creates a new attribute by applying a
  /// mathematical expression to existing attributes. The expression can contain attribute
  /// references and numeric constants. Supported operators are : +, -, *, /, ^,
  /// log, abs, cos, exp, sqrt, floor, ceil, rint, tan, sin, (, ) Attributes are
  /// specified by prefixing with 'a', eg. a7 is attribute number 7 (starting from
  /// 1). Example expression : a1^2*a5/log(a7*4.0).
  /// </summary>
  public class AddExpression<T> : BaseFilter<T, AddExpression> where T : new()
  {
    public AddExpression(Runtime<T> rt) : base(rt, new AddExpression()) {}

    /// <summary>
    /// Set the name of the new attribute.
    /// </summary>    
    public AddExpression<T> Name (string name) {
      ((AddExpression)Impl).setName(name);
      return this;
    }

    /// <summary>
    /// Set the math expression to apply. Eg. a1^2*a5/log(a7*4.0)
    /// </summary>    
    public AddExpression<T> Expression (string expr) {
      ((AddExpression)Impl).setExpression(expr);
      return this;
    }

    /// <summary>
    /// Set debug mode. If true then the new attribute will be named with the
    /// postfix parse of the supplied expression.
    /// </summary>    
    public AddExpression<T> Debug (bool d) {
      ((AddExpression)Impl).setDebug(d);
      return this;
    }

        
        
  }
}