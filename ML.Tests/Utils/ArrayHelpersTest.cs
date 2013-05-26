using ML.Utils;
using NUnit.Framework;

namespace ML.Tests.Utils
{
  [TestFixture] public class ArrayHelpersTest
  {
    [Test] public void TestArrayTranspose() {
      var a = new [] {
        new double[] {0, 1, 2, 3, 4},
        new double[] {5, 6, 7, 8, 9},
      };
      var exp = new [] {
        new double[] {0, 5},
        new double[] {1, 6},
        new double[] {2, 7},
        new double[] {3, 8},
        new double[] {4, 9},
      };
      CollectionAssert.AreEqual(exp, ArrayHelpers.Transpose(a));
    }
  }
}