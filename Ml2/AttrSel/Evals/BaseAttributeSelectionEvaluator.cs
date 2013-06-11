using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class BaseAttributeSelectionEvaluator<T> {
    protected readonly Runtime<T> rt;
    protected readonly ASEvaluation impl;    
    
    public BaseAttributeSelectionEvaluator(Runtime<T> rt, ASEvaluation impl) { 
      this.rt = rt;
      this.impl = impl; 
    }

    public ASEvaluation GetImpl() { return impl; }
  }
}