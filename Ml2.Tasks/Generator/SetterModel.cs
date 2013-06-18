using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using weka.core;

namespace Ml2.Tasks.Generator
{
  public class SetterModel
  {
    internal WekaTypeModel Model {get;private set; }
    internal MethodInfo Method {get;private set; }

    public SetterModel(WekaTypeModel model, MethodInfo method)
    {
      Model = model;
      Method = method;
    }

    public string SetterName
    {
      get
      {
        var name = Method.Name.Substring(3);
        if (name == Model.ImplementationType.Name) { name = "Set" + name; }
        return name;
      }
    }

    public string SetterDescription
    {
      get
      {
        var tiptextmname = SetterName + "TipText";
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
        if (Method.Name == "setSeed" || Method.Name == "setRandomSeed") { return false; }
        try { 
          return !String.IsNullOrEmpty(TemplatedSetters.GetSetterTemplate(this)) || SetterArgsTypes != null; 
        } catch (NotSupportedException)
        {
          Console.WriteLine("\tSetter: " + Method.Name + " of internal types [" + 
              String.Join(", ", Method.GetParameters().Select(p => p.ParameterType.Name)) + 
              "] is not supported.");
        } 
        return false;
      }
    }    

    public string SetterCode {
      get {  
        var templated = TemplatedSetters.GetSetterTemplate(this);
        if (!String.IsNullOrEmpty(templated)) return templated;

        var args = GetPassedArgumentNames();
        var impl = String.Format("(({0})Impl).{1}({2});", Model.ImplTypeName, Method.Name, args);
        var signature = SetterArgsTypes.Zip(SetterArgsNames, (a, b) => a + " " + b).ToArray();
        return Utils.GetSetterCode(SetterDescription, Model.TypeName, SetterName, signature, impl);
      }
    }

    private string GetPassedArgumentNames() {
      var args = new List<string>();
      foreach (var pi in Method.GetParameters()) {
        var name = GetCsSafeName(pi);
        var type = pi.ParameterType;
        
        if (type == typeof (SelectedTag)) { name = String.Format("new weka.core.SelectedTag((int) {1}, {0}.{2})", Model.ImplTypeName, name, Utils.GetEnumImplType(Method).Name); }
        args.Add(name);
      }
      return String.Join(", ", args);
    }    

    private string[] SetterArgsTypes
    {
      get { return Method.GetParameters().Select(GetCsSafeType).ToArray(); }
    }

    private string[] SetterArgsNames
    {
      get { return Method.GetParameters().Select(GetCsSafeName).ToArray(); }
    }

    private string GetCsSafeName(ParameterInfo pi) {
      switch (pi.Name) {
        case "bool":
          return "value";
        default: return pi.Name;
      }
    }

    private string GetCsSafeType(ParameterInfo pi) {
      switch (pi.ParameterType.Name)
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
          case "Double[][]": return "double[][]";
          case "Single": return "float";
          case "Single[]": return "float[]";
          // TODO: This is not nice but since FastVector is obsolete this 
          // will eventually be replaced I hope.
          case "FastVector": return "weka.core.FastVector"; 
          case "SelectedTag": 
            try { Utils.GetEnumImplType(Method); }
            catch (InvalidOperationException) {
              throw new NotSupportedException("Enum: " + Method.Name + " not supported. No values found.");
            }
            return Utils.GetEnumNameFromSetter(Method.Name);
          default:
            throw new NotSupportedException("Type: " + pi.ParameterType.Name + " not supported.");
        }
    }
  }
}