﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ml2.Arff;
using Ml2.Asstn;
using Ml2.Clss;
using Ml2.Clstr;
using Ml2.Fltr;
using Ml2.RuntimeHelpers;
using weka.classifiers;
using weka.core;
using weka.core.converters;

namespace Ml2
{
  public class Runtime : Runtime<object> {
    public static T[] Load<T>(params string[] files) where T : new()
    {
      if (!files.Any()) throw new ArgumentNullException("files");
      return LoadRowsFromFiles<T>(files);
    }

    public static T[] LoadLines<T>(ICollection<string> lines, int opt_limit = 0) where T : new()
    {
      if (!lines.Any()) throw new ArgumentNullException("lines");
      if (opt_limit > 0)
      {
        var rng = new Random(1);      
        var newlines = lines.
            OrderBy(row => rng.Next()).
            Take(opt_limit).
            ToList();
        newlines.Insert(0, lines.First());
        lines = newlines;
      }      
      return new LoaderFactory().Get<T>().LoadLines<T>(lines);
      
    }

    public Runtime(int classifier, object[] data) : base(classifier, data) {}
  }

  public class Runtime<T> where T : new()
  {        
    private readonly IAttributesRemover<T> attremover = new AttributesRemover<T>();

    /// <summary>
    /// Creates an weka.core.Instances wrapper passing in the 
    /// classifier (dependant variable) column index and the raw data files.
    /// Currently only supports CSV files.
    /// </summary>
    /// <param name="classifier">The index of the classifier (dependant variable) column.</param>
    /// <param name="files">
    /// Any number of data files.  It is expected that these files are 
    /// all in the same format and that format is defined by the properties of T.
    /// </param>
    public Runtime(int classifier, params string[] files) {
      if (!files.Any()) throw new ArgumentNullException("files");
      
      var arff = new ArffInstanceBuilder<T>(LoadRowsFromFiles<T>(files)).Build();      
      Instances = arff.Instances;
      Observations = arff.Observations;
      Instances.setClassIndex(classifier);
    }

    /// <summary>
    /// Creates an weka.core.Instances wrapper passing in the 
    /// classifier (dependant variable) column index and the observations.  
    /// </summary>
    /// <param name="classifier">The index of the classifier (dependant variable) column.</param>
    /// <param name="data">The observations (instances) of data.</param>
    public Runtime(int classifier, T[] data) {
      var arff = new ArffInstanceBuilder<T>(data);
      arff.Build();
      Instances = arff.Instances;
      Observations = arff.Observations;
      Instances.setClassIndex(classifier);
    }


    /// <summary>
    /// This is used by instance filters to create a new Runtime with a 
    /// specified set of Instances and Observations.
    /// </summary>
    internal Runtime(Instances instances, Observation<T>[] observations) { 
      Instances = instances; 
      Observations = observations;
    }

    public Instances Instances { get; private set; }

    public Observation<T>[] Observations { get; private set; }

    public AttrSel.AttributeSelection<T> AttributeSelection { get { return new AttrSel.AttributeSelection<T>(this); } }

    public Clusterers<T> Clusterers { get { return new Clusterers<T>(this); } }

    public Filters<T> Filters { get { return new Filters<T>(this); } }

    public Associations<T> Associations { get { return new Associations<T>(this); } }

    public Classifiers<T> Classifiers { get { return new Classifiers<T>(this); } }

    public void SaveToArffFile(string file)
    {
      if (File.Exists(file)) File.Delete(file);
      var saver = new ArffSaver();
      saver.setInstances(Instances);
      saver.setFile(new java.io.File(file));
      saver.writeBatch();
    }

    public Runtime<T> RemoveAttributes(params object[] attributes) {
      attremover.RemoveAttributes(this, attributes);
      return this;            
    }

    public Runtime<T> EvaluateWithCrossValidation(Classifier classifier, int numfolds = 10)
    {
      new ClassifierEvaluator<T>(this, classifier).
        EvaluateWithCrossValidateion(numfolds);
      return this;
    }

    public ICollection<string> GeneratePredictions(
        Func<double, Observation<T>, int, string> outputline,
        string outheader,
        params Classifier[] classifiers)
    {
      var outlines = new List<string>();
      if (!String.IsNullOrWhiteSpace(outheader)) outlines.Add(outheader);
      return Observations.Select((obs, idx) => 
          outputline(ClassifyInstance(classifiers, obs), obs, idx)).
        ToArray();      
    }

    private static double ClassifyInstance(Classifier[] classifiers, Observation<T> obs) {
      return classifiers.Select(c => c.classifyInstance(obs.Instance)).GetMajority();
    }

    protected static T2[] LoadRowsFromFiles<T2>(string[] files) where T2 : new()
    {
      return new LoaderFactory().Get<T2>(files.First().Split('.').Last()).Load<T2>(files);
    }
  }
}