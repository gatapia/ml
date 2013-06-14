using System;
using System.IO;
using weka.classifiers;

namespace Ml2.RuntimeHelpers
{
  public class ClassifierEvaluator<T> where T : new()
  {
    private readonly Runtime<T> runtime;
    private readonly Classifier classifier;

    public ClassifierEvaluator(Runtime<T> runtime, Classifier classifier)
    {
      this.runtime = runtime;
      this.classifier = classifier;
    }

    public void EvaluateWith10CrossValidateion()
    {
      var evaluation = new Evaluation(runtime.Instances);
      var seed = DateTime.Now.Millisecond;
      var rng = new java.util.Random(seed);
      evaluation.crossValidateModel(classifier, runtime.Instances, 10, rng);
      Console.WriteLine(FlushResultsToFile(seed, evaluation));
    }

    private string FlushResultsToFile(int seed, Evaluation eval)
    {
      var date = DateTime.Now;
      var filename = date.ToString("yyyyMMddTHHmmss.") + classifier.GetType().Name.ToLower() + ".eval";
      if (File.Exists(filename)) File.Delete(filename);
      var contents = eval.toSummaryString("Summary:\n=======\n\n", true) +
                     eval.toClassDetailsString("\n\nClass Details:\n=============\n\n") +
                     "\n\nEvaluator Seed: " + seed;
          
      File.WriteAllText(filename, contents);
      return contents;
    }
  }
}