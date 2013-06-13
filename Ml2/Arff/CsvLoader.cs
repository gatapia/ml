using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using FileHelpers;
using FileHelpers.RunTime;

namespace Ml2.Arff
{
  internal class CsvLoader : ILoader
  {
    public T[] Load<T>(params string[] files)
    {
      Trace.Assert(files.Any());
      Trace.Assert(files.All(File.Exists));

      var cb = new DelimitedClassBuilder(typeof(T).Name, ",");
      cb.IgnoreFirstLines = 1;
      cb.IgnoreEmptyLines = true;

      foreach (var f in typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public))
      {
        cb.AddField(f.Name, f.FieldType);
        cb.LastField.TrimMode = TrimMode.Both;
        if (f.FieldType == typeof(string))
        {
          cb.LastField.FieldQuoted = true;
          cb.LastField.QuoteChar = '"';
        }
      }

      var engine = new FileHelperEngine(cb.CreateRecordClass());
      var dt = engine.ReadFile(files[0]);
      return dt.Cast<T>().ToArray();
      // var engine = new FileHelperEngine<T>();
      // return files.SelectMany(f => engine.ReadFile(f)).ToArray();
    }
  }
}