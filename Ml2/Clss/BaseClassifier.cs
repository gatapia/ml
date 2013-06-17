using System.IO;
using weka.classifiers;
using weka.core;

namespace Ml2.Clss
{
  public interface IBaseClassifier<T, out I> where T : new() where I : Classifier {
    Runtime<T> Runtime { get; }
    I Impl { get; }
    double Classify(Instance instance);
    double Classify(Observation<T> obs);
    IBaseClassifier<T, I> Build();
    IBaseClassifier<T, I> FlushToFile(string file);
    IBaseClassifier<T, I> EvaluateWith10CrossValidation();
  }

  public class BaseClassifier<T, I> : IBaseClassifier<T, I> where I : Classifier where T : new()
  {
    private bool built;
    public Runtime<T> Runtime { get; private set; }
    public I Impl { get; private set; }    

    public BaseClassifier(Runtime<T> rt, I impl)
    {
      Runtime = rt;
      Impl = impl;
    }

    public double Classify(Instance instance)
    {
      Build();
      return Impl.classifyInstance(instance);
    }

    public double Classify(Observation<T> obs)
    {
      Build();
      return Impl.classifyInstance(obs.Instance);
    }

    public IBaseClassifier<T, I> FlushToFile(string file) {
      Build();
      if (File.Exists(file)) File.Delete(file);
      SerializationHelper.write(file, Impl);
      return this;
    }

    public IBaseClassifier<T, I> EvaluateWith10CrossValidation()
    {
      Build();
      Runtime.EvaluateWith10CrossValidateion(Impl);
      return this;

    }

    public IBaseClassifier<T, I> Build()
    {
      if (built) return this;
      built = true;

      Impl.buildClassifier(Runtime.Instances);
      
      return this;
    }
  }

  public static class BaseClassifier {
    public static Classifier Read(string file) {
      return (Classifier) SerializationHelper.read(file);
    }
  }
}