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
      get
      {
        var name = method.Name.Substring(3);
        if (name == t.Name) { name = "Set" + name; }
        return name;
      }
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
          return true;
        }
        catch (NotSupportedException)
        {
          Console.WriteLine("\tOption: " + method.Name + " of internal type: " + 
              GetParameterType().Name + " is not supported.");
        } catch (InvalidOperationException)
        {
          Console.WriteLine("Error with method [" + method.Name + "] with multiple parameters: [" + 
            String.Join(", ", method.GetParameters().Select(p => p.Name)) +"]");
        }
        return false;
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