using weka.core;
using weka.attributeSelection;

namespace Ml2.AttrSel.Algs
{
  /// <summary>
  /// GreedyStepwise : Performs a greedy forward or backward search through the
  /// space of attribute subsets. May start with no/all attributes or from an
  /// arbitrary point in the space. Stops when the addition/deletion of any
  /// remaining attributes results in a decrease in evaluation. Can also produce a
  /// ranked list of attributes by traversing the space from one side to the other and
  /// recording the order that attributes are selected.
  /// </summary>
  public class GreedyStepwise<T> : BaseAttributeSelectionAlgorithm<T>
  {
    public GreedyStepwise(Runtime<T> rt) : base(rt, new GreedyStepwise()) {}

    /// <summary>
    /// Set to true if a ranked list is required.
    /// </summary>
    public GreedyStepwise<T> GenerateRanking (bool value) {
      ((GreedyStepwise)impl).setGenerateRanking(value);
      return this;
    }

    /// <summary>
    /// Search backwards rather than forwards.
    /// </summary>
    public GreedyStepwise<T> SearchBackwards (bool value) {
      ((GreedyStepwise)impl).setSearchBackwards(value);
      return this;
    }

    /// <summary>
    /// If true (and forward search is selected) then attributes will continue to
    /// be added to the best subset as long as merit does not degrade.
    /// </summary>
    public GreedyStepwise<T> ConservativeForwardSelection (bool value) {
      ((GreedyStepwise)impl).setConservativeForwardSelection(value);
      return this;
    }

    /// <summary>
    /// Set the start point for the search. This is specified as a comma
    /// seperated list off attribute indexes starting at 1. It can include ranges. Eg.
    /// 1,2,5-9,17.
    /// </summary>
    public GreedyStepwise<T> StartSet (string value) {
      ((GreedyStepwise)impl).setStartSet(value);
      return this;
    }

    /// <summary>
    /// Set threshold by which attributes can be discarded. Default value results
    /// in no attributes being discarded. Use in conjunction with generateRanking
    /// </summary>
    public GreedyStepwise<T> Threshold (double value) {
      ((GreedyStepwise)impl).setThreshold(value);
      return this;
    }

    /// <summary>
    /// Specify the number of attributes to retain. The default value (-1)
    /// indicates that all attributes are to be retained. Use either this option or a
    /// threshold to reduce the attribute set.
    /// </summary>
    public GreedyStepwise<T> NumToSelect (int value) {
      ((GreedyStepwise)impl).setNumToSelect(value);
      return this;
    }

        
        
  }
}