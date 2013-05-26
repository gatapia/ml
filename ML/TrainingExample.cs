using System.Linq;

namespace ML
{
  public class TrainingExample
  {
    public double[] xi { get; set; }
    public double yi { get; set; }

    public TrainingExample Scale(double[] μs, double[] ranges)
    {
      return new TrainingExample
               {
                 xi = xi.Select((x, i) => (x - μs[i]) / ranges[i]).ToArray(), 
                 yi = yi
               };
    }
  }
}