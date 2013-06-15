using weka.core;

namespace Ml2.Arff
{
  internal interface IArffInstanceBuilder
  {
    Instances Build();
  }
}