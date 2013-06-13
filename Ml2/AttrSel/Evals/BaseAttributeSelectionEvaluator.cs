using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public class BaseAttributeSelectionEvaluator<T, I> where I : ASEvaluation {
    protected readonly Runtime<T> rt;
    public I Impl { get; private set; }
    
    public BaseAttributeSelectionEvaluator(Runtime<T> rt, I impl) { 
      this.rt = rt;
      Impl = impl; 
    }    
  }
}