namespace Ml2.Tests.Kaggle.Titanic.Data
{
  public class TitanicDataRow
  {
    public ESurvival Survival { get; set; }
    public EPassengerClass PassengerClass { get; set; }
    public string Name { get; set; }
    public ESex Sex { get; set; }
    public double? Age { get; set; }
    public int? NumSiblingsOrSpouses { get; set; }
    public int? NumParentsChildren { get; set; }
    public string TicketNumber { get; set; }
    public double? PassengerFare { get; set; }
    public string CabinNum { get; set; }
    public EPort PortOfEmbarkation { get; set; }
  }
}