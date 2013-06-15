using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using java.util;
using weka.core;
using Attribute = weka.core.Attribute;

namespace Ml2.Arff
{
  internal class ArffInstanceBuilder<T> : IArffInstanceBuilder
  {
    private const string ISO_8601_DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ss";
    private readonly T[] data;

    public ArffInstanceBuilder(T[] data) { this.data = data; }

    public Instances Build()
    {            
      var type = data.Any() ? data.First().GetType() : typeof(T);
      var fields = GetProperties(type);
      var atts = BuildAttributes(fields);
      var instances = new Instances(type.Name, atts, data.Length);      
      Array.ForEach(data, r => instances.add(new DenseInstance(1.0, AddRow(r, atts))));
      return instances;
    }

    private static PropertyInfo[] GetProperties(Type type) {      
      return type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToArray();
    }

    private double[] AddRow(T row, ArrayList atts)
    {
      var fields = GetProperties(row.GetType());
      var rowvals = new double[fields.Length];
      for (int i = 0; i < fields.Length; i++)
      {
        rowvals[i] = GetValue((Attribute) atts.get(i), fields[i].GetValue(row));        
      }
      return rowvals;
    }

    private double GetValue(Attribute att, object v)
    {
      if (v == null || (v is string && String.IsNullOrWhiteSpace((string)v))) return Utils.missingValue();

      if (att.isNumeric()) return (double) Convert.ChangeType(v, typeof(double));
      if (att.isNominal()) return att.indexOfValue(v.ToString());
      if (att.isString()) return att. addStringValue((string) v);
      if (att.isDate()) return att.parseDate((string) v);
      throw new NotSupportedException(att.type() + " is not a supported attribute atttype.");
    }

    private ArrayList BuildAttributes(ICollection<PropertyInfo> properties)
    {
      var atts = new ArrayList();
      for (var i = 0; i < properties.Count; i++) { atts.add(GetAttribute(properties.ElementAt(i))); }
      return atts;
    }

    private Attribute GetAttribute(PropertyInfo pi)
    {
      var name = pi.Name;
      var atttype = EvaluateAttributeType(pi);
      if (atttype == EAttributeType.Nominal)
      {
        var type = ArffUtils.GetNonNullableType(pi.PropertyType);
        var arr = type.IsEnum ? 
            Enum.GetNames(type) : 
            data.Select(row => pi.GetValue(row, null).ToString()).Distinct().ToArray();
        return new Attribute(name, GetVectorFromArray(arr));
      }
      if (atttype == EAttributeType.Numeric) return new Attribute(name);      
      if (atttype == EAttributeType.Binary) return new Attribute(name, GetVectorFromArray(new [] { "True", "False" }));
      if (atttype == EAttributeType.String) return new Attribute(name, (ArrayList) null);
      if (atttype == EAttributeType.Date) return new Attribute(name, ISO_8601_DATE_FORMAT); // ISO-8601 Format
      throw new NotSupportedException(atttype + " is not a supported attribute atttype.");
    }

    private static EAttributeType EvaluateAttributeType(PropertyInfo pi)
    {
      if(pi == null) throw new ArgumentNullException("pi");

      var t = ArffUtils.GetNonNullableType(pi.PropertyType);      

      if (t.IsEnum || System.Attribute.IsDefined(pi, typeof(NominalAttribute))) { return EAttributeType.Nominal; }      
      if (t == typeof(string)) { return EAttributeType.String; }
      if (t == typeof(DateTime)) { return EAttributeType.Date; }
      if (t == typeof(bool)) { return EAttributeType.Binary; }
      var tc = Type.GetTypeCode(t);
      if (tc >= TypeCode.SByte && tc <= TypeCode.Decimal) { return EAttributeType.Numeric; }
      throw new NotSupportedException(t.Name + " is not a supported attribute atttype.");
    }

    private static ArrayList GetVectorFromArray(object[] arr)
    {
      var v = new ArrayList();
      Array.ForEach(arr, e => v.add(e));
      return v;
    }
  }
}