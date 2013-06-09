using weka.attributeSelection;

namespace Ml2.AttrSel
{
  public interface IAttributeSelectionEvaluation
  {
    ASEvaluation GetImpl();
  }
}