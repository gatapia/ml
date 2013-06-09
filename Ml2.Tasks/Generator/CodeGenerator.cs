using System;
using System.IO;
using System.Linq;
using Ml2.Tasks.Generator.AttrSel;
using NUnit.Framework;
using weka.attributeSelection;

namespace Ml2.Tasks.Generator
{
  [TestFixture, Ignore("Run Manually")] public class CodeGenerator
  {
    [Test] public void GenerateAttributeSelectionEvaluators()
    {
      var types = GetBaseClassesOf(typeof (ASEvaluation)).
          Where(Utils.IsSupportedEvalType).
          ToArray();
      Array.ForEach(types, t => 
            RunT4Template(typeof(AttributeSelectionEvaluator), t, @"AttrSel\Evals\Generated"));
      RunT4TemplateImpl(new Evaluators(types), @"AttrSel\Evals\Generated\Evaluators");
    }

    [Test] public void GenerateAttributeSelectionAlgorithms()
    {
      var types = GetBaseClassesOf(typeof (ASSearch));
      Array.ForEach(types, t => 
            RunT4Template(typeof(AttributeSelectionAlgorithm), t, @"AttrSel\Algs\Generated"));

      RunT4TemplateImpl(new Algorithms(types), @"AttrSel\Algs\Generated\Algorithms");
    }

    private static Type[] GetBaseClassesOf(Type ancestor)
    {
      return typeof (CfsSubsetEval).Assembly.
        GetTypes().
        Where(t => !t.IsAbstract && ancestor.IsAssignableFrom(t)).
        ToArray();
    }

    private void RunT4Template(Type template, Type t, string dir)
    {
      var eval = (IMl2CodeGenerator) Activator.CreateInstance(template, t);
      Console.WriteLine("Generating Type:  " + t.Name);
      RunT4TemplateImpl(eval, dir + "\\" + eval.TypeName);
    }

    private static void RunT4TemplateImpl(IMl2CodeGenerator eval, string file)
    {
      var output = @"..\..\..\Ml2\" + file + ".cs";
      if (File.Exists(output)) File.Delete(output);      
      File.WriteAllText(output, eval.TransformText());
    }
  }
}