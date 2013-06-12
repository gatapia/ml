using System;
using System.Linq;
using System.Reflection;

namespace Ml2.Tasks.Generator
{
  public class OptionModel
  {
    internal WekaTypeModel Model {get;private set; }
    internal MethodInfo Method {get;private set; }

    public OptionModel(WekaTypeModel model, MethodInfo method)
    {
      Model = model;
      Method = method;
    }

    public string OptionName
    {
      get
      {
        var name = Method.Name.Substring(3);
        if (name == Model.ImplementationType.Name) { name = "Set" + name; }
        return name;
      }
    }

    public string OptionDescription
    {
      get
      {
        var tiptextmname = OptionName + "TipText";
        tiptextmname = Char.ToLower(tiptextmname[0]) + tiptextmname.Substring(1);
        var mi = Model.ImplementationType.GetMethod(tiptextmname, BindingFlags.Instance | BindingFlags.Public);
        if (mi == null) return String.Empty;
        var desc = (string) mi.Invoke(Activator.CreateInstance(Model.ImplementationType), null);
        return String.Join("\n    /// ", Utils.SplitIntoChunks(desc, 75));
      }
    }

    public bool IsSupported
    {
      get
      {
        try
        {
          if (!String.IsNullOrEmpty(TemplatedSetters.GetSetterTemplate(this))) return true;
          var ot = OptionType;
          return true;
        }
        catch (NotSupportedException)
        {
          Console.WriteLine("\tOption: " + Method.Name + " of internal type: " + 
              GetParameterType().Name + " is not supported.");
        } catch (InvalidOperationException)
        {
          Console.WriteLine("Error with method [" + Method.Name + "] with multiple parameters: [" + 
            String.Join(", ", Method.GetParameters().Select(p => p.Name)) +"]");
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
          case "Int32[]": return "int[]";
          case "Int64": return "long";
          case "Int64[]": return "long[]";
          case "Double": return "double";
          case "Double[]": return "double[]";
          case "SelectedTag": 
            try { Utils.GetEnumImplType(Method); }
            catch (InvalidOperationException) {
              throw new NotSupportedException("Enum: " + Method.Name + " not supported. No values found.");
            }
            return Utils.GetEnumNameFromSetter(Method.Name);
          default:
            throw new NotSupportedException("Type: " + raw + " not supported.");
        }
      }
    }

    public string SetterCode {
      get {  
        var templated = TemplatedSetters.GetSetterTemplate(this);
        if (!String.IsNullOrEmpty(templated)) return templated;
        var setterimpl = GetParameterType().Name == "SelectedTag" ?
          "((" + Model.ImplTypeName + ")Impl)." + Method.Name + "(new SelectedTag((int) value, " + Model.ImplTypeName + "." + Utils.GetEnumImplType(Method).Name + "));" :
          "((" + Model.ImplTypeName + ")Impl)." + OptionImplSetterName + "(value);";

        return Utils.GetSetterCode(OptionDescription, Model.TypeName, OptionName, OptionType, setterimpl);
      }
    }

    private Type GetParameterType()
    {
      return Method.GetParameters().Single().ParameterType;
    }

    public string OptionImplSetterName
    {
      get { return Method.Name; }
    }
  }
}