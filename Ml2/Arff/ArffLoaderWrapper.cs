using System.Collections.Generic;

namespace Ml2.Arff
{
  internal class ArffLoaderWrapper : ILoader
  {
    public T[] Load<T>(params string[] files) where T : new()
    {
      throw new System.NotImplementedException();
    }

    public T[] LoadLines<T>(IEnumerable<string> lines) where T : new()
    {
      throw new System.NotImplementedException();
    }
  }
}