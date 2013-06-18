﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using weka.core;

namespace Ml2.Tasks.Generator
{
  public class WekaTypeModel
  {
    private readonly Type impl;
    private readonly string ignoresuffix;

    public WekaTypeModel(Type impl, string ignoresuffix = null) {
      this.impl = impl;
      this.ignoresuffix = ignoresuffix;
    }

    internal Type ImplementationType { get { return impl; } }

    public string TypeName { get { return Utils.GetMl2TypeName(impl, ignoresuffix); } }
    public string GetClassDescription(string separator) { return Utils.GetClassDescription(impl, separator); }
    public string ImplTypeName { get { return impl.Name; } }
    public string ImplTypeNamespace { get { return impl.Namespace; } }

    public SetterModel[] Setters
    {
      get
      {
        var setters = impl.GetMethods(BindingFlags.Instance | BindingFlags.Public).
          Where(m => m.Name.StartsWith("set") && m.Name != "setOptions").
          Select(m => new SetterModel(this, m)).
          Where(o => o.IsSupported).
          ToArray();
        
        var found = new [] {"Seed", "RandomSeed"};
        setters.Where(s => s.SetterName.ToLower().IndexOf("seed") >= 0).ToList().ForEach(s => {
          Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!Type[" + TypeName  +"] Setter[" + s.SetterName + "] SetterType[" + s.Method.GetParameters().Single().ParameterType.Name + "] \n");
        });
        return setters;
      }
    } 

    public WekaEnum[] Enumerations {
      get {
        var tagmethods = impl.GetMethods(BindingFlags.Instance | BindingFlags.Public).
          Where(m => m.Name.StartsWith("set") && m.Name != "setOptions").
          Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(SelectedTag))).
          ToArray();
        return tagmethods.Select(GetEnumForMethod).Where(e => e != null).ToArray();
      }
    }

    private WekaEnum GetEnumForMethod(MethodInfo m) {
      try {
        return new WekaEnum {
          Name = Utils.GetEnumNameFromSetter(m.Name),
          Values = GetEnumValuesFromSetter(m)
        };
      } catch (InvalidOperationException) { return null; }
    }

    private KeyValuePair<string, string>[] GetEnumValuesFromSetter(MethodInfo m) {
      var tags = (Tag[]) Utils.GetEnumImplType(m).GetValue(null);
      
      return tags.Select(t => new KeyValuePair<string, string>(
          GetEnumValueName(t.getReadable()), 
          String.Empty + t.getID())).ToArray();
    }

    private string GetEnumValueName(string raw) {      
      return raw.
          Replace(" ", "_").
          Replace(":", "_").
          Replace("/", "_div_").
          Replace("1", "one").
          Replace("(", "").
          Replace(")", "").
          Replace(";", "").
          Replace("-", "_");
    }

    public class WekaEnum {
      public string Name { get; set; }
      public KeyValuePair<string, string>[] Values { get; set; }       
    }
  }
}