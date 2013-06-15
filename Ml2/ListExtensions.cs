using System;
using System.Collections.Generic;
using System.Linq;

namespace Ml2
{
  public static class ListExtensions
  {
    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> data, int seed = 0)
    {
      var rng = new Random(seed);
      return data.OrderBy(d => rng.Next()).ToList();
    }

    public static IEnumerable<T> RandomSample<T>(this IEnumerable<T> data, int size, int seed = 0)
    {
      var lst = data.ToList();
      if (size <= 0 || size > lst.Count) throw new ArgumentException("size");
      if (size == lst.Count) return lst;
      var odds = size / (double) lst.Count;
      var rng = new Random(seed);
      var sample = new List<T>();
      var source = lst.ToList();
      var idx = 0;
      while (true)
      {
        if (rng.NextDouble() <= odds)
        {
          var modded = idx % lst.Count;
          var val = source[modded];
          sample.Add(val);
          source.RemoveAt(modded);
          if (sample.Count == size) return sample;
        }
        idx++;
      }      
    }
  }
}