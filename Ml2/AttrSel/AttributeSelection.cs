using Ml2.AttrSel.Algs;
using Ml2.AttrSel.Evals;
using weka.core;

namespace Ml2.AttrSel
{
  public class AttributeSelection<T>
  {
    public AttributeSelection(Runtime<T> rt)
    {
      Algorithms = new Algorithms<T>(rt);
      Evaluators = new Evaluators<T>(rt);
    }

    public Algorithms<T> Algorithms { get; private set; }
    public Evaluators<T> Evaluators { get; private set; }
  }
}