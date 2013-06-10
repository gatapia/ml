using Ml2.AttrSel.Evals;
using weka.core;

namespace Ml2.AttrSel.Algs.Generated
{
  /// <summary>
  /// GreedyStepwise : Performs a greedy forward or backward search through the
  /// space of attribute subsets. May start with no/all attributes or from an
  /// arbitrary point in the space. Stops when the addition/deletion of any
  /// remaining attributes results in a decrease in evaluation. Can also produce a
  /// ranked list of attributes by traversing the space from one side to the other and
  /// recording the order that attributes are selected.
  /// </summary>
  public class GreedyStepwise
  {
    private readonly weka.attributeSelection.GreedyStepwise impl = new weka.attributeSelection.GreedyStepwise();
    private readonly Instances inst;
    
    public GreedyStepwise(Instances inst) { this.inst = inst; }

    /// <summary>
    /// Set to true if a ranked list is required.
    /// </summary>
    public GreedyStepwise GenerateRanking (bool value) {
      impl.setGenerateRanking(value);
      return this;
    }

    /// <summary>
    /// Search backwards rather than forwards.
    /// </summary>
    public GreedyStepwise SearchBackwards (bool value) {
      impl.setSearchBackwards(value);
      return this;
    }

    /// <summary>
    /// If true (and forward search is selected) then attributes will continue to
    /// be added to the best subset as long as merit does not degrade.
    /// </summary>
    public GreedyStepwise ConservativeForwardSelection (bool value) {
      impl.setConservativeForwardSelection(value);
      return this;
    }

    /// <summary>
    /// Set the start point for the search. This is specified as a comma
    /// seperated list off attribute indexes starting at 1. It can include ranges. Eg.
    /// 1,2,5-9,17.
    /// </summary>
    public GreedyStepwise StartSet (string value) {
      impl.setStartSet(value);
      return this;
    }

    /// <summary>
    /// Set threshold by which attributes can be discarded. Default value results
    /// in no attributes being discarded. Use in conjunction with generateRanking
    /// </summary>
    public GreedyStepwise Threshold (double value) {
      impl.setThreshold(value);
      return this;
    }

    /// <summary>
    /// Specify the number of attributes to retain. The default value (-1)
    /// indicates that all attributes are to be retained. Use either this option or a
    /// threshold to reduce the attribute set.
    /// </summary>
    public GreedyStepwise NumToSelect (int value) {
      impl.setNumToSelect(value);
      return this;
    }

        
    public int[] Search(IAttributeSelectionEvaluator eval) { return impl.search(eval.GetImpl(), inst); }
  }
}