using System;

namespace Ml2.Arff
{
  internal class LoaderFactory : ILoaderFactory
  {
    public ILoader Get<T>()
    {
      if (typeof(CsvRow).IsAssignableFrom(typeof(T)))
      {
        return new CsvLoader();
      }
      throw new NotSupportedException(typeof (T).Name + " is not supported by any ILoader");
    }
  }
}