using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Filters instances according to a user-specified expression. Grammar:
  /// boolexpr_list ::= boolexpr_list boolexpr_part | boolexpr_part; boolexpr_part
  /// ::= boolexpr:e {: parser.setResult(e); :} ; boolexpr ::= BOOLEAN | true |
  /// false | expr < expr | expr <= expr | expr > expr | expr >= expr | expr = expr
  /// | ( boolexpr ) | not boolexpr | boolexpr and boolexpr | boolexpr or
  /// boolexpr | ATTRIBUTE is STRING ; expr ::= NUMBER | ATTRIBUTE | ( expr ) | opexpr |
  /// funcexpr ; opexpr ::= expr + expr | expr - expr | expr * expr | expr /
  /// expr ; funcexpr ::= abs ( expr ) | sqrt ( expr ) | log ( expr ) | exp ( expr )
  /// | sin ( expr ) | cos ( expr ) | tan ( expr ) | rint ( expr ) | floor (
  /// expr ) | pow ( expr for base , expr for exponent ) | ceil ( expr ) ; Notes: -
  /// NUMBER any integer or floating point number (but not in scientific
  /// notation!) - STRING any string surrounded by single quotes; the string may not
  /// contain a single quote though. - ATTRIBUTE the following placeholders are
  /// recognized for attribute values: - CLASS for the class value in case a class
  /// attribute is set. - ATTxyz with xyz a number from 1 to # of attributes in the
  /// dataset, representing the value of indexed attribute. Examples: -
  /// extracting only mammals and birds from the 'zoo' UCI dataset: (CLASS is 'mammal') or
  /// (CLASS is 'bird') - extracting only animals with at least 2 legs from the
  /// 'zoo' UCI dataset: (ATT14 >= 2) - extracting only instances with
  /// non-missing 'wage-increase-second-year' from the 'labor' UCI dataset: not
  /// ismissing(ATT3)
  /// </summary>
  public class SubsetByExpression<T> : BaseFilter<T>
  {
    public SubsetByExpression(Runtime<T> rt) : base(rt, new SubsetByExpression()) {}

    /// <summary>
    /// The expression to used for filtering the dataset.
    /// </summary>    
    public SubsetByExpression<T> Expression (string value) {
      ((SubsetByExpression)Impl).setExpression(value);
      return this;
    }

    /// <summary>
    /// Whether to apply the filtering process to instances that are input after
    /// the first (training) batch. The default is false so that, when used in a
    /// FilteredClassifier, test instances do not potentially get 'consumed' by the
    /// filter an a prediction is always made.
    /// </summary>    
    public SubsetByExpression<T> FilterAfterFirstBatch (bool b) {
      ((SubsetByExpression)Impl).setFilterAfterFirstBatch(b);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public SubsetByExpression<T> Debug (bool value) {
      ((SubsetByExpression)Impl).setDebug(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public SubsetByExpression<T> InputFormat (Runtime<T> instanceInfo) {
      ((SubsetByExpression)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

        
        
  }
}