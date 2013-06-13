using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using java.util;
using weka.core;
using Attribute = weka.core.Attribute;

namespace Ml2.Arff
{
  internal class ArffInstanceBuilder : IArffInstanceBuilder
  {
    private const string ISO_8601_DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ss"; 

    public Instances Build<T>(T[] data)
    {            
      var type = data.Any() ? data.First().GetType() : typeof(T);
      var fields = GetProperties(type);
      var names = fields.Select(f => f.Name).ToArray();      
      var fieldtypes = fields.Select(f => GetRealType(f.PropertyType)).ToArray();      
      var atttypes = fieldtypes.Select(EvaluateAttributeType).ToArray();
      var atts = BuildAttributes(atttypes, names, fieldtypes);
      var instances = new Instances(type.Name, atts, data.Length);      
      Array.ForEach(data, r => instances.add(new DenseInstance(1.0, AddRow(r, atts))));
      return instances;
    }

    private static PropertyInfo[] GetProperties(Type type) {      
      return type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToArray();
    }

    private double[] AddRow<T>(T row, ArrayList atts)
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

    private static Type GetRealType(Type t)
    {
      Trace.Assert(t != null);
      if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>)) { return Nullable.GetUnderlyingType(t); }
      return t;
    }

    private static EAttributeType EvaluateAttributeType(Type t)
    {
      Trace.Assert(t != null);

      if (t.IsEnum) { return EAttributeType.Nominal; }      
      if (t == typeof(string)) { return EAttributeType.String; }
      if (t == typeof(DateTime)) { return EAttributeType.Date; }
      if (t == typeof(bool)) { return EAttributeType.Binary; }
      var tc = Type.GetTypeCode(t);
      if (tc >= TypeCode.SByte && tc <= TypeCode.Decimal) { return EAttributeType.Numeric; }
      throw new NotSupportedException(t.Name + " is not a supported attribute atttype.");
    }

    private ArrayList BuildAttributes(ICollection<EAttributeType> atttypes, ICollection<string> names, ICollection<Type> fieldtypes)
    {
      var atts = new ArrayList();
      Trace.Assert(atttypes.Count == fieldtypes.Count);
      Trace.Assert(atttypes.Count == names.Count);

      for (var i = 0; i < atttypes.Count; i++)
      {
        atts.add(GetAttribute(atttypes.ElementAt(i), names.ElementAt(i), fieldtypes.ElementAt(i)));
      }
      return atts;
    }

    private Attribute GetAttribute(EAttributeType atttype, string fieldname, Type fieldtype)
    {
      if (atttype == EAttributeType.Numeric) return new Attribute(fieldname);
      if (atttype == EAttributeType.Nominal) return new Attribute(fieldname, GetVectorFromArray(Enum.GetNames(fieldtype)));
      if (atttype == EAttributeType.Binary) return new Attribute(fieldname, GetVectorFromArray(new [] { "True", "False" }));
      if (atttype == EAttributeType.String) return new Attribute(fieldname, (ArrayList) null);
      if (atttype == EAttributeType.Date) return new Attribute(fieldname, ISO_8601_DATE_FORMAT); // ISO-8601 Format
      throw new NotSupportedException(atttype + " is not a supported attribute atttype.");
    }

    private static ArrayList GetVectorFromArray(string[] arr)
    {
      var v = new ArrayList();
      Array.ForEach(arr, e => v.add(e));
      return v;
    }
  }
}