using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// WrapperSubsetEval: Evaluates attribute sets by using a learning scheme.
  /// Cross validation is used to estimate the accuracy of the learning scheme for
  /// a set of attributes. For more information see: Ron Kohavi, George H. John
  /// (1997). Wrappers for feature subset selection. Artificial Intelligence.
  /// 97(1-2):273-324.
  /// </summary>
  public class WrapperSubset<T> : BaseAttributeSelectionEvaluator<T>
  {
    public WrapperSubset(Runtime<T> rt) : base(rt, new WrapperSubsetEval()) {}
    
    /// <summary>
    /// Classifier to use for estimating the accuracy of subsets
    /// </summary>    
    public WrapperSubset<T> Classifier (Clss.BaseClassifier<T> newClassifier) {
      ((WrapperSubsetEval)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// Number of xval folds to use when estimating subset accuracy.
    /// </summary>    
    public WrapperSubset<T> Folds (int f) {
      ((WrapperSubsetEval)Impl).setFolds(f);
      return this;
    }

    /// <summary>
    /// Seed to use for randomly generating xval splits.
    /// </summary>    
    public WrapperSubset<T> Seed (int s) {
      ((WrapperSubsetEval)Impl).setSeed(s);
      return this;
    }

    /// <summary>
    /// Repeat xval if stdev of mean exceeds this value.
    /// </summary>    
    public WrapperSubset<T> Threshold (double t) {
      ((WrapperSubsetEval)Impl).setThreshold(t);
      return this;
    }

    /// <summary>
    /// The measure used to evaluate the performance of attribute combinations.
    /// </summary>    
    public WrapperSubset<T> EvaluationMeasure (EEvaluationMeasure newMethod) {
      ((WrapperSubsetEval)Impl).setEvaluationMeasure(new weka.core.SelectedTag((int) newMethod, WrapperSubsetEval.TAGS_EVALUATION));
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public WrapperSubset<T> IRClassValue (string val) {
      ((WrapperSubsetEval)Impl).setIRClassValue(val);
      return this;
    }

            
    public enum EEvaluationMeasure {
      Default__accuracy_discrete_class_RMSE_numeric_class = 1,
      Accuracy_discrete_class_only = 2,
      RMSE_of_the_class_probabilities_for_discrete_class = 3,
      MAE_of_the_class_probabilities_for_discrete_class = 4,
      F_measure_discrete_class_only = 5,
      AUC_area_under_the_ROC_curve___discrete_class_only = 6,
      AUPRC_area_under_the_precision_recall_curve___discrete_class_only = 7
    }

        
  }
}