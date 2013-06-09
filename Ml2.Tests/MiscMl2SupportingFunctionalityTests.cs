using System;
using System.Data;
using System.Linq;
using Ml2.Tests.Kaggle.Titanic;
using NUnit.Framework;

namespace Ml2.Tests
{
  [TestFixture] public class MiscMl2SupportingFunctionalityTests
  {
    private Runtime rt;
    [TestFixtureSetUp] public void TestFixtureSetUp()
    {
      rt = new Runtime();
      rt.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");
    }

    [Test] public void Test_loading_csv_file_loads_all_instances_as_expected()
    {      
      Assert.AreEqual(891, rt.Instances.numInstances());
    }

    [Test] public void Test_classifier_attribute_sets_appropriate_index()
    {
      Assert.AreEqual(0, rt.Instances.classIndex());
    }

    [Test] public void Test_csfsubset_evaluator_and_best_first()
    {
      var eval = rt.AttributeSelection.Evaluators.
          CfsSubset().
              LocallyPredictive(true).
              MissingSeparate(true);

      var indexes = rt.AttributeSelection.Algorithms.
          BestFirst().
              LookupCacheSize(1).
              SearchTermination(1).
              StartSet("2-11").
          Search(eval);
      CollectionAssert.AreEqual(Enumerable.Range(1, 10), indexes);
    }

    [Test] public void Test_corr_evaluator_and_ranker()
    {
      var eval = rt.AttributeSelection.Evaluators.
        CorrelationAttribute();

      var indexes = rt.AttributeSelection.Algorithms.
          Ranker().
              GenerateRanking(true).
              StartSet("2-11").
          Search(eval);
      CollectionAssert.AreEqual(new int[0], indexes);
    }
  }
}