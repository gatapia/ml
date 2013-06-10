using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// ReliefFAttributeEval : Evaluates the worth of an attribute by repeatedly
  /// sampling an instance and considering the value of the given attribute for
  /// the nearest instance of the same and different class. Can operate on both
  /// discrete and continuous class data. For more information see: Kenji Kira,
  /// Larry A. Rendell: A Practical Approach to Feature Selection. In: Ninth
  /// International Workshop on Machine Learning, 249-256, 1992. Igor Kononenko:
  /// Estimating Attributes: Analysis and Extensions of RELIEF. In: European Conference
  /// on Machine Learning, 171-182, 1994. Marko Robnik-Sikonja, Igor Kononenko:
  /// An adaptation of Relief for attribute estimation in regression. In:
  /// Fourteenth International Conference on Machine Learning, 296-304, 1997.
  /// </summary>
  public class ReliefFAttribute : IAttributeSelectionEvaluator
  {
    private readonly ReliefFAttributeEval impl = new ReliefFAttributeEval();
    
    /// <summary>
    /// Weight nearest neighbours by their distance.
    /// </summary>    
    public ReliefFAttribute WeightByDistance (bool value) {
      impl.setWeightByDistance(value);
      return this;
    }

    /// <summary>
    /// Number of instances to sample. Default (-1) indicates that all instances
    /// will be used for attribute estimation.
    /// </summary>    
    public ReliefFAttribute SampleSize (int value) {
      impl.setSampleSize(value);
      return this;
    }

    /// <summary>
    /// Random seed for sampling instances.
    /// </summary>    
    public ReliefFAttribute Seed (int value) {
      impl.setSeed(value);
      return this;
    }

    /// <summary>
    /// Number of nearest neighbours for attribute estimation.
    /// </summary>    
    public ReliefFAttribute NumNeighbours (int value) {
      impl.setNumNeighbours(value);
      return this;
    }

    /// <summary>
    /// Set influence of nearest neighbours. Used in an exp function to control
    /// how quickly weights decrease for more distant instances. Use in conjunction
    /// with weightByDistance. Sensible values = 1/5 to 1/10 the number of nearest
    /// neighbours.
    /// </summary>    
    public ReliefFAttribute Sigma (int value) {
      impl.setSigma(value);
      return this;
    }

        
    public ASEvaluation GetImpl() { return impl; }
  }
}