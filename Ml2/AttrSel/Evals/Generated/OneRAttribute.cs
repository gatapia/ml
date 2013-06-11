using weka.core;
using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// OneRAttributeEval : Evaluates the worth of an attribute by using the OneR
  /// classifier.
  /// </summary>
  public class OneRAttribute<T> : BaseAttributeSelectionEvaluator<T>
  {
    public OneRAttribute(Runtime<T> rt) : base(rt, new OneRAttributeEval()) {}
    
    /// <summary>
    /// Set the seed for use in cross validation.
    /// </summary>    
    public OneRAttribute<T> Seed (int value) {
      ((OneRAttributeEval)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// Set the number of folds for cross validation.
    /// </summary>    
    public OneRAttribute<T> Folds (int value) {
      ((OneRAttributeEval)impl).setFolds(value);
      return this;
    }

    /// <summary>
    /// The minimum number of objects in a bucket (passed to OneR).
    /// </summary>    
    public OneRAttribute<T> MinimumBucketSize (int value) {
      ((OneRAttributeEval)impl).setMinimumBucketSize(value);
      return this;
    }

    /// <summary>
    /// Use the training data to evaluate attributes rather than cross
    /// validation.
    /// </summary>    
    public OneRAttribute<T> EvalUsingTrainingData (bool value) {
      ((OneRAttributeEval)impl).setEvalUsingTrainingData(value);
      return this;
    }

            
        
  }
}