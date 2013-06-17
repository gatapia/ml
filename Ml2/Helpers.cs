using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Ml2.Arff;

namespace Ml2
{
  public static class Helpers
  {
    public static T Serialise<T>(T o, string file) {
      using (var stream = File.Open(file, FileMode.Create)) {
        new BinaryFormatter().Serialize(stream, o);
      }
      return o;
    }

    public static T Deserialise<T>(string file) {
      using (FileStream stream = File.Open(file, FileMode.Open)) {
        return (T) new BinaryFormatter().Deserialize(stream);
      }
    }

    public static T GetValue<T>(object o, string prop) {
      return (T) (o is IGetValue ? 
          ((IGetValue) o).GetValue(prop) : 
          o.GetType().GetProperty(prop).GetValue(o));
    }

    public static void SetValue(object target, string prop, object value) {
      target.GetType().GetProperty(prop).SetValue(target, value);
    }

    public static IEnumerable<T> RowsWherePropIsValue<T>(IEnumerable<T> data, string prop, object value) {
      return value == null ? 
        data.Where(d => GetValue<object>(d, prop) == null) : 
        data.Where(d => value.Equals(GetValue<object>(d, prop)));
    }

    private static readonly IDictionary<Type, PropertyInfo[]> memoized_props = new Dictionary<Type, PropertyInfo[]>();

    public static PropertyInfo[] GetProps(Type t)
    {
      return memoized_props.ContainsKey(t) ? 
          memoized_props[t] : 
          (memoized_props[t] = t.GetProperties().OrderBy(p => p.MetadataToken).ToArray());
    }

    private static readonly Random rng = new Random(1);
    public static double Random() { return rng.NextDouble(); }
  }
}