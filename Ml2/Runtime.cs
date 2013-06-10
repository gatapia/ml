using System;
using System.Diagnostics;
using System.IO;
using Ml2.Arff;
using Ml2.Asstn;
using Ml2.AttrSel;
using Ml2.Clss;
using Ml2.Clstr;
using Ml2.Fltr;
using Ml2.Misc;
using weka.core;
using weka.core.converters;

namespace Ml2
{
  public class Runtime<T>
  {
    private readonly IArffInstanceBuilder arff = new ArffInstanceBuilder();
    private readonly IClassifierIndexInferer classidx = new ClassifierIndexInferer();
    private readonly ILoaderFactory loaderFactory = new LoaderFactory();

    public Runtime() {}
    public Runtime(Instances instances) { Instances = instances; }

    public Instances Instances { get; private set; }
    public T[] Rows { get; private set; }

    public AttributeSelection AttributeSelection { get { return new AttributeSelection(Instances); } }
    public Clusterers<T> Clusterers { get { return new Clusterers<T>(this); } }
    public Filters<T> Filters { get { return new Filters<T>(this); } }
    public Associations<T> Associations { get { return new Associations<T>(this); } }
    public Classifiers<T> Classifiers { get { return new Classifiers<T>(this); } }
    
    public Runtime<T> Load(params string[] files)
    {
      Trace.Assert(Rows == null, "Runtime has already been initialised.");

      Rows = loaderFactory.Get<T>().Load<T>(files);
      Instances = arff.Build(Rows);
      return SetClassifierIndex(classidx.InferClassIndex<T>());
    }

    public Runtime<T> SetClassifierIndex(int idx) {
      Instances.setClassIndex(idx);
      return this;
    }

    public void FlushToFile(string file)
    {
      if (File.Exists(file)) File.Delete(file);
      var saver = new ArffSaver();
      saver.setInstances(Instances);
      saver.setFile(new java.io.File(file));
      saver.writeBatch();
    }

    public Instance GetRowInstance(T row)
    {
      Trace.Assert(Rows != null, "Runtime has not been initialised with a call to Load.");

      var idx = Array.IndexOf(Rows, row);
      return Instances.instance(idx);
    }
  }
}