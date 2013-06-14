using System.Collections.Generic;
using weka.core;
using weka.filters;

namespace Ml2.Fltr
{
  public class BaseFilter<T, I> where I : Filter where T : new()
  {
    protected readonly Runtime<T> rt;

    public BaseFilter(Runtime<T> rt, I impl)
    {
      this.rt = rt;
      Impl = impl;
    }

    public I Impl { get; private set;}

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