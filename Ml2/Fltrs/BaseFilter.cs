using weka.core;
using weka.filters;

namespace Ml2.Fltrs
{
  public class BaseFilter<T>
  {
    protected readonly Filter impl;
    protected readonly Runtime<T> rt;

    public BaseFilter(Runtime<T> rt, Filter impl)
    {
      this.rt = rt;
      this.impl = impl;
    }

    public Runtime<T> RunFilter()
    {
      for (int i = 0; i < rt.Instances.numInstances(); i++) { impl.input(rt.Instances.instance(i)); }
      impl.batchFinished();

      Instances newData = impl.getOutputFormat();
      Instance processed;
      while ((processed = impl.output()) != null) { newData.add(processed); }
      var newrt = new Runtime<T>(newData);
      return newrt;
    }
  }
}