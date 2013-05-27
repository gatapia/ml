using System;
using System.Linq;

namespace ML.NeuralNet
{
  /// <summary>
  /// L = no of layers in the network
  /// sl = no of units (not counting bias unit) in layer 'l'
  /// With a binary classification NN we have only 1 output unit (sl = 1) and
  ///   the output of that unit is a real number (ℛ)
  /// K can also denote the number of units in the output layer. K=1 for 
  ///   binary classification
  /// 
  /// </summary>
  public class NeuralNetworks
  {
    public double CostFunction(TrainingSet t, double λ, double[] Θ, Func<double[], double> hθ) {
      return (-1.0/t.m) * t.Sum(e => {
        var hθxi = hθ(e.xi);
        return e.yi*Math.Log(hθxi) + (1-e.yi)*Math.Log(1- hθxi);
      }) + (λ/(2*t.m)) * Θ.Skip(1).Sum(θ => θ*θ);
    }
  }
}