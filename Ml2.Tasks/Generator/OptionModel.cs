using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator
{
  public class OptionModel
  {
    private readonly Type t;
    private readonly MethodInfo method;

    public OptionModel(Type t, MethodInfo method)
    {
      this.t = t;
      this.method = method;
    }

    public string OptionName
    {
      get { return method.Name.Substring(3); }
    }

    public string OptionDescription
    {
      get
      {
        var tiptextmname = OptionName + "TipText";
        tiptextmname = Char.ToLower(tiptextmname[0]) + tiptextmname.Substring(1);
        var mi = t.GetMethod(tiptextmname, BindingFlags.Instance | BindingFlags.Public);
        if (mi == null) return String.Empty;
        var desc = (string) mi.Invoke(Activator.CreateInstance(t), null);
        return String.Join("\n    /// ", Utils.SplitIntoChunks(desc, 75));
      }
    }

    public bool IsSupported
    {
      get
      {
        try
        {
          var ot = OptionType;
        }
        catch (NotSupportedException)
        {
          Console.WriteLine("\tOption: " + method.Name + " of internal type: " + 
              GetParameterType().Name + " is not supported.");
          return false;
        }
        return true;
      }
    }

    public string OptionType
    {
      get
      {
        var raw = GetParameterType().Name;
        switch (raw)
        {
          case "Boolean": return "bool";
          case "String": return "string";
          case "String[]": return "string[]";
          case "Int32": return "int";
          case "Double": return "double";
          default:
            throw new NotSupportedException("Type: " + raw + " not supported.");
        }
      }
    }

    private Type GetParameterType()
    {
      return method.GetParameters().Single().ParameterType;
    }

    public string OptionImplSetterName
    {
      get { return method.Name; }
    }
  }
}