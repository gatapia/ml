using System.Linq;

namespace ML
{
  public class TrainingExample
  {
    public double[] xi { get; set; }
    public double yi { get; set; }

    public TrainingExample(double yi, double[] xi) {
      this.yi = yi;
      this.xi = xi;
    }

    public TrainingExample Scale(double[] μs, double[] ranges)
    {
      return new TrainingExample(
        yi, 
        xi = xi.Select((x, i) => (x - μs[i]) / ranges[i]).ToArray()
      );
    }
  }
}