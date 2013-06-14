﻿using System;
using System.IO;
using Ml2.Arff;
using Ml2.Asstn;
using Ml2.Clss;
using Ml2.Clstr;
using Ml2.Fltr;
using weka.core;
using weka.core.converters;

namespace Ml2
{
  public class Runtime : Runtime<object> {
    public static T[] Load<T>(params string[] files) where T : new() {
      var lf = new LoaderFactory();
      return lf.Get<T>().Load<T>(files);
    }
    
    public Runtime(object[] data, int classifier) : base(data, classifier) {}
  }

  public class Runtime<T> where T : new()
  {
    private readonly IArffInstanceBuilder arff = new ArffInstanceBuilder();
    private readonly ILoaderFactory loaderFactory = new LoaderFactory();

    public Runtime(int classifier, params string[] files) {
      Rows = loaderFactory.Get<T>().Load<T>(files);
      
      Instances = arff.Build(Rows);      
      Instances.setClassIndex(classifier);
    }

    public Runtime(T[] data, int classifier) {
      Rows = data;
      Instances = arff.Build(Rows);      
      Instances.setClassIndex(classifier);
    }


    /// <summary>
    /// This is used by instance filters to create a new Runtime with a 
    /// specified set of Instances and Rows.
    /// </summary>
    internal Runtime(Instances instances, T[] rows) { 
      Instances = instances; 
      Rows = rows;
    }    

    public Instances Instances { get; private set; }
    public T[] Rows { get; private set; }

    public AttrSel.AttributeSelection<T> AttributeSelection { get { return new AttrSel.AttributeSelection<T>(this); } }
    public Clusterers<T> Clusterers { get { return new Clusterers<T>(this); } }
    public Filters<T> Filters { get { return new Filters<T>(this); } }
    public Associations<T> Associations { get { return new Associations<T>(this); } }
    public Classifiers<T> Classifiers { get { return new Classifiers<T>(this); } }    

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
      var idx = Array.IndexOf(Rows, row);
      return Instances.instance(idx);
    }
  }
}