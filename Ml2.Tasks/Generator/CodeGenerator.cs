using System;
using System.IO;
using System.Linq;
using Ml2.Tasks.Generator.AttrSelEval;
using NUnit.Framework;
using weka.attributeSelection;

namespace Ml2.Tasks.Generator
{
  [TestFixture, Ignore("Run Manually")] public class CodeGenerator
  {
    [Test] public void GenerateEvaluators()
    {
      var evals = typeof (CfsSubsetEval).Assembly.
          GetTypes().
          Where(t => !t.IsAbstract && typeof (ASEvaluation).IsAssignableFrom(t)).
          ToArray();
      Array.ForEach(evals, t => RunT4Template(typeof(AttributeSelectionEvaluator), t));

    }

    private void RunT4Template(Type template, Type t)
    {
      var eval = (IMl2CodeGenerator) Activator.CreateInstance(template, t);
      if (!eval.IsSupported) return;
      var output = @"..\..\..\Ml2\AttrSel\Evals\Generated\" + eval.TypeName + ".cs";
      if (File.Exists(output)) File.Delete(output);
      Console.WriteLine("Generating Evaluator:  " + t.Name);
      File.WriteAllText(output, eval.TransformText());
    }
  }
}