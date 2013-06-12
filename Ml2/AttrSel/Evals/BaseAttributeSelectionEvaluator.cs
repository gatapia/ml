using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class BaseAttributeSelectionEvaluator<T> {
    protected readonly Runtime<T> rt;
    public ASEvaluation Impl { get; private set; }
    
    public BaseAttributeSelectionEvaluator(Runtime<T> rt, ASEvaluation impl) { 
      this.rt = rt;
      this.Impl = impl; 
    }

    public ASEvaluation GetImpl() { return Impl; }
  }
}