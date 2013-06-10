using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator
{
  public static class Utils
  {
    public static string GetMl2EvalTypeName(Type t)
    {
      var idx = t.Name.IndexOf("Eval");
      return idx < 0 ? t.Name : t.Name.Substring(0, idx);
    }

    public static string GetMl2ClustererTypeName(Type t)
    {
      var idx = t.Name.IndexOf("Clusterer");
      return idx < 0 ? t.Name : t.Name.Substring(0, idx);
    }

    public static bool IsSupportedEvalType(Type t)
    {
      return t.Name != "DummySubsetEvaluator";
    }

    public static string GetClassDescription(Type t, string separator)
    {
      var desc = (string) t.GetMethod("globalInfo", BindingFlags.Instance | BindingFlags.Public).
                            Invoke(Activator.CreateInstance(t), null);
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
  }
}