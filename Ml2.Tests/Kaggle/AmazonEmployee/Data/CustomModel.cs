using System;
using System.Collections.Generic;
using System.Linq;

namespace Ml2.Tests.Kaggle.AmazonEmployee.Data
{
  [Serializable] public class CustomModel
  {
    private static readonly IDictionary<string, double> CACHE = new Dictionary<string, double>();

    private readonly IAmazonDataRow row;
    private readonly IAmazonDataRow[] trainingrows;
    private readonly int idx;
    private readonly int resourceid;    

    public CustomModel() {}

    public CustomModel(IAmazonDataRow row, IAmazonDataRow[] trainingrows, int idx)
    {
      this.row = row;
      this.trainingrows = trainingrows;
      this.idx = idx;
      resourceid = row.RESOURCE;      
    }

    public EAction ACTION { get { return row.GetAction();  }}
    public double RESOURCE_TOTAL_ROWS { get { return GetTotal("RESOURCE");  } }        
    public double RESOURCE_REJECTION_PROPORTION { get { return GetRejectProportion("RESOURCE");  } }        
    public double MANAGER_TOTAL_ROWS { get { return GetTotal("MGR_ID");  } }        
    public double MANAGER_REJECTION_PROPORTION { get { return GetRejectProportion("MGR_ID");  } }        
    public double ROLL_ROLLUP_2_TOTAL_ROWS { get { return GetTotal("ROLE_ROLLUP_2");  } }
    public double ROLL_ROLLUP_2_REJECTION_PROPORTION { get { return GetRejectProportion("ROLE_ROLLUP_2");  } }

    public double GetTotalRejectionProportion()
    {
      return RESOURCE_REJECTION_PROPORTION + MANAGER_REJECTION_PROPORTION + ROLL_ROLLUP_2_REJECTION_PROPORTION;
    } 
    public int GetIndex() { return idx;  } 

    public int GetResourceId() { return resourceid;  } 

    private double GetTotal(string field)
    {
      var val = TestingUtils.GetValue<int>(row, field);
      var key = field + "." + val + ".TOTAL";      
      if (CACHE.ContainsKey(key)) return CACHE[key];
      GetRejectProportion(field); // This initialises both totals and proportion caches
      return CACHE[key];
    }
    

    private double GetRejectProportion(string field)
    {
      var val = TestingUtils.GetValue<int>(row, field);
      var key = field + "." + val + ".PROPORTION";      
      if (CACHE.ContainsKey(key)) return CACHE[key];      
      var all = trainingrows.Where(r => TestingUtils.GetValue<int>(row, field) == val).ToArray();
      CACHE[field + "." + val + ".TOTAL"] = all.Length;
      return CACHE[key] = all.Count(r => r.GetAction() == EAction.Rejected) / (double) all.Length;
    }
  }
}