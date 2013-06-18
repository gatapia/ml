using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public interface IBaseAttributeSelectionEvaluator<out I> where I : ASEvaluation {
    I Impl { get; }
  }

  public class BaseAttributeSelectionEvaluator<T, I> : IBaseAttributeSelectionEvaluator<I> where I : ASEvaluation where T : new() {
    protected readonly Runtime<T> rt;
    public I Impl { get; private set; }
    
    public BaseAttributeSelectionEvaluator(Runtime<T> rt, I impl) { 
      this.rt = rt;
      Impl = impl; 

      InternalHelpers.SetSeedOnInstance(impl);
    }    
  }
}