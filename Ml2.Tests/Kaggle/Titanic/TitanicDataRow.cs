using FileHelpers;
using Ml2.Arff;

namespace Ml2.Tests.Kaggle.Titanic
{
  [IgnoreFirst(1), IgnoreEmptyLines] public class TitanicDataRow : CsvRow
  {
    [FieldConverter(typeof(EnumCsvConverter<ESurvival>)), Classifier] public ESurvival Survival;
    [FieldConverter(typeof(EnumCsvConverter<EPassengerClass>))] public EPassengerClass PassengerClass;
    [FieldQuoted] public string Name;
    [FieldConverter(typeof(EnumCsvConverter<ESex>))] public ESex Sex;
    public double? Age;
    public int? NumSiblingsOrSpouses;
    public int? NumParentsChildren;
    public string TicketNumber;
    public double? PassengerFare;
    public string CabinNum;
    [FieldConverter(typeof(EnumCsvConverter<EPort>))] public EPort? PortOfEmbarkation;
  }
}