using weka.core;
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
  public class ReliefFAttribute<T> : BaseAttributeSelectionEvaluator<T>
  {
    public ReliefFAttribute(Runtime<T> rt) : base(rt, new ReliefFAttributeEval()) {}
    
    /// <summary>
    /// Weight nearest neighbours by their distance.
    /// </summary>    
    public ReliefFAttribute<T> WeightByDistance (bool value) {
      ((ReliefFAttributeEval)Impl).setWeightByDistance(value);
      return this;
    }

    /// <summary>
    /// Number of instances to sample. Default (-1) indicates that all instances
    /// will be used for attribute estimation.
    /// </summary>    
    public ReliefFAttribute<T> SampleSize (int value) {
      ((ReliefFAttributeEval)Impl).setSampleSize(value);
      return this;
    }

    /// <summary>
    /// Random seed for sampling instances.
    /// </summary>    
    public ReliefFAttribute<T> Seed (int value) {
      ((ReliefFAttributeEval)Impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// Number of nearest neighbours for attribute estimation.
    /// </summary>    
    public ReliefFAttribute<T> NumNeighbours (int value) {
      ((ReliefFAttributeEval)Impl).setNumNeighbours(value);
      return this;
    }

    /// <summary>
    /// Set influence of nearest neighbours. Used in an exp function to control
    /// how quickly weights decrease for more distant instances. Use in conjunction
    /// with weightByDistance. Sensible values = 1/5 to 1/10 the number of nearest
    /// neighbours.
    /// </summary>    
    public ReliefFAttribute<T> Sigma (int value) {
      ((ReliefFAttributeEval)Impl).setSigma(value);
      return this;
    }

            
        
  }
}