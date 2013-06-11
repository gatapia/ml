using weka.core;
using weka.associations;

namespace Ml2.Asstn
{
  /// <summary>
  /// Class implementing an Apriori-type algorithm. Iteratively reduces the
  /// minimum support until it finds the required number of rules with the given
  /// minimum confidence. The algorithm has an option to mine class association
  /// rules. It is adapted as explained in the second reference. For more information
  /// see: R. Agrawal, R. Srikant: Fast Algorithms for Mining Association Rules
  /// in Large Databases. In: 20th International Conference on Very Large Data
  /// Bases, 478-499, 1994. Bing Liu, Wynne Hsu, Yiming Ma: Integrating
  /// Classification and Association Rule Mining. In: Fourth International Conference on
  /// Knowledge Discovery and Data Mining, 80-86, 1998.
  /// </summary>
  public class Apriori<T> : BaseAssociation<T>
  {
    public Apriori(Runtime<T> rt) : base(rt, new Apriori()) {}

    /// <summary>
    /// Set the type of metric by which to rank rules. Confidence is the
    /// proportion of the examples covered by the premise that are also covered by the
    /// consequence (Class association rules can only be mined using confidence). Lift
    /// is confidence divided by the proportion of all examples that are covered by
    /// the consequence. This is a measure of the importance of the association
    /// that is independent of support. Leverage is the proportion of additional
    /// examples covered by both the premise and consequence above those expected if
    /// the premise and consequence were independent of each other. The total number
    /// of examples that this represents is presented in brackets following the
    /// leverage. Conviction is another measure of departure from independence.
    /// Conviction is given by P(premise)P(!consequence) / P(premise, !consequence).
    /// </summary>    
    public Apriori<T> MetricType (EMetricType value) {
      ((Apriori)impl).setMetricType(new SelectedTag((int) value, Apriori.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// Upper bound for minimum support. Start iteratively decreasing minimum
    /// support from this value.
    /// </summary>    
    public Apriori<T> UpperBoundMinSupport (double value) {
      ((Apriori)impl).setUpperBoundMinSupport(value);
      return this;
    }

    /// <summary>
    /// Remove columns with all missing values.
    /// </summary>    
    public Apriori<T> RemoveAllMissingCols (bool value) {
      ((Apriori)impl).setRemoveAllMissingCols(value);
      return this;
    }

    /// <summary>
    /// Minimum metric score. Consider only rules with scores higher than this
    /// value.
    /// </summary>    
    public Apriori<T> MinMetric (double value) {
      ((Apriori)impl).setMinMetric(value);
      return this;
    }

    /// <summary>
    /// Index of the class attribute. If set to -1, the last attribute is taken
    /// as class attribute.
    /// </summary>    
    public Apriori<T> ClassIndex (int value) {
      ((Apriori)impl).setClassIndex(value);
      return this;
    }

    /// <summary>
    /// If enabled class association rules are mined instead of (general)
    /// association rules.
    /// </summary>    
    public Apriori<T> Car (bool value) {
      ((Apriori)impl).setCar(value);
      return this;
    }

    /// <summary>
    /// Lower bound for minimum support.
    /// </summary>    
    public Apriori<T> LowerBoundMinSupport (double value) {
      ((Apriori)impl).setLowerBoundMinSupport(value);
      return this;
    }

    /// <summary>
    /// Number of rules to find.
    /// </summary>    
    public Apriori<T> NumRules (int value) {
      ((Apriori)impl).setNumRules(value);
      return this;
    }

    /// <summary>
    /// Iteratively decrease support by this factor. Reduces support until min
    /// support is reached or required number of rules has been generated.
    /// </summary>    
    public Apriori<T> Delta (double value) {
      ((Apriori)impl).setDelta(value);
      return this;
    }

    /// <summary>
    /// Significance level. Significance test (confidence metric only).
    /// </summary>    
    public Apriori<T> SignificanceLevel (double value) {
      ((Apriori)impl).setSignificanceLevel(value);
      return this;
    }

    /// <summary>
    /// If enabled the itemsets are output as well.
    /// </summary>    
    public Apriori<T> OutputItemSets (bool value) {
      ((Apriori)impl).setOutputItemSets(value);
      return this;
    }

    /// <summary>
    /// If enabled the algorithm will be run in verbose mode.
    /// </summary>    
    public Apriori<T> Verbose (bool value) {
      ((Apriori)impl).setVerbose(value);
      return this;
    }

    /// <summary>
    /// If enabled, zero (that is, the first value of a nominal) is treated in
    /// the same way as a missing value.
    /// </summary>    
    public Apriori<T> TreatZeroAsMissing (bool value) {
      ((Apriori)impl).setTreatZeroAsMissing(value);
      return this;
    }

          
    public enum EMetricType {
      Confidence = 0,
      Lift = 1,
      Leverage = 2,
      Conviction = 3
    }

        
  }
}