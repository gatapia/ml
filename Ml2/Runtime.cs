using System;
using Ml2.Arff;
using weka.core;

namespace Ml2
{
  public class Runtime
  {
    private readonly ILoaderFactory loaderFactory = new LoaderFactory();
    private readonly IArffInstanceBuilder arff = new ArffInstanceBuilder();

    public Instances Instances { get; private set; }

    public Runtime Load<T>(params string[] files)
    {
      Instances = arff.Build(loaderFactory.Get<T>().Load<T>(files));
      return this;
    }
  }
}