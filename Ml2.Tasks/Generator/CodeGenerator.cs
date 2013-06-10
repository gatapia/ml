using System;
using System.IO;
using System.Linq;
using Ml2.Tasks.Generator.Asstn;
using Ml2.Tasks.Generator.AttrSel;
using Ml2.Tasks.Generator.Clstr;
using Ml2.Tasks.Generator.Fltr;
using NUnit.Framework;
using weka.associations;
using weka.attributeSelection;
using weka.clusterers;

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

    [Test] public void GenerateClusterers()
    {
      var types = GetBaseClassesOf(typeof (AbstractClusterer));
      Array.ForEach(types, t => 
             RunT4Template(typeof(ClustererAlgorithm), t, @"Clstr\Generated"));

      RunT4TemplateImpl(new Clusterers(types), @"Clstr\Generated\Clusterers");
    }

    [Test] public void GenerateAllFilters()
    {
      var types = GetBaseClassesOf(typeof (weka.filters.Filter)).
          ToArray();
      var supatt = types.
          Where(t => t.Namespace == "weka.filters.supervised.attribute").
          ToArray();
      var supinst = types.
          Where(t => t.Namespace == "weka.filters.supervised.instance").
          ToArray();
      var unsupatt = types.
          Where(t => t.Namespace == "weka.filters.unsupervised.attribute").
          ToArray();
      var unsupinst = types.
          Where(t => t.Namespace == "weka.filters.unsupervised.instance").
          ToArray();


      Array.ForEach(types, t => 
              RunT4Template(typeof(FilterAlgorithm), t, @"Fltrs\Generated"));
      RunT4TemplateImpl(new Filters(supatt) { TypeName = "SuppervisedAttributeFilters" }, @"Fltrs\Generated\SuppervisedAttributeFilters");
      RunT4TemplateImpl(new Filters(supinst) { TypeName = "SuppervisedInstanceFilters" }, @"Fltrs\Generated\SuppervisedInstanceFilters");
      RunT4TemplateImpl(new Filters(unsupatt) { TypeName = "UnsuppervisedAttributeFilters" }, @"Fltrs\Generated\UnsuppervisedAttributeFilters");
      RunT4TemplateImpl(new Filters(unsupinst) { TypeName = "UnsuppervisedInstanceFilters" }, @"Fltrs\Generated\UnsuppervisedInstanceFilters");
    }

    [Test] public void GenerateAllAssociations()
    {
      var types = GetBaseClassesOf(typeof (AbstractAssociator));
      Array.ForEach(types, t => 
             RunT4Template(typeof(AssociationAlgorithm), t, @"Asstn\Generated"));

      RunT4TemplateImpl(new Associations(types), @"Asstn\Generated\Associations");
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