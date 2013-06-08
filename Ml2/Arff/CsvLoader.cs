using System.Diagnostics;
using System.IO;
using System.Linq;
using FileHelpers;

namespace Ml2.Arff
{
  internal class CsvLoader : ILoader
  {
    public T[] Load<T>(params string[] files)
    {
      Trace.Assert(files.Any());
      Trace.Assert(files.All(File.Exists));

      var engine = new FileHelperEngine<T>();
      return files.SelectMany(f => engine.ReadFile(f)).ToArray();
    }
  }
}