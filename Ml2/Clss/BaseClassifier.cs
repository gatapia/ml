using weka.classifiers;

namespace Ml2.Clss
{
  public class BaseClassifier<T>
  {
    protected readonly Runtime<T> rt;
    public Classifier Impl { get; private set; }    

    public BaseClassifier(Runtime<T> rt, Classifier impl)
    {
      this.rt = rt;
      Impl = impl;
    }

    public BaseClassifier<T> Build()
    {
      Impl.buildClassifier(rt.Instances);
      return this;
    }

    public double Classify(T row)
    {
      return Impl.classifyInstance(rt.GetRowInstance(row));
    }
  }
}