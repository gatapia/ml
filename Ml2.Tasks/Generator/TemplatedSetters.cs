﻿using System;
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
      var args = o.Method.GetParameters();
      if (args.Length > 1) return String.Empty;
      var mi = args.Single();
      var pt = mi.ParameterType;
      var name = args[0].Name;
      if (pt == typeof(Filter)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Fltr.BaseFilter<T> " + mi.Name);
      }
      if (pt == typeof(Filter[])) {
        return GetSetterTemplateImpl(o, name + ".Select(v => v.Impl).ToArray()", "Fltr.BaseFilter<T>[] " + mi.Name);
      }
      if (pt == typeof(Associator)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Asstn.BaseAssociation<T> " + mi.Name);
      }
      if (pt == typeof(Classifier)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Clss.BaseClassifier<T> " + mi.Name);
      }
      if (pt == typeof(Classifier[])) {
        return GetSetterTemplateImpl(o, name + ".Select(v => v.Impl).ToArray()", "Clss.BaseClassifier<T>[] " + mi.Name);
      }
      if (pt == typeof(ASEvaluation)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "AttrSel.Evals.BaseAttributeSelectionEvaluator<T> " + mi.Name);
      }
      if (pt == typeof(ASSearch)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "AttrSel.Algs.BaseAttributeSelectionAlgorithm<T> " + mi.Name);
      }
      if (pt == typeof(Clusterer)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Clstr.BaseClusterer<T> " + mi.Name);
      }
      if (pt == typeof(Instances)) {
        return GetSetterTemplateImpl(o, name + ".Instances", "Runtime<T> " + mi.Name);
      }
      return String.Empty;
    }

    private static string GetSetterTemplateImpl(OptionModel o, string arg, string opttype) {
      var impl = "((" + o.Model.ImplTypeName + ")Impl)." + o.Method.Name + "(" + arg + ");";
      var args = new [] {opttype};
      return Utils.GetSetterCode(o.OptionDescription, o.Model.TypeName, o.OptionName, args, impl);
    }
  }
}