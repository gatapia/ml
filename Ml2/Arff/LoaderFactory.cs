namespace Ml2.Arff
{
  internal class LoaderFactory : ILoaderFactory
  {
    public ILoader Get<T>() { return new CsvLoader(); }
  }
}