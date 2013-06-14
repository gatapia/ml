using System;
using System.Linq;
using weka.associations;
using weka.attributeSelection;
using weka.classifiers;
using weka.clusterers;
using weka.core;
using weka.filters;

namespace Ml2.Tasks.Generator
{
  public static class TemplatedSetters
  {
    public static string GetSetterTemplate(SetterModel o) {

      if (o.Method.Name == "setInputFormat") { throw new NotSupportedException("InputFormat not supported as its handled by BaseFilter"); }

      var args = o.Method.GetParameters();
      if (args.Length > 1) return String.Empty;
      var mi = args.Single();
      var pt = mi.ParameterType;
      var name = args[0].Name;
      if (pt == typeof(Filter)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Fltr.BaseFilter<T, weka.filters.Filter> " + mi.Name);
      }
      if (pt == typeof(Filter[])) {
        return GetSetterTemplateImpl(o, name + ".Select(v => v.Impl).ToArray()", "Fltr.BaseFilter<T, weka.filters.Filter>[] " + mi.Name);
      }
      if (pt == typeof(Associator)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Asstn.BaseAssociation<T, weka.associations.AbstractAssociator> " + mi.Name);
      }
      if (pt == typeof(Classifier)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Clss.BaseClassifier<T, weka.classifiers.Classifier> " + mi.Name);
      }
      if (pt == typeof(Classifier[])) {
        return GetSetterTemplateImpl(o, name + ".Select(v => v.Impl).ToArray()", "Clss.BaseClassifier<T, weka.classifiers.Classifier>[] " + mi.Name);
      }
      if (pt == typeof(ASEvaluation)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "AttrSel.Evals.BaseAttributeSelectionEvaluator<T, weka.attributeSelection.ASEvaluation> " + mi.Name);
      }
      if (pt == typeof(ASSearch)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "AttrSel.Algs.BaseAttributeSelectionAlgorithm<T, weka.attributeSelection.ASSearch> " + mi.Name);
      }
      if (pt == typeof(Clusterer)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Clstr.BaseClusterer<T, weka.clusterers.Clusterer> " + mi.Name);
      }
      if (pt == typeof(Instances)) {
        return GetSetterTemplateImpl(o, name + ".Instances", "Runtime<T> " + mi.Name);
      }
      if (o.Method.Name == "setAttributeRange") {
        var arg = "System.String.Join(\",\", attributes.Select(a => a + 1))";
        return GetSetterTemplateImpl(o, arg, "params int[] attributes");
      }
      return String.Empty;
    }

    private static string GetSetterTemplateImpl(SetterModel o, string arg, string opttype) {
      var impl = "((" + o.Model.ImplTypeName + ")Impl)." + o.Method.Name + "(" + arg + ");";
      var args = new [] {opttype};
      return Utils.GetSetterCode(o.SetterDescription, o.Model.TypeName, o.SetterName, args, impl);
    }
  }
}