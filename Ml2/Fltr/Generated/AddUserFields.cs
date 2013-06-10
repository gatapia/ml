using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that adds new attributes with user specified type and constant
  /// value. Numeric, nominal, string and date attributes can be created.
  /// Attribute name, and value can be set with environment variables. Date attributes
  /// can also specify a formatting string by which to parse the supplied date
  /// value. Alternatively, a current time stamp can be specified by supplying the
  /// special string "now" as the value for a date attribute.
  /// </summary>
  public class AddUserFields<T> : BaseFilter<T>
  {
    public AddUserFields(Runtime<T> rt) : base(rt, new AddUserFields()) {}

        
  }
}