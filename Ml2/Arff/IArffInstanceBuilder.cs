using weka.core;

namespace Ml2.Arff
{
  internal interface IArffInstanceBuilder<T>
  {
    IArffInstanceBuilder<T> Build();
    Instances Instances { get; }
    Observation<T>[] Observations { get; }
  }
}