using weka.core;
using weka.filters.supervised.attribute;
using System.Linq;

namespace Ml2.Fltr
{
  /// <summary>
  /// A supervised attribute filter that can be used to select attributes. It
  /// is very flexible and allows various search and evaluation methods to be
  /// combined.
  /// </summary>
  public class AttributeSelection<T> : BaseFilter<T>
  {
    public AttributeSelection(Runtime<T> rt) : base(rt, new AttributeSelection()) {}

    /// <summary>
    /// Determines how attributes/attribute subsets are evaluated.
    /// </summary>    
    public AttributeSelection<T> Evaluator (AttrSel.Evals.BaseAttributeSelectionEvaluator<T> value) {
      ((AttributeSelection)Impl).setEvaluator(value.Impl);
      return this;
    }

    /// <summary>
    /// Determines the search method.
    /// </summary>    
    public AttributeSelection<T> Search (AttrSel.Algs.BaseAttributeSelectionAlgorithm<T> value) {
      ((AttributeSelection)Impl).setSearch(value.Impl);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public AttributeSelection<T> InputFormat (Runtime<T> value) {
      ((AttributeSelection)Impl).setInputFormat(value.Instances);
      return this;
    }

        
        
  }
}