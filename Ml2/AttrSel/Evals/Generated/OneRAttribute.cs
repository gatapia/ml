using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// OneRAttributeEval :<br/><br/>Evaluates the worth of an attribute by using
  /// the OneR classifier.<br/><br/><br/>Options:<br/><br/>-S &lt;seed&gt; =
  /// 	Random number seed for cross validation<br/>	(default = 1)<br/>-F
  /// &lt;folds&gt; = 	Number of folds for cross validation<br/>	(default = 10)<br/>-D =
  /// 	Use training data for evaluation rather than cross validaton<br/>-B
  /// &lt;minimum bucket size&gt; = 	Minimum number of objects in a bucket<br/>	(passed on
  /// to OneR, default = 6)
  /// </summary>
  public class OneRAttribute<T> : BaseAttributeSelectionEvaluator<T, OneRAttributeEval> where T : new()
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