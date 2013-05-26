using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ML.Tests.Stats
{
  public class TestHelpers
  {
    private const double ACCEPTABLE_ERROR = 0.001;
    public static void AlmostEqual(double a, double b) {
      Assert.AreEqual(a, b, ACCEPTABLE_ERROR);
    }

    public static void AlmostEqual(Tuple<double, double> a, Tuple<double, double> b) {
      Assert.AreEqual(a.Item1, b.Item1, ACCEPTABLE_ERROR);
      Assert.AreEqual(a.Item2, b.Item2, ACCEPTABLE_ERROR);
    }

    public static void AlmostEqual(ICollection<double> a, ICollection<double> b) {
      Assert.AreEqual(a.Count, b.Count);
      for (int i = 0; i < a.Count; i++) { Assert.AreEqual(a.ElementAt(i), b.ElementAt(i), ACCEPTABLE_ERROR); }           
    }
  }
}