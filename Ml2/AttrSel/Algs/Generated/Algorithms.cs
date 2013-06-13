using weka.core;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Algs
{
  public class Algorithms<T> where T : new()
  {
    private readonly Runtime<T> rt;    
    public Algorithms(Runtime<T> rt) { 
      this.rt = rt;
    }   

    /// <summary>
    /// BestFirst: Searches the space of attribute subsets by greedy hillclimbing
    /// augmented with a backtracking facility. Setting the number of consecutive
    /// non-improving nodes allowed controls the level of backtracking done. Best
    /// first may start with the empty set of attributes and search forward, or
    /// start with the full set of attributes and search backward, or start at any
    /// point and search in both directions (by considering all possible single
    /// attribute additions and deletions at a given point).
    /// </summary>
    public BestFirst<T> BestFirst() { return new BestFirst<T>(rt); }

    /// <summary>
    /// GreedyStepwise : Performs a greedy forward or backward search through the
    /// space of attribute subsets. May start with no/all attributes or from an
    /// arbitrary point in the space. Stops when the addition/deletion of any
    /// remaining attributes results in a decrease in evaluation. Can also produce a
    /// ranked list of attributes by traversing the space from one side to the other and
    /// recording the order that attributes are selected.
    /// </summary>
    public GreedyStepwise<T> GreedyStepwise() { return new GreedyStepwise<T>(rt); }

    /// <summary>
    /// Ranker : Ranks attributes by their individual evaluations. Use in
    /// conjunction with attribute evaluators (ReliefF, GainRatio, Entropy etc).
    /// </summary>
    public Ranker<T> Ranker() { return new Ranker<T>(rt); }

    
  }
}