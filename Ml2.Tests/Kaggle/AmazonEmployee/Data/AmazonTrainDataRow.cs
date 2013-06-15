using Ml2.Arff;

namespace Ml2.Tests.Kaggle.AmazonEmployee.Data
{
  public class AmazonTrainDataRow
  {
    public EAction ACTION { get; set; }
    public int RESOURCE { get; set; }
    [Nominal] public int MGR_ID { get; set; }
    [Nominal] public int ROLE_ROLLUP_1 { get; set; }
    [Nominal] public int ROLE_ROLLUP_2 { get; set; }
    [Nominal] public int ROLE_DEPTNAME { get; set; }
    [Nominal] public int ROLE_TITLE { get; set; }
    [Nominal] public int ROLE_FAMILY_DESC { get; set; }
    [Nominal] public int ROLE_FAMILY { get; set; }
    [Nominal] public int ROLE_CODE { get; set; }    
  }
}