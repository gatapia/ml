namespace Ml2.Arff
{
  internal interface ILoaderFactory
  {
    ILoader Get<T>();
  }
}