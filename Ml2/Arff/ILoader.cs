using System.Collections.Generic;

namespace Ml2.Arff
{
  internal interface ILoader
  {
    T[] Load<T>(params string[] files) where T : new();
    T[] LoadLines<T>(IEnumerable<string> lines) where T : new();
  }
}