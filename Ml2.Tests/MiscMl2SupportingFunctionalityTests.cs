using System;
using System.Linq;
using Ml2.Tests.Kaggle.Titanic.Data;
using NUnit.Framework;

namespace Ml2.Tests
{
  [TestFixture] public class MiscMl2SupportingFunctionalityTests
  {
    private Runtime<TitanicDataRow> rt;
    [TestFixtureSetUp] public void TestFixtureSetUp()
    {
      rt = new Runtime<TitanicDataRow>(0, @"resources\kaggle\titanic\train.csv");
    }

    [Test] public void Test_removal_of_typed_attributes() {
      Assert.AreEqual(11, rt.Instances.numAttributes());
      rt.RemoveAttributes(typeof(string));
      Assert.AreEqual(8, rt.Instances.numAttributes());
    }

    [Test] public void Test_removal_of_named_attributes() {
      Assert.AreEqual(11, rt.Instances.numAttributes());
      rt.RemoveAttributes("NumSiblingsOrSpouses");
      Assert.AreEqual(10, rt.Instances.numAttributes());
    }

    [Test] public void Test_removal_of_indexed_attributes() {
      Assert.AreEqual(11, rt.Instances.numAttributes());
      rt.RemoveAttributes(4, 1, 5, 3);
      Assert.AreEqual(7, rt.Instances.numAttributes());
    }

    [Test] public void Test_removal_of_mixed_attributes() {
      Assert.AreEqual(11, rt.Instances.numAttributes());
      rt.RemoveAttributes("NumSiblingsOrSpouses", typeof(string), 1);
      Assert.AreEqual(6, rt.Instances.numAttributes());
    }

    [Test] public void Test_loading_csv_file_loads_all_instances_as_expected()
    {      
      Assert.AreEqual(891, rt.Instances.numInstances());
    }

    [Test] public void Test_classifier_attribute_sets_appropriate_index()
    {
      Assert.AreEqual(0, rt.Instances.classIndex());
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

    [Test] public void Test_clustering()
    {
      var kmeans = rt.Clusterers.
          SimpleKMeans().
          NumClusters(5).          
          Seed(1).
          Build();

      var classes = rt.Rows.Take(10).Select(kmeans.Classify);
      Console.WriteLine("First 10 Row Classifications: " + String.Join(", ", classes));
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
  }
}