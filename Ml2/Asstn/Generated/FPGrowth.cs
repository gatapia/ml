using weka.core;
using weka.associations;

// ReSharper disable once CheckNamespace
namespace Ml2.Asstn
{
  /// <summary>
  /// Class implementing the FP-growth algorithm for finding large item sets
  /// without candidate generation. Iteratively reduces the minimum support until
  /// it finds the required number of rules with the given minimum metric. For
  /// more information see: J. Han, J.Pei, Y. Yin: Mining frequent patterns without
  /// candidate generation. In: Proceedings of the 2000 ACM-SIGMID International
  /// Conference on Management of Data, 1-12, 2000.
  /// </summary>
  public class FPGrowth<T> : BaseAssociation<T, FPGrowth> where T : new()
  {
    public FPGrowth(Runtime<T> rt) : base(rt, new FPGrowth()) {}

    /// <summary>
    /// Set the index of binary valued attributes that is to be considered the
    /// positive index. Has no effect for sparse data (in this case the first index
    /// (i.e. non-zero values) is always treated as positive. Also has no effect for
    /// unary valued attributes (i.e. when using the Weka Apriori-style format for
    /// market basket data, which uses missing value "?" to indicate absence of an
    /// item.
    /// </summary>    
    public FPGrowth<T> PositiveIndex (int index) {
      ((FPGrowth)Impl).setPositiveIndex(index);
      return this;
    }    

    /// <summary>
    /// The maximum number of items to include in frequent item sets. -1 means no
    /// limit.
    /// </summary>    
    public FPGrowth<T> MaxNumberOfItems (int max) {
      ((FPGrowth)Impl).setMaxNumberOfItems(max);
      return this;
    }    

    /// <summary>
    /// The number of rules to output
    /// </summary>    
    public FPGrowth<T> NumRulesToFind (int numR) {
      ((FPGrowth)Impl).setNumRulesToFind(numR);
      return this;
    }    

    /// <summary>
    /// Minimum metric score. Consider only rules with scores higher than this
    /// value.
    /// </summary>    
    public FPGrowth<T> MinMetric (double v) {
      ((FPGrowth)Impl).setMinMetric(v);
      return this;
    }    

    /// <summary>
    /// Iteratively decrease support by this factor. Reduces support until min
    /// support is reached or required number of rules has been generated.
    /// </summary>    
    public FPGrowth<T> Delta (double v) {
      ((FPGrowth)Impl).setDelta(v);
      return this;
    }    

    /// <summary>
    /// Lower bound for minimum support as a fraction or number of instances.
    /// </summary>    
    public FPGrowth<T> LowerBoundMinSupport (double v) {
      ((FPGrowth)Impl).setLowerBoundMinSupport(v);
      return this;
    }    

    /// <summary>
    /// Upper bound for minimum support as a fraction or number of instances.
    /// Start iteratively decreasing minimum support from this value.
    /// </summary>    
    public FPGrowth<T> UpperBoundMinSupport (double v) {
      ((FPGrowth)Impl).setUpperBoundMinSupport(v);
      return this;
    }    

    /// <summary>
    /// Limit input to FPGrowth to those transactions (instances) that contain
    /// these items. Provide a comma separated list of attribute names.
    /// </summary>    
    public FPGrowth<T> TransactionsMustContain (string list) {
      ((FPGrowth)Impl).setTransactionsMustContain(list);
      return this;
    }    

    /// <summary>
    /// Only print rules that contain these items. Provide a comma separated list
    /// of attribute names.
    /// </summary>    
    public FPGrowth<T> RulesMustContain (string list) {
      ((FPGrowth)Impl).setRulesMustContain(list);
      return this;
    }    

    /// <summary>
    /// Use OR instead of AND for transactions/rules must contain lists.
    /// </summary>    
    public FPGrowth<T> UseORForMustContainList (bool b) {
      ((FPGrowth)Impl).setUseORForMustContainList(b);
      return this;
    }    

    /// <summary>
    /// Find all rules that meet the lower bound on minimum support and the
    /// minimum metric constraint. Turning this mode on will disable the iterative
    /// support reduction procedure to find the specified number of rules.
    /// </summary>    
    public FPGrowth<T> FindAllRulesForSupportLevel (bool s) {
      ((FPGrowth)Impl).setFindAllRulesForSupportLevel(s);
      return this;
    }    

    /// <summary>
    /// 
    /// </summary>    
    public FPGrowth<T> OffDiskReportingFrequency (int freq) {
      ((FPGrowth)Impl).setOffDiskReportingFrequency(freq);
      return this;
    }    

          
        
  }
}