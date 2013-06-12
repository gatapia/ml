﻿using System;
using System.Linq;
using System.Reflection;
using weka.core;

namespace Ml2.Tasks.Generator
{
  internal static class Utils
  {
    public static string GetMl2TypeName(Type t, string suffix)
    {
      if (String.IsNullOrWhiteSpace(suffix)) return t.Name;
      var idx = t.Name.IndexOf(suffix);
      return idx < 0 ? t.Name : t.Name.Substring(0, idx);
    }

    public static bool IsSupportedType(Type t)
    {
      if (t.GetConstructor(new Type[0]) == null)
      {
        Console.WriteLine("Type [" + t.FullName + "] does not have a default constructor.");
        return false;
      }
      return t.Name != "DummySubsetEvaluator";
    }

    public static string GetClassDescription(Type t, string separator)
    {
      var impl = Activator.CreateInstance(t);
      var mi = t.GetMethod("globalInfo", BindingFlags.Instance | BindingFlags.Public);
      if (mi == null)
      {
        Console.WriteLine("Type [" + t.FullName + "] does not have a valid globalInfo method.");
        return "No class description found.";
      }
      var desc = (string) mi.Invoke(impl, null);
      return String.Join("\n" + separator, SplitIntoChunks(desc, 75));
    }

    public static string[] SplitIntoChunks(string str, int chunksize)
    {
      int charCount = 0;
      return str.Split(new[] {' ', '\n'}, StringSplitOptions.RemoveEmptyEntries)
        .GroupBy(w => (charCount += w.Length + 1) / chunksize)
        .Select(g => string.Join(" ", g)).
        ToArray();
    }

    public static string GetEnumNameFromSetter(string name) {      
      return "E" + name.Substring(3);
    }

    public static PropertyInfo GetEnumImplType(MethodInfo m) {
      var statics = m.DeclaringType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
      var alltaggs = statics.Where(f => f.PropertyType == typeof(Tag[])).ToArray();
      return alltaggs.Single();
    }

    public static string GetSetterCode(string summary, string modeltype, string settername, string settertype, string impl) {
      return String.Format(@"/// <summary>
    /// {0}
    /// </summary>    
    public {1}<T> {2} ({3} value) {{
      {4}
      return this;
    }}", summary, modeltype, settername, settertype, impl);
    }
  }
}