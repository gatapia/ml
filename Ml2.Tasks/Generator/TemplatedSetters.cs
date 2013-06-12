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
    public static string GetSetterTemplate(OptionModel o) {
      var pt = o.Method.GetParameters().Single().ParameterType;
      if (pt == typeof(Filter)) {
        return GetSetterTemplateImpl(o, "value.Impl", "Fltr.BaseFilter<T>");
      }
      if (pt == typeof(Filter[])) {
        return GetSetterTemplateImpl(o, "value.Select(v => v.Impl).ToArray()", "Fltr.BaseFilter<T>[]");
      }
      if (pt == typeof(Associator)) {
        return GetSetterTemplateImpl(o, "value.Impl", "Asstn.BaseAssociation<T>");
      }
      if (pt == typeof(Classifier)) {
        return GetSetterTemplateImpl(o, "value.Impl", "Clss.BaseClassifier<T>");
      }
      if (pt == typeof(ASEvaluation)) {
        return GetSetterTemplateImpl(o, "value.Impl", "AttrSel.Evals.BaseAttributeSelectionEvaluator<T>");
      }
      if (pt == typeof(ASSearch)) {
        return GetSetterTemplateImpl(o, "value.Impl", "AttrSel.Algs.BaseAttributeSelectionAlgorithm<T>");
      }
      if (pt == typeof(Clusterer)) {
        return GetSetterTemplateImpl(o, "value.Impl", "Clstr.BaseClusterer<T>");
      }
      if (pt == typeof(Instances)) {
        return GetSetterTemplateImpl(o, "value.Instances", "Runtime<T>");
      }
      return String.Empty;
    }

    private static string GetSetterTemplateImpl(OptionModel o, string arg, string opttype) {
      var impl = "((" + o.Model.ImplTypeName + ")Impl)." + o.Method.Name + "(" + arg + ");";
      return Utils.GetSetterCode(o.OptionDescription, o.Model.TypeName, o.OptionName, opttype, impl);
    }
  }
}