using ML.Stats;
using NUnit.Framework;

namespace ML.Tests.Stats
{
  [TestFixture] public class HelperTests
  {
    [Test] public void TestGetZ() {
      TestHelpers.AlmostEqual(1.96, Helpers.GetZSigma(0.95));      
    } 
  }
}