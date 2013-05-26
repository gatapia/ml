namespace ML
{
  public class TrainingExample
  {
    public double[] xi { get; set; }
    public double yi { get; set; }

    public TrainingExample Scale(double[] μs, double[] rs)
    {
      var n = xi.Length;
      var xi2 = new double[n];
      for (int i = 0; i < n; i++)
      {
        // (xi-μi)/range(xs)
        xi2[i] = (xi2[i] - μs[i])/rs[i];
      }
      return new TrainingExample {xi = xi2, yi = yi};
    }
  }
}