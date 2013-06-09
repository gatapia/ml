using System.IO;
using Ml2.Arff;
using Ml2.AttributeSelection;
using Ml2.Misc;
using weka.core;
using weka.core.converters;

namespace Ml2
{
  public class Runtime
  {
    private readonly IArffInstanceBuilder arff = new ArffInstanceBuilder();
    private readonly IClassifierIndexInferer classidx = new ClassifierIndexInferer();
    private readonly ILoaderFactory loaderFactory = new LoaderFactory();

    public Instances Instances { get; private set; }

    public Algorithms AttributeSelectionAlgorithms
    {
      get { return new Algorithms(Instances); }
    }

    public Evaluations AttributeSelectionEvaluations
    {
      get { return new Evaluations(Instances); }
    }

    public Runtime Load<T>(params string[] files)
    {
      Instances = arff.Build(loaderFactory.Get<T>().Load<T>(files));
      return SetClassifierIndex(classidx.InferClassIndex<T>());
    }

    public Runtime SetClassifierIndex(int idx)
    {
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
  }
}