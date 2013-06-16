using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ml2.Tests
{
  public static class TestingUtils
  {
    public static void Serialise(object o, string file)
    {
      using (var stream = File.Open(file, FileMode.Create))
      {
        new BinaryFormatter().Serialize(stream, o);
      }
    }

    public static T Deserialise<T>(string file)
    {
      using (FileStream stream = File.Open(file, FileMode.Open))
      {
        return (T) new BinaryFormatter().Deserialize(stream);
      }
    }

    public static T GetValue<T>(object o, string prop)
    {
      return (T) o.GetType().GetProperty(prop).GetValue(o);
    }
  }
}