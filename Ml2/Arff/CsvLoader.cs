using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using LumenWorks.Framework.IO.Csv;

namespace Ml2.Arff
{
  internal class CsvLoader : ILoader
  {
    public T[] Load<T>(params string[] files) where T : new() {
      Trace.Assert(files.Any());
      Trace.Assert(files.All(File.Exists));

      return files.SelectMany(ReadFile<T>).ToArray();
    }

    public T[] LoadLines<T>(IEnumerable<string> lines) where T : new()
    {
      var contents = String.Join("\n", lines);
      using (var sr = new StringReader(contents)) { return ReadFileImpl<T>(sr); }
    }

    private static T[] ReadFile<T>(string file) where T : new() {           
      using (var sr = new StreamReader(file)) { return ReadFileImpl<T>(sr); }      
    }

    private static T[] ReadFileImpl<T>(TextReader tr) where T : new()
    {
      var targets = GetProperties<T>();
      var records = new List<T>();
      using (var csv = new CsvReader(tr, true))
      {
        var fieldCount = csv.FieldCount;
        while (csv.ReadNextRecord())
        {
          var record = new T();
          for (var i = 0; i < fieldCount; i++)
          {
            var field = targets[i];
            field.SetValue(record, CovertToType(csv[i], field.PropertyType));
          }
          records.Add(record);
        }
      }
      return records.ToArray();
    }

    private static object CovertToType(string val, Type type) {
      if (String.IsNullOrEmpty(val)) return null;
      type = ArffUtils.GetNonNullableType(type);
      if (type.IsEnum) return ConvertToEnum(val, type);
      return Convert.ChangeType(val, type);
    }

    private static object ConvertToEnum(string val, Type type) {
      int intv;
      if (Int32.TryParse(val, out intv)) { return Enum.ToObject(type, intv); }

      val = val.ToLower();
      var names = Enum.GetNames(type).Select(n => n.ToLower()).ToArray();
      var values = Enum.GetValues(type).Cast<object>().ToArray();
      
      foreach (var value in values) { if (value.ToString().ToLower() == val) return value; }
      for (int i = 0; i < names.Length; i++) { if (val == names[i]) return values[i]; }
      if (val.Length == 1)
      {
        char c = val[0];
        for (int i = 0; i < names.Length; i++) { if (c == names[i][0]) return values[i]; }
      }
      throw new ArgumentException(val + " could not be converted to " + type.Name);
    }

    private static PropertyInfo[] GetProperties<T>() where T : new() {
      return typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    }
  }
}