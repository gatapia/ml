using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
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
    public OneRAttribute<T> Seed (int seed) {
      ((OneRAttributeEval)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// Set the number of folds for cross validation.
    /// </summary>    
    public OneRAttribute<T> Folds (int folds) {
      ((OneRAttributeEval)Impl).setFolds(folds);
      return this;
    }

    /// <summary>
    /// The minimum number of objects in a bucket (passed to OneR).
    /// </summary>    
    public OneRAttribute<T> MinimumBucketSize (int minB) {
      ((OneRAttributeEval)Impl).setMinimumBucketSize(minB);
      return this;
    }

    /// <summary>
    /// Use the training data to evaluate attributes rather than cross
    /// validation.
    /// </summary>    
    public OneRAttribute<T> EvalUsingTrainingData (bool e) {
      ((OneRAttributeEval)Impl).setEvalUsingTrainingData(e);
      return this;
    }

            
        
  }
}