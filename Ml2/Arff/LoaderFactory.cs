namespace Ml2.Arff
{
  internal class LoaderFactory : ILoaderFactory
  {

    public ILoader Get<T>(string extension = "csv")
    {
      if (extension == "arff") return new ArffLoaderWrapper();
      return new CsvLoader();
    }
  }
}