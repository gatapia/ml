using System;
using System.Linq;
using FileHelpers;

namespace Ml2.Arff
{
  public class EnumCsvConverter<T> : ConverterBase
  {
    public override object StringToField(string v)
    {
      if (String.IsNullOrWhiteSpace(v)) return 0;

      int intv;
      if (Int32.TryParse(v, out intv)) { return Enum.ToObject(typeof (T), intv); }

      v = v.ToLower();
      var names = Enum.GetNames(typeof (T)).Select(n => n.ToLower()).ToArray();
      var values = (T[]) Enum.GetValues(typeof(T));
      
      foreach (var value in values) { if (value.ToString().ToLower() == v) return value; }
      for (int i = 0; i < names.Length; i++) { if (v == names[i]) return values[i]; }
      if (v.Length == 1)
      {
        char c = v[0];
        for (int i = 0; i < names.Length; i++) { if (c == names[i][0]) return values[i]; }
      }
      throw new ArgumentException(v + " could not be converted to " + typeof(T).Name);
    }
  }
}