using System;
using Ml2.Arff;

namespace Ml2.Tests.Kaggle.AmazonEmployee.Data
{
  [Serializable] public class AmazonTrainDataRow : IAmazonDataRow
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
   
    public EAction GetAction() { return ACTION; }
    
    public object GetValue(string property) {
      switch (property) {
        case "ACTION" : return ACTION;
        case "RESOURCE" : return RESOURCE;
        case "MGR_ID" : return MGR_ID;
        case "ROLE_ROLLUP_1" : return ROLE_ROLLUP_1;
        case "ROLE_ROLLUP_2" : return ROLE_ROLLUP_2;
        case "ROLE_DEPTNAME" : return ROLE_DEPTNAME;
        case "ROLE_TITLE" : return ROLE_TITLE;
        case "ROLE_FAMILY_DESC" : return ROLE_FAMILY_DESC;
        case "ROLE_FAMILY" : return ROLE_FAMILY;
        default: throw new ArgumentException("property: " + property + " not found in AmazonTrainDataRow");
      }
    }
  }
}