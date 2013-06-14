using System.IO;
using weka.classifiers;
using weka.core;

namespace Ml2.Clss
{
  public interface IBaseClassifier<T, out I> where T : new() where I : Classifier {
    Runtime<T> Runtime { get; }
    I Impl { get; }
    IBaseClassifier<T, I> Build();
    double Classify(Instance instance);
    IBaseClassifier<T, I> Flush(string file);
    void EvaluateWith10CrossValidateion();
  }

  public class BaseClassifier<T, I> : IBaseClassifier<T, I> where I : Classifier where T : new()
  {
    public Runtime<T> Runtime { get; private set; }
    public I Impl { get; private set; }    

    public BaseClassifier(Runtime<T> rt, I impl)
    {
      Runtime = rt;
      Impl = impl;
    }

    public IBaseClassifier<T, I> Build()
    {
      Impl.buildClassifier(Runtime.Instances);
      return this;
    }

    public double Classify(Instance instance)
    {
      return Impl.classifyInstance(instance);
    }

    public IBaseClassifier<T, I> Flush(string file) {
      if (File.Exists(file)) File.Delete(file);
      SerializationHelper.write(file, Impl);
      return this;
    }

    public void EvaluateWith10CrossValidateion() { Runtime.EvaluateWith10CrossValidateion(Impl); }    
  }

  public static class BaseClassifier {
    public static Classifier Read(string file) {
      return (Classifier) SerializationHelper.read(file);
    }
  }
}