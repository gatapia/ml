using System;
using System.Linq;

namespace Ml2.Tests.Kaggle.AmazonEmployee.Data
{
  [Serializable] public class ManagerOnlyRow
  {
    public ManagerOnlyRow() {}

    public ManagerOnlyRow(IAmazonDataRow[] rows, IAmazonDataRow row, ManagerOnlyRow[] trainingset)
    {
      resourceid = row.RESOURCE;
      MGR_ID = row.MGR_ID;
      var resourcerows = rows.Where(r => r.RESOURCE == row.RESOURCE).ToArray();
      var managerrows = rows.Where(r => r.MGR_ID == row.MGR_ID).ToArray();

      if (row is AmazonTrainDataRow)
      {
        ACTION = row.GetAction();
        RESOURCE_REJECTIONS = resourcerows.Count(r => r.GetAction() == EAction.Rejected);
        RESOURCE_APPROVALS = resourcerows.Count(r => r.GetAction() == EAction.Approved);
        MANAGER_REJECTIONS = managerrows.Count(r => r.GetAction() == EAction.Rejected);
        MANAGER_APPROVALS = managerrows.Count(r => r.GetAction() == EAction.Approved);
      } else
      {
        var match = trainingset.FirstOrDefault(ts => ts.MGR_ID == row.MGR_ID && ts.resourceid == resourceid);
        if (match != null)
        {
          RESOURCE_REJECTIONS = match.RESOURCE_REJECTIONS;
          RESOURCE_APPROVALS = match.RESOURCE_APPROVALS;
          MANAGER_REJECTIONS = match.MANAGER_REJECTIONS;
          MANAGER_APPROVALS = match.MANAGER_APPROVALS;
        }
      }
    }

    private readonly int resourceid;

    public EAction ACTION { get; set; }
    public int MGR_ID { get; set; }
    public int RESOURCE_REJECTIONS { get; set; }
    public int RESOURCE_APPROVALS { get; set; }
    public int MANAGER_REJECTIONS { get; set; }
    public int MANAGER_APPROVALS { get; set; }

    public bool IsUnknown() { return RESOURCE_REJECTIONS == 0 && RESOURCE_APPROVALS == 0 && MANAGER_REJECTIONS == 0 && MANAGER_APPROVALS == 0; }
    public double TotalRejections() { return RESOURCE_REJECTIONS + MANAGER_REJECTIONS; }
    public double TotalApprovals() { return RESOURCE_APPROVALS + MANAGER_APPROVALS; }
  }
}