using Ml2.Arff;

namespace Ml2.Tests.Kaggle.AmazonEmployee.Data
{
  public interface IAmazonDataRow : IGetValue
  {    
    int RESOURCE { get; }
    int MGR_ID { get; }
    int ROLE_ROLLUP_1 { get; }
    int ROLE_FAMILY { get; }

    EAction GetAction();
  }
}