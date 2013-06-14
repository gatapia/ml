using Ml2.AttrSel.Evals;
using weka.attributeSelection;

namespace Ml2.AttrSel.Algs
{
  public interface IBaseAttributeSelectionAlgorithm<out I> where I : ASSearch {
    I Impl { get; }
    int[] Search<E>(IBaseAttributeSelectionEvaluator<E> eval) where E : ASEvaluation;
  }

  public class BaseAttributeSelectionAlgorithm<T, I> : IBaseAttributeSelectionAlgorithm<I> where I : ASSearch where T : new() {
    protected readonly Runtime<T> rt;
    public I Impl { get; private set; }
    
    public BaseAttributeSelectionAlgorithm(Runtime<T> rt, I impl) { 
      this.rt = rt;
      Impl = impl; 
    }

    public int[] Search<E>(IBaseAttributeSelectionEvaluator<E> eval) where E : ASEvaluation { 
      return Impl.search(eval.Impl, rt.Instances); 
    }
  }
}