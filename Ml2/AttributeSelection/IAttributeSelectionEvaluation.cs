using weka.attributeSelection;

namespace Ml2.AttributeSelection
{
  public interface IAttributeSelectionEvaluation
  {
    ASEvaluation GetImpl();
  }
}