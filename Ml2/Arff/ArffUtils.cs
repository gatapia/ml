using System;
using System.Diagnostics;

namespace Ml2.Arff
{
  public static class ArffUtils
  {
    public static Type GetNonNullableType(Type t) {
      Trace.Assert(t != null);
      if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof (Nullable<>)) {
        return Nullable.GetUnderlyingType(t);
      }
      return t;
    }
  }
}