using weka.core;

namespace Ml2.AttrSel.Algs.Generated
{
  public class Algorithms
  {
    private readonly Instances inst;    
    public Algorithms(Instances inst) { this.inst = inst; }   

    /// <summary>
    /// BestFirst: Searches the space of attribute subsets by greedy hillclimbing
    /// augmented with a backtracking facility. Setting the number of consecutive
    /// non-improving nodes allowed controls the level of backtracking done. Best
    /// first may start with the empty set of attributes and search forward, or
    /// start with the full set of attributes and search backward, or start at any
    /// point and search in both directions (by considering all possible single
    /// attribute additions and deletions at a given point).
    /// </summary>
    public BestFirst BestFirst() { return new BestFirst(inst); }

    /// <summary>
    /// GreedyStepwise : Performs a greedy forward or backward search through the
    /// space of attribute subsets. May start with no/all attributes or from an
    /// arbitrary point in the space. Stops when the addition/deletion of any
    /// remaining attributes results in a decrease in evaluation. Can also produce a
    /// ranked list of attributes by traversing the space from one side to the other and
    /// recording the order that attributes are selected.
    /// </summary>
    public GreedyStepwise GreedyStepwise() { return new GreedyStepwise(inst); }

    /// <summary>
    /// Ranker : Ranks attributes by their individual evaluations. Use in
    /// conjunction with attribute evaluators (ReliefF, GainRatio, Entropy etc).
    /// </summary>
    public Ranker Ranker() { return new Ranker(inst); }

    
  }
}