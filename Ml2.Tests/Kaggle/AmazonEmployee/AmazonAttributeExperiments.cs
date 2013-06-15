using System;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{
  [TestFixture] public class AmazonAttributeExperiments
  {
    [Test] public void attribute_selection()
    {
      var train = new Runtime<AmazonTrainDataRow>(0, @"resources\kaggle\amazon-employee\train.csv");
      var eval = train.AttributeSelection.Evaluators.CfsSubset().
          LocallyPredictive(true).
          MissingSeparate(true);
      var impl = train.AttributeSelection.Algorithms.BestFirst();

      var filter = train.Filters.Supervised.Attribute.AttributeSelection().
          Evaluator(eval).
          Search(impl);

      var newrt = filter.RunFilter();
      Console.WriteLine("New Instances: " + newrt.Instances);
    }
  }
}