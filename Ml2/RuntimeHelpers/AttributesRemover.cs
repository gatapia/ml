using System;
using System.Collections.Generic;
using System.Linq;

namespace Ml2.RuntimeHelpers
{
  public class AttributesRemover<T> : IAttributesRemover<T> where T : new()
  {
    public void RemoveAttributes(Runtime<T> rt, params object[] attributes) {
      if (attributes == null || attributes.Length == 0) return;

      var type = rt.Observations.First().Row.GetType();
      var indexes = attributes.Where(a => a is int).Cast<int>();
      var names = attributes.Where(a => a is string).Select(a => ((string)a).ToLower());
      var types = attributes.Where(a => a is Type).Cast<Type>();
      var nameidxs = GetNameIndexes(type, names);
      var typeidxs = GetTypeIndexes(type, types);
      var all = (indexes.Concat(nameidxs).Concat(typeidxs)).
        Distinct().
        OrderByDescending(i => i).
        ToArray();
      Array.ForEach(all, idx => rt.Instances.deleteAttributeAt(idx));
    }

    private IEnumerable<int> GetNameIndexes(Type t, IEnumerable<string> names) {
      var fields = Helpers.GetProps(t).
        Select(f => f.Name.ToLower()).
        ToArray();
      var idxs = names.Select(n => Array.IndexOf(fields, n)).ToArray();
      
      if (!idxs.All(idx => idx >= 0)) throw new ArgumentException("names");
      return idxs;
    }

    private IEnumerable<int> GetTypeIndexes(Type t, IEnumerable<Type> types) {
      var fields = Helpers.GetProps(t).
        Select(f => f.PropertyType).
        ToArray();
      var idxs = Enumerable.Range(0, fields.Length).
        Where(idx => types.Contains(fields[idx])).
        ToArray();
      
      if (!idxs.All(idx => idx >= 0)) throw new ArgumentException("types");
      return idxs;
    }
  }
}