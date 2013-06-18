using System.Linq;

namespace Ml2
{
  internal static class InternalHelpers
  {
    internal static void SetSeedOnInstance(object o) {
      o.GetType().GetMethods().
          Where(m => m.Name == "setSeed" || m.Name == "setRandomSeed").
          ToList().ForEach(m => m.Invoke(o, new object[] { Runtime.GlobalRandomSeed }));
    }
  }
}