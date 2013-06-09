using System;
using Ml2.AttributeSelection;
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

    [Test] public void Test_evaluation_and_best_first()
    {
      var csfsubset = rt.AttributeSelectionEvaluations.
          CfsSubsetEval().
              TreatMissingAsSeparate(true);

      var indexes = rt.AttributeSelectionAlgorithms.
          BestFirst().Search(csfsubset);
      Console.WriteLine("Indexes: " + String.Join(", ", indexes));
    }
  }
}