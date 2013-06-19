using System;
using Ml2.Arff;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{    
  [TestFixture] public class ClassifierExperimentsWithSmote
  {    
    [Test] public void prepare_training_data_with_additional_counts() {
      var training = LoadTrainingRuntime();
    }
   
    private Runtime<AmazonTrainDataRow> LoadTrainingRuntime() {          
      var file = "training_runtime_with_smote.arff";
      var start = DateTime.Now;
      var rt = new Runtime<AmazonTrainDataRow>(0, @"resources\kaggle\amazon-employee\train.csv");
      rt.Filters.SupervisedInstance.SpreadSubsample().
          DistributionSpread(3).
          RunFilter();
      
      rt.Filters.SupervisedInstance.SMOTE().
          Percentage(300).
          ClassValue(((int) EAction.Rejected).ToString());

      rt.SaveToArffFile(file);
      Console.WriteLine("Creating the training runtime took: {0}ms", DateTime.Now.Subtract(start).TotalMilliseconds);
      return rt;
    }
  }

  
  internal class RFCustomModel2 {
    public EAction ACTION { get; set; }
    [Nominal] public int RESOURCE { get; set; }
    [Nominal] public int MGR_ID { get; set; }
    [Nominal] public int ROLE_ROLLUP_1 { get; set; }
    [Nominal] public int ROLE_ROLLUP_2 { get; set; }
    [Nominal] public int ROLE_DEPTNAME { get; set; }
    [Nominal] public int ROLE_TITLE { get; set; } 
    [Nominal] public int ROLE_FAMILY_DESC { get; set; } 
  }
}