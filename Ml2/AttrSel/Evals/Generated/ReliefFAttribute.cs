using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
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
  public class ReliefFAttribute<T> : BaseAttributeSelectionEvaluator<T, ReliefFAttributeEval>
  {
    public ReliefFAttribute(Runtime<T> rt) : base(rt, new ReliefFAttributeEval()) {}
    
    /// <summary>
    /// Weight nearest neighbours by their distance.
    /// </summary>    
    public ReliefFAttribute<T> WeightByDistance (bool b) {
      ((ReliefFAttributeEval)Impl).setWeightByDistance(b);
      return this;
    }

    /// <summary>
    /// Number of instances to sample. Default (-1) indicates that all instances
    /// will be used for attribute estimation.
    /// </summary>    
    public ReliefFAttribute<T> SampleSize (int s) {
      ((ReliefFAttributeEval)Impl).setSampleSize(s);
      return this;
    }

    /// <summary>
    /// Random seed for sampling instances.
    /// </summary>    
    public ReliefFAttribute<T> Seed (int s) {
      ((ReliefFAttributeEval)Impl).setSeed(s);
      return this;
    }

    /// <summary>
    /// Number of nearest neighbours for attribute estimation.
    /// </summary>    
    public ReliefFAttribute<T> NumNeighbours (int n) {
      ((ReliefFAttributeEval)Impl).setNumNeighbours(n);
      return this;
    }

    /// <summary>
    /// Set influence of nearest neighbours. Used in an exp function to control
    /// how quickly weights decrease for more distant instances. Use in conjunction
    /// with weightByDistance. Sensible values = 1/5 to 1/10 the number of nearest
    /// neighbours.
    /// </summary>    
    public ReliefFAttribute<T> Sigma (int s) {
      ((ReliefFAttributeEval)Impl).setSigma(s);
      return this;
    }

            
        
  }
}