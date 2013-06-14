using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Algs
{
  /// <summary>
  /// BestFirst:<br/><br/>Searches the space of attribute subsets by greedy
  /// hillclimbing augmented with a backtracking facility. Setting the number of
  /// consecutive non-improving nodes allowed controls the level of backtracking
  /// done. Best first may start with the empty set of attributes and search
  /// forward, or start with the full set of attributes and search backward, or start at
  /// any point and search in both directions (by considering all possible
  /// single attribute additions and deletions at a given
  /// point).<br/><br/><br/>Options:<br/><br/>-P &lt;start set&gt; = 	Specify a starting set of
  /// attributes.<br/>	Eg. 1,3,5-7.<br/>-D &lt;0 = backward | 1 = forward | 2 =
  /// bi-directional&gt; = 	Direction of search. (default = 1).<br/>-N &lt;num&gt; = 	Number of
  /// non-improving nodes to<br/>	consider before terminating search.<br/>-S
  /// &lt;num&gt; = 	Size of lookup cache for evaluated subsets.<br/>	Expressed as a
  /// multiple of the number of<br/>	attributes in the data set. (default = 1)
  /// </summary>
  public class BestFirst<T> : BaseAttributeSelectionAlgorithm<T, BestFirst> where T : new()
  {
    public BestFirst(Runtime<T> rt) : base(rt, new BestFirst()) {}

    /// <summary>
    /// Set the start point for the search. This is specified as a comma
    /// seperated list off attribute indexes starting at 1. It can include ranges. Eg.
    /// 1,2,5-9,17.
    /// </summary>    
    public BestFirst<T> StartSet (string startSet) {
      ((BestFirst)Impl).setStartSet(startSet);
      return this;
    }

    /// <summary>
    /// Set the direction of the search.
    /// </summary>    
    public BestFirst<T> Direction (EDirection d) {
      ((BestFirst)Impl).setDirection(new weka.core.SelectedTag((int) d, BestFirst.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// Set the amount of backtracking. Specify the number of
    /// </summary>    
    public BestFirst<T> SearchTermination (int t) {
      ((BestFirst)Impl).setSearchTermination(t);
      return this;
    }

    /// <summary>
    /// Set the maximum size of the lookup cache of evaluated subsets. This is
    /// expressed as a multiplier of the number of attributes in the data set.
    /// (default = 1).
    /// </summary>    
    public BestFirst<T> LookupCacheSize (int size) {
      ((BestFirst)Impl).setLookupCacheSize(size);
      return this;
    }

        
    public enum EDirection {
      Backward = 0,
      Forward = 1,
      Bi_directional = 2
    }

        
  }
}