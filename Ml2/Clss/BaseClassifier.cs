using System.IO;
using weka.classifiers;
using weka.core;

namespace Ml2.Clss
{
  public class BaseClassifier<T, I> where I : Classifier
  {
    protected readonly Runtime<T> rt;
    public I Impl { get; private set; }    

    public BaseClassifier(Runtime<T> rt, I impl)
    {
      this.rt = rt;
      Impl = impl;
    }

    public BaseClassifier<T, I> Build()
    {
      Impl.buildClassifier(rt.Instances);
      return this;
    }

    public double Classify(T row)
    {
      return Impl.classifyInstance(rt.GetRowInstance(row));
    }

    public BaseClassifier<T, I> Flush(string file) {
      if (File.Exists(file)) File.Delete(file);
      SerializationHelper.write(file, Impl);
      return this;
    }
  }

  public static class BaseClassifier {
    public static Classifier Read(string file) {
      return (Classifier) SerializationHelper.read(file);
    }
  }
}