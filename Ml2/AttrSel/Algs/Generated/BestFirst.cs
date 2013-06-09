using Ml2.AttrSel.Evals;
using weka.core;

namespace Ml2.AttrSel.Algs
{
  /// <summary>
  /// BestFirst: Searches the space of attribute subsets by greedy hillclimbing
  /// augmented with a backtracking facility. Setting the number of consecutive
  /// non-improving nodes allowed controls the level of backtracking done. Best
  /// first may start with the empty set of attributes and search forward, or
  /// start with the full set of attributes and search backward, or start at any
  /// point and search in both directions (by considering all possible single
  /// attribute additions and deletions at a given point).
  /// </summary>
  public class BestFirst
  {
    private readonly weka.attributeSelection.BestFirst impl = new weka.attributeSelection.BestFirst();
    private readonly Instances inst;
    
    public BestFirst(Instances inst) { this.inst = inst; }

    /// <summary>
    /// Set the start point for the search. This is specified as a comma
    /// seperated list off attribute indexes starting at 1. It can include ranges. Eg.
    /// 1,2,5-9,17.
    /// </summary>
    public BestFirst StartSet (string value) {
      impl.setStartSet(value);
      return this;
    }

    /// <summary>
    /// Set the amount of backtracking. Specify the number of
    /// </summary>
    public BestFirst SearchTermination (int value) {
      impl.setSearchTermination(value);
      return this;
    }

    /// <summary>
    /// Set the maximum size of the lookup cache of evaluated subsets. This is
    /// expressed as a multiplier of the number of attributes in the data set.
    /// (default = 1).
    /// </summary>
    public BestFirst LookupCacheSize (int value) {
      impl.setLookupCacheSize(value);
      return this;
    }

        
    public int[] Search(IAttributeSelectionEvaluator eval) { return impl.search(eval.GetImpl(), inst); }
  }
}