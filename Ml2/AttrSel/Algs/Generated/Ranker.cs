using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Algs
{
  /// <summary>
  /// Ranker : Ranks attributes by their individual evaluations. Use in
  /// conjunction with attribute evaluators (ReliefF, GainRatio, Entropy etc).
  /// </summary>
  public class Ranker<T> : BaseAttributeSelectionAlgorithm<T, Ranker>
  {
    public Ranker(Runtime<T> rt) : base(rt, new Ranker()) {}

    /// <summary>
    /// Specify a set of attributes to ignore. When generating the ranking,
    /// Ranker will not evaluate the attributes in this list. This is specified as a
    /// comma seperated list off attribute indexes starting at 1. It can include
    /// ranges. Eg. 1,2,5-9,17.
    /// </summary>    
    public Ranker<T> StartSet (string startSet) {
      ((Ranker)Impl).setStartSet(startSet);
      return this;
    }

    /// <summary>
    /// Set threshold by which attributes can be discarded. Default value results
    /// in no attributes being discarded. Use either this option or numToSelect to
    /// reduce the attribute set.
    /// </summary>    
    public Ranker<T> Threshold (double threshold) {
      ((Ranker)Impl).setThreshold(threshold);
      return this;
    }

    /// <summary>
    /// Specify the number of attributes to retain. The default value (-1)
    /// indicates that all attributes are to be retained. Use either this option or a
    /// threshold to reduce the attribute set.
    /// </summary>    
    public Ranker<T> NumToSelect (int n) {
      ((Ranker)Impl).setNumToSelect(n);
      return this;
    }

    /// <summary>
    /// A constant option. Ranker is only capable of generating attribute
    /// rankings.
    /// </summary>    
    public Ranker<T> GenerateRanking (bool doRank) {
      ((Ranker)Impl).setGenerateRanking(doRank);
      return this;
    }

        
        
  }
}