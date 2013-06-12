using System.Collections.Generic;
using weka.core;
using weka.filters;

namespace Ml2.Fltr
{
  public class BaseFilter<T>
  {
    protected readonly Runtime<T> rt;

    public BaseFilter(Runtime<T> rt, Filter impl)
    {
      this.rt = rt;
      Impl = impl;
    }

    public Filter Impl { get; private set;}

    public Runtime<T> RunFilter()
    {
      var newrows = new List<T>();
      for (int i = 0; i < rt.Instances.numInstances(); i++) { 
        if (Impl.input(rt.Instances.instance(i))) { newrows.Add(rt.Rows[i]); }
      }
      Impl.batchFinished();

      Instances newData = Impl.getOutputFormat();
      Instance processed;
      while ((processed = Impl.output()) != null) { newData.add(processed); }
      var newrt = new Runtime<T>(newData, newrows.ToArray());
      return newrt;
    }
  }
}