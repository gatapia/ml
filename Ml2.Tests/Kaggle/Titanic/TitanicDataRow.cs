using FileHelpers;
using Ml2.Arff;

namespace Ml2.Tests.Kaggle.Titanic
{
  [IgnoreFirst(1), IgnoreEmptyLines] public class TitanicDataRow : CsvRow
  {
    [Classifier] public ESurvival Survival;
    public EPassengerClass PassengerClass;
    public string Name;
    public ESex Sex;
    public double Age;
    public int NumSiblingsOrSpouses;
    public int NumParentsChildren;
    public string TicketNumber;
    public double PassengerFare;
    public string CabinNum;
    public EPort PortOfEmbarkation;
  }
}