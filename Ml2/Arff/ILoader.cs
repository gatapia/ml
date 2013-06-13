namespace Ml2.Arff
{
  internal interface ILoader
  {
    T[] Load<T>(params string[] files) where T : new();
  }
}