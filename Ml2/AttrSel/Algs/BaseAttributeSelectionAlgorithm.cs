using Ml2.AttrSel.Evals;
using weka.attributeSelection;

namespace Ml2.AttrSel.Algs
{
  public class BaseAttributeSelectionAlgorithm<T> {
    protected readonly Runtime<T> rt;
    protected readonly ASSearch impl;    
    
    public BaseAttributeSelectionAlgorithm(Runtime<T> rt, ASSearch impl) { 
      this.rt = rt;
      this.impl = impl; 
    }

    public int[] Search(BaseAttributeSelectionEvaluator<T> eval) { return impl.search(eval.GetImpl(), rt.Instances); }
  }
}