namespace Ml2.Clstr
{
  public interface IClusterer<T>
  {
    IClusterer<T> Build();
    int Classify(T row);
  }
}