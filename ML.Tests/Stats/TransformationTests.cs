using ML.Stats;
using NUnit.Framework;

namespace ML.Tests.Stats
{
  [TestFixture] public class TransformationTests
  {
    [Test] public void TestLog10() {
      var source = new [] {1.0, 2.0, 3.0, 4.0};
      var exp = new [] {0.0, 0.301, 0.477, 0.602};
      TestHelpers.AlmostEqual(exp, Transformations.Log10(source));
    }
  }
}