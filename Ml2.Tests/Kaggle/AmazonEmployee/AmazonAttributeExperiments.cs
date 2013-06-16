using System;
using Ml2.AttrSel.Algs;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{
  [TestFixture] public class AmazonAttributeExperiments
  {
    [Test] public void attribute_selection()
    {
      var train = new Runtime<AmazonTrainDataRow>(0, @"resources\kaggle\amazon-employee\train.csv").
          RemoveAttributes("RESOURCE");

      var eval = train.AttributeSelection.Evaluators.CfsSubset().
          LocallyPredictive(true).
          MissingSeparate(true);

      var impl = train.AttributeSelection.Algorithms.BestFirst().
          Direction(BestFirst<AmazonTrainDataRow>.EDirection.Backward).
          LookupCacheSize(10).
          SearchTermination(10).
          StartSet("1-9");

      var filter = train.Filters.Supervised.Attribute.AttributeSelection().
          Evaluator(eval).
          Search(impl);

      var newrt = filter.RunFilter();
      var atts = newrt.Instances.enumerateAttributes();
      while (atts.hasMoreElements())
        Console.WriteLine("Arr: " + ((weka.core.Attribute)atts.nextElement()).name());
    }
  }
}