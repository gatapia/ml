using weka.filters.supervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A supervised attribute filter that can be used to select attributes. It
  /// is very flexible and allows various search and evaluation methods to be
  /// combined.
  /// </summary>
  public class AttributeSelection<T> : BaseFilter<T, AttributeSelection> where T : new()
  {
    public AttributeSelection(Runtime<T> rt) : base(rt, new AttributeSelection()) {}

    /// <summary>
    /// Determines how attributes/attribute subsets are evaluated.
    /// </summary>    
    public AttributeSelection<T> Evaluator (AttrSel.Evals.BaseAttributeSelectionEvaluator<T, weka.attributeSelection.ASEvaluation> evaluator) {
      ((AttributeSelection)Impl).setEvaluator(evaluator.Impl);
      return this;
    }

    /// <summary>
    /// Determines the search method.
    /// </summary>    
    public AttributeSelection<T> Search (AttrSel.Algs.BaseAttributeSelectionAlgorithm<T, weka.attributeSelection.ASSearch> search) {
      ((AttributeSelection)Impl).setSearch(search.Impl);
      return this;
    }

        
        
  }
}