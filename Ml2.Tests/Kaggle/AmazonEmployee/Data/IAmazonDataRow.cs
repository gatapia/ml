namespace Ml2.Tests.Kaggle.AmazonEmployee.Data
{
  public interface IAmazonDataRow
  {    
    int RESOURCE { get; }
    int MGR_ID { get; }

    EAction GetAction();
  }
}