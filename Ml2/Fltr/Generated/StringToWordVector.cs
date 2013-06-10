using weka.filters.unsupervised.attribute;

namespace Ml2.Fltr
{
  /// <summary>
  /// Converts String attributes into a set of attributes representing word
  /// occurrence (depending on the tokenizer) information from the text contained in
  /// the strings. The set of words (attributes) is determined by the first
  /// batch filtered (typically training data).
  /// </summary>
  public class StringToWordVector<T> : BaseFilter<T>
  {
    public StringToWordVector(Runtime<T> rt) : base(rt, new StringToWordVector()) {}

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector<T> SelectedRange (string value) {
      ((StringToWordVector)impl).setSelectedRange(value);
      return this;
    }
    /// <summary>
    /// Set attribute selection mode. If false, only selected attributes in the
    /// range will be worked on; if true, only non-selected attributes will be
    /// processed.
    /// </summary>    
    public StringToWordVector<T> InvertSelection (bool value) {
      ((StringToWordVector)impl).setInvertSelection(value);
      return this;
    }
    /// <summary>
    /// Prefix for the created attribute names. (default: "")
    /// </summary>    
    public StringToWordVector<T> AttributeNamePrefix (string value) {
      ((StringToWordVector)impl).setAttributeNamePrefix(value);
      return this;
    }
    /// <summary>
    /// The number of words (per class if there is a class attribute assigned) to
    /// attempt to keep.
    /// </summary>    
    public StringToWordVector<T> WordsToKeep (int value) {
      ((StringToWordVector)impl).setWordsToKeep(value);
      return this;
    }
    /// <summary>
    /// Specify the rate (x% of the input dataset) at which to periodically prune
    /// the dictionary. wordsToKeep prunes after creating a full dictionary. You
    /// may not have enough memory for this approach.
    /// </summary>    
    public StringToWordVector<T> PeriodicPruning (double value) {
      ((StringToWordVector)impl).setPeriodicPruning(value);
      return this;
    }
    /// <summary>
    /// Sets the minimum term frequency. This is enforced on a per-class basis.
    /// </summary>    
    public StringToWordVector<T> MinTermFreq (int value) {
      ((StringToWordVector)impl).setMinTermFreq(value);
      return this;
    }
    /// <summary>
    /// Output word counts rather than boolean 0 or 1(indicating presence or
    /// absence of a word).
    /// </summary>    
    public StringToWordVector<T> OutputWordCounts (bool value) {
      ((StringToWordVector)impl).setOutputWordCounts(value);
      return this;
    }
    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector<T> TFTransform (bool value) {
      ((StringToWordVector)impl).setTFTransform(value);
      return this;
    }
    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector<T> IDFTransform (bool value) {
      ((StringToWordVector)impl).setIDFTransform(value);
      return this;
    }
    /// <summary>
    /// If this is set, the maximum number of words and the minimum term
    /// frequency is not enforced on a per-class basis but based on the documents in all
    /// the classes (even if a class attribute is set).
    /// </summary>    
    public StringToWordVector<T> DoNotOperateOnPerClassBasis (bool value) {
      ((StringToWordVector)impl).setDoNotOperateOnPerClassBasis(value);
      return this;
    }
    /// <summary>
    /// If set then all the word tokens are converted to lower case before being
    /// added to the dictionary.
    /// </summary>    
    public StringToWordVector<T> LowerCaseTokens (bool value) {
      ((StringToWordVector)impl).setLowerCaseTokens(value);
      return this;
    }
    /// <summary>
    /// Ignores all the words that are on the stoplist, if set to true.
    /// </summary>    
    public StringToWordVector<T> UseStoplist (bool value) {
      ((StringToWordVector)impl).setUseStoplist(value);
      return this;
    }
    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public StringToWordVector<T> AttributeIndices (string value) {
      ((StringToWordVector)impl).setAttributeIndices(value);
      return this;
    }
        
  }
}