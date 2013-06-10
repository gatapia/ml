using Ml2.AttrSel.Evals;
using weka.core;

namespace Ml2.AttrSel.Algs.Generated
{
  /// <summary>
  /// Ranker : Ranks attributes by their individual evaluations. Use in
  /// conjunction with attribute evaluators (ReliefF, GainRatio, Entropy etc).
  /// </summary>
  public class Ranker
  {
    private readonly weka.attributeSelection.Ranker impl = new weka.attributeSelection.Ranker();
    private readonly Instances inst;
    
    public Ranker(Instances inst) { this.inst = inst; }

    /// <summary>
    /// Specify a set of attributes to ignore. When generating the ranking,
    /// Ranker will not evaluate the attributes in this list. This is specified as a
    /// comma seperated list off attribute indexes starting at 1. It can include
    /// ranges. Eg. 1,2,5-9,17.
    /// </summary>
    public Ranker StartSet (string value) {
      impl.setStartSet(value);
      return this;
    }

    /// <summary>
    /// Set threshold by which attributes can be discarded. Default value results
    /// in no attributes being discarded. Use either this option or numToSelect to
    /// reduce the attribute set.
    /// </summary>
    public Ranker Threshold (double value) {
      impl.setThreshold(value);
      return this;
    }

    /// <summary>
    /// Specify the number of attributes to retain. The default value (-1)
    /// indicates that all attributes are to be retained. Use either this option or a
    /// threshold to reduce the attribute set.
    /// </summary>
    public Ranker NumToSelect (int value) {
      impl.setNumToSelect(value);
      return this;
    }

    /// <summary>
    /// A constant option. Ranker is only capable of generating attribute
    /// rankings.
    /// </summary>
    public Ranker GenerateRanking (bool value) {
      impl.setGenerateRanking(value);
      return this;
    }

        
    public int[] Search(IAttributeSelectionEvaluator eval) { return impl.search(eval.GetImpl(), inst); }
  }
}