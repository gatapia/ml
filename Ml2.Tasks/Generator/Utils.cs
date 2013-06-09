using System;
using System.Linq;

namespace Ml2.Tasks.Generator
{
  public static class Utils
  {
    public static string GetMl2EvalTypeName(Type t)
    {
      var idx = t.Name.IndexOf("Eval");
      return idx < 0 ? t.Name : t.Name.Substring(0, idx);
    } 

    public static bool IsSupportedEvalType(Type t)
    {
      return t.Name != "DummySubsetEvaluator";
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