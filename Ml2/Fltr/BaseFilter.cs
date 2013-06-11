using System.Collections.Generic;
using weka.core;
using weka.filters;

namespace Ml2.Fltr
{
  public class BaseFilter<T>
  {
    protected readonly Runtime<T> rt;
    protected readonly Filter impl;    

    public BaseFilter(Runtime<T> rt, Filter impl)
    {
      this.rt = rt;
      this.impl = impl;
    }

    public Runtime<T> RunFilter()
    {
      var newrows = new List<T>();
      for (int i = 0; i < rt.Instances.numInstances(); i++) { 
        if (impl.input(rt.Instances.instance(i))) { newrows.Add(rt.Rows[i]); }
      }
      impl.batchFinished();

      Instances newData = impl.getOutputFormat();
      Instance processed;
      while ((processed = impl.output()) != null) { newData.add(processed); }
      var newrt = new Runtime<T>(newData, newrows.ToArray());
      return newrt;
    }
  }
}