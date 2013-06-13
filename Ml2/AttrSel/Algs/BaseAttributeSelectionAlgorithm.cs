using Ml2.AttrSel.Evals;
using weka.attributeSelection;

namespace Ml2.AttrSel.Algs
{
  public class BaseAttributeSelectionAlgorithm<T, I> where I : ASSearch {
    protected readonly Runtime<T> rt;
    public I Impl { get; private set; }
    
    public BaseAttributeSelectionAlgorithm(Runtime<T> rt, I impl) { 
      this.rt = rt;
      Impl = impl; 
    }

    public int[] Search<E>(BaseAttributeSelectionEvaluator<T, E> eval) where E : ASEvaluation { 
      return Impl.search(eval.Impl, rt.Instances); 
    }
  }
}