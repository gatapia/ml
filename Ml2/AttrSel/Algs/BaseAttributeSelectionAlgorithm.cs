using Ml2.AttrSel.Evals;
using weka.attributeSelection;

namespace Ml2.AttrSel.Algs
{
  public class BaseAttributeSelectionAlgorithm<T> {
    protected readonly Runtime<T> rt;
    public ASSearch Impl { get; private set; }
    
    public BaseAttributeSelectionAlgorithm(Runtime<T> rt, ASSearch impl) { 
      this.rt = rt;
      this.Impl = impl; 
    }

    public int[] Search(BaseAttributeSelectionEvaluator<T> eval) { return Impl.search(eval.GetImpl(), rt.Instances); }
  }
}