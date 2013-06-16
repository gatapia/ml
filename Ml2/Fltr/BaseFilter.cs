using System.Collections.Generic;
using weka.core;
using weka.filters;

namespace Ml2.Fltr
{
  public interface IBaseFilter<T, out I> where T : new() where I : Filter {
    I Impl { get; }
    Runtime<T> RunFilter();
  }

  public class BaseFilter<T, I> : IBaseFilter<T, I> where I : Filter where T : new()
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
      Impl.setInputFormat(rt.Instances);

      var num = rt.Instances.numInstances();
      var observations = new List<Observation<T>>();
      for (int i = 0; i < num; i++)
      {
        // var observations = rt.Observations.Where(o => Impl.input(o.Instance)).ToArray();        
        var inst = rt.Instances.instance(i);
        if (Impl.input(inst))
        {
          observations.Add(new Observation<T> {Instance = inst, Row = rt.Observations[i].Row});
        }        
      }      
      Impl.batchFinished(); 
      var instances = Impl.getOutputFormat();
      Instance processed;
      while ((processed = Impl.output()) != null) { instances.add(processed); }
      var newrt = new Runtime<T>(instances, observations.ToArray());
      return newrt;
    }    
  }
}