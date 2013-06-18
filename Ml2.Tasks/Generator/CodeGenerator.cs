using System;
using System.IO;
using System.Linq;
using Ml2.Tasks.Generator.Asstn;
using Ml2.Tasks.Generator.AttrSel;
using Ml2.Tasks.Generator.Clss;
using Ml2.Tasks.Generator.Clstr;
using Ml2.Tasks.Generator.Fltr;
using NUnit.Framework;
using weka.associations;
using weka.attributeSelection;
using weka.classifiers;
using weka.clusterers;
using weka.filters;

namespace Ml2.Tasks.Generator
{
  [TestFixture, Ignore("Run Manually")] public class CodeGenerator
  {
    [Test] public void GenerateAttributeSelectionEvaluators()
    {
      var types = GetBaseClassesOf(typeof (ASEvaluation)).
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

    [Test] public void GenerateClusterers()
    {
      var types = GetBaseClassesOf(typeof (AbstractClusterer));
      Array.ForEach(types, t => 
             RunT4Template(typeof(ClustererAlgorithm), t, @"Clstr\Generated"));

      RunT4TemplateImpl(new Clusterers(types), @"Clstr\Generated\Clusterers");
    }

    [Test] public void GenerateAllFilters()
    {      
      var types = GetBaseClassesOf(typeof (Filter));
      var namespaces = types.
          Select(t => t.Namespace).
          Distinct().
          ToList();
      namespaces.ForEach(GenerateCodeForFilterNamespace);
      
      Array.ForEach(types, t => RunT4Template(typeof(FilterAlgorithm), t, @"Fltr\Generated"));
    }

    private void GenerateCodeForFilterNamespace(string ns)
    {
      var types = GetBaseClassesOf(typeof (Filter)).
          Where(t => t.Namespace == ns).
          ToArray();
      ns = ns.Substring(5);
      var tokens = ns.Split('.');
      var uppercamel = String.Join(String.Empty, tokens.Select(w => Char.ToUpper(w[0]) + w.Substring(1)));
      if (uppercamel == "Filters") uppercamel += "General";
      RunT4TemplateImpl(new Filters(types) { TypeName = uppercamel }, @"Fltr\Generated\" + uppercamel);
    }

    [Test] public void GenerateAllAssociations()
    {
      var types = GetBaseClassesOf(typeof (AbstractAssociator));
      Array.ForEach(types, t => 
             RunT4Template(typeof(AssociationAlgorithm), t, @"Asstn\Generated"));

      RunT4TemplateImpl(new Associations(types), @"Asstn\Generated\Associations");
    }

    [Test] public void GenerateAllClassifiers()
    {
      var types = GetBaseClassesOf(typeof (Classifier));
      Array.ForEach(types, t => 
             RunT4Template(typeof(ClassifierAlgorithm), t, @"Clss\Generated"));      
      RunT4TemplateImpl(new Classifiers(types), @"Clss\Generated\Classifiers");
    }

    private static Type[] GetBaseClassesOf(Type ancestor)
    {
      return typeof (CfsSubsetEval).Assembly.
        GetTypes().
        Where(t => !t.IsAbstract && 
            t.DeclaringType == null &&  // No nested classes
            ancestor.IsAssignableFrom(t) && Utils.IsSupportedType(t)).
        ToArray();
    }

    private void RunT4Template(Type template, Type t, string dir)
    {
      var eval = (IMl2CodeGenerator) Activator.CreateInstance(template, t);
      Console.WriteLine("Generating Type:  " + t.Name);
      RunT4TemplateImpl(eval, dir + "\\" + eval.Model.TypeName);
    }

    private static void RunT4TemplateImpl(ICodeGen eval, string file)
    {
      var output = @"..\..\..\Ml2\" + file + ".cs";
      if (File.Exists(output)) File.Delete(output);      
      var generated = eval.TransformText();
      File.WriteAllText(output, generated);
    }
  }
}