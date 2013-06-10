using weka.classifiers;

namespace Ml2.Clss
{
  public class BaseClassifier<T>
  {
    protected readonly Runtime<T> rt;
    protected readonly Classifier impl;    

    public BaseClassifier(Runtime<T> rt, Classifier impl)
    {
      this.rt = rt;
      this.impl = impl;
    }

    public BaseClassifier<T> Build()
    {
      impl.buildClassifier(rt.Instances);
      return this;
    }

    public double Classify(T row)
    {
      return impl.classifyInstance(rt.GetRowInstance(row));
    }
  }
}