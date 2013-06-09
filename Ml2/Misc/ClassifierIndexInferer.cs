using System;
using System.Reflection;
using Ml2.Arff;

namespace Ml2.Misc
{
  internal class ClassifierIndexInferer : IClassifierIndexInferer
  {
    public int InferClassIndex<T>()
    {
      var fields = typeof (T).GetFields(BindingFlags.Public | BindingFlags.Instance);
      int idx = -1;
      for (int i = 0; i < fields.Length; i++)
      {
        FieldInfo fi = fields[i];
        if (fi.IsDefined(typeof (ClassifierAttribute), true))
        {
          if (idx >= 0)
            throw new ApplicationException("Only a single [Classifier] attribute is supported in an imported file.");
          idx = i;
        }
      }
      return idx >= 0 ? idx : fields.Length - 1;
    }

  }
}