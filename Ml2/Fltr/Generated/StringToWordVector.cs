using weka.filters.unsupervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Converts String attributes into a set of attributes representing word
  /// occurrence (depending on the tokenizer) information from the text contained in
  /// the strings. The set of words (attributes) is determined by the first
  /// batch filtered (typically training data).
  /// </summary>
  public class StringToWordVector<T> : BaseFilter<T, StringToWordVector>
  {
    public StringToWordVector(Runtime<T> rt) : base(rt, new StringToWordVector()) {}

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector<T> SelectedRange (string newSelectedRange) {
      ((StringToWordVector)Impl).setSelectedRange(newSelectedRange);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected attributes in the
    /// range will be worked on; if true, only non-selected attributes will be
    /// processed.
    /// </summary>    
    public StringToWordVector<T> InvertSelection (bool invert) {
      ((StringToWordVector)Impl).setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Prefix for the created attribute names. (default: "")
    /// </summary>    
    public StringToWordVector<T> AttributeNamePrefix (string newPrefix) {
      ((StringToWordVector)Impl).setAttributeNamePrefix(newPrefix);
      return this;
    }

    /// <summary>
    /// The number of words (per class if there is a class attribute assigned) to
    /// attempt to keep.
    /// </summary>    
    public StringToWordVector<T> WordsToKeep (int newWordsToKeep) {
      ((StringToWordVector)Impl).setWordsToKeep(newWordsToKeep);
      return this;
    }

    /// <summary>
    /// Specify the rate (x% of the input dataset) at which to periodically prune
    /// the dictionary. wordsToKeep prunes after creating a full dictionary. You
    /// may not have enough memory for this approach.
    /// </summary>    
    public StringToWordVector<T> PeriodicPruning (double newPeriodicPruning) {
      ((StringToWordVector)Impl).setPeriodicPruning(newPeriodicPruning);
      return this;
    }

    /// <summary>
    /// Sets the minimum term frequency. This is enforced on a per-class basis.
    /// </summary>    
    public StringToWordVector<T> MinTermFreq (int newMinTermFreq) {
      ((StringToWordVector)Impl).setMinTermFreq(newMinTermFreq);
      return this;
    }

    /// <summary>
    /// Output word counts rather than boolean 0 or 1(indicating presence or
    /// absence of a word).
    /// </summary>    
    public StringToWordVector<T> OutputWordCounts (bool outputWordCounts) {
      ((StringToWordVector)Impl).setOutputWordCounts(outputWordCounts);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector<T> TFTransform (bool TFTransform) {
      ((StringToWordVector)Impl).setTFTransform(TFTransform);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector<T> IDFTransform (bool IDFTransform) {
      ((StringToWordVector)Impl).setIDFTransform(IDFTransform);
      return this;
    }

    /// <summary>
    /// If this is set, the maximum number of words and the minimum term
    /// frequency is not enforced on a per-class basis but based on the documents in all
    /// the classes (even if a class attribute is set).
    /// </summary>    
    public StringToWordVector<T> DoNotOperateOnPerClassBasis (bool newDoNotOperateOnPerClassBasis) {
      ((StringToWordVector)Impl).setDoNotOperateOnPerClassBasis(newDoNotOperateOnPerClassBasis);
      return this;
    }

    /// <summary>
    /// Sets whether if the word frequencies for a document (instance) should be
    /// normalized or not.
    /// </summary>    
    public StringToWordVector<T> NormalizeDocLength (ENormalizeDocLength newType) {
      ((StringToWordVector)Impl).setNormalizeDocLength(new weka.core.SelectedTag((int) newType, StringToWordVector.TAGS_FILTER));
      return this;
    }

    /// <summary>
    /// If set then all the word tokens are converted to lower case before being
    /// added to the dictionary.
    /// </summary>    
    public StringToWordVector<T> LowerCaseTokens (bool downCaseTokens) {
      ((StringToWordVector)Impl).setLowerCaseTokens(downCaseTokens);
      return this;
    }

    /// <summary>
    /// Ignores all the words that are on the stoplist, if set to true.
    /// </summary>    
    public StringToWordVector<T> UseStoplist (bool useStoplist) {
      ((StringToWordVector)Impl).setUseStoplist(useStoplist);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public StringToWordVector<T> AttributeIndices (string rangeList) {
      ((StringToWordVector)Impl).setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector<T> InputFormat (Runtime<T> instanceInfo) {
      ((StringToWordVector)Impl).setInputFormat(instanceInfo.Instances);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public StringToWordVector<T> AttributeIndicesArray (int[] attributes) {
      ((StringToWordVector)Impl).setAttributeIndicesArray(attributes);
      return this;
    }

        
    public enum ENormalizeDocLength {
      No_normalization = 0,
      Normalize_all_data = 1,
      Normalize_test_data_only = 2
    }

        
  }
}