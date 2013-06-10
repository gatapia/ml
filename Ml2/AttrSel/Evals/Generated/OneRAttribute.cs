using weka.attributeSelection;

namespace Ml2.AttrSel.Evals.Generated
{
  /// <summary>
  /// OneRAttributeEval : Evaluates the worth of an attribute by using the OneR
  /// classifier.
  /// </summary>
  public class OneRAttribute : IAttributeSelectionEvaluator
  {
    private readonly OneRAttributeEval impl = new OneRAttributeEval();
    
    /// <summary>
    /// Set the seed for use in cross validation.
    /// </summary>    
    public OneRAttribute Seed (int value) {
      impl.setSeed(value);
      return this;
    }

    /// <summary>
    /// Set the number of folds for cross validation.
    /// </summary>    
    public OneRAttribute Folds (int value) {
      impl.setFolds(value);
      return this;
    }

    /// <summary>
    /// The minimum number of objects in a bucket (passed to OneR).
    /// </summary>    
    public OneRAttribute MinimumBucketSize (int value) {
      impl.setMinimumBucketSize(value);
      return this;
    }

    /// <summary>
    /// Use the training data to evaluate attributes rather than cross
    /// validation.
    /// </summary>    
    public OneRAttribute EvalUsingTrainingData (bool value) {
      impl.setEvalUsingTrainingData(value);
      return this;
    }

        
    public ASEvaluation GetImpl() { return impl; }
  }
}