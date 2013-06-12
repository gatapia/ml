using weka.core;
using weka.attributeSelection;

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
  public class BestFirst<T> : BaseAttributeSelectionAlgorithm<T>
  {
    public BestFirst(Runtime<T> rt) : base(rt, new BestFirst()) {}

    /// <summary>
    /// Set the start point for the search. This is specified as a comma
    /// seperated list off attribute indexes starting at 1. It can include ranges. Eg.
    /// 1,2,5-9,17.
    /// </summary>    
    public BestFirst<T> StartSet (string value) {
      ((BestFirst)Impl).setStartSet(value);
      return this;
    }

    /// <summary>
    /// Set the direction of the search.
    /// </summary>    
    public BestFirst<T> Direction (EDirection value) {
      ((BestFirst)Impl).setDirection(new SelectedTag((int) value, BestFirst.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// Set the amount of backtracking. Specify the number of
    /// </summary>    
    public BestFirst<T> SearchTermination (int value) {
      ((BestFirst)Impl).setSearchTermination(value);
      return this;
    }

    /// <summary>
    /// Set the maximum size of the lookup cache of evaluated subsets. This is
    /// expressed as a multiplier of the number of attributes in the data set.
    /// (default = 1).
    /// </summary>    
    public BestFirst<T> LookupCacheSize (int value) {
      ((BestFirst)Impl).setLookupCacheSize(value);
      return this;
    }

        
    public enum EDirection {
      Backward = 0,
      Forward = 1,
      Bi_directional = 2
    }

        
  }
}