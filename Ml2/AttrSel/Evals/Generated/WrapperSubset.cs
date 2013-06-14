using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// WrapperSubsetEval:<br/><br/>Evaluates attribute sets by using a learning
  /// scheme. Cross validation is used to estimate the accuracy of the learning
  /// scheme for a set of attributes.<br/><br/>For more information
  /// see:<br/><br/>Ron Kohavi, George H. John (1997). Wrappers for feature subset selection.
  /// Artificial Intelligence. 97(1-2):273-324.<br/><br/>Options:<br/><br/>-B
  /// &lt;base learner&gt; = 	class name of base learner to use for 	accuracy
  /// estimation.<br/>	Place any classifier options LAST on the command
  /// line<br/>	following a "--". eg.:<br/>		-B weka.classifiers.bayes.NaiveBayes ... --
  /// -K<br/>	(default: weka.classifiers.rules.ZeroR)<br/>-F &lt;num&gt; = 	number of
  /// cross validation folds to use for estimating accuracy.<br/>	(default=5)<br/>-R
  /// &lt;seed&gt; = 	Seed for cross validation accuracy
  /// testimation.<br/>	(default = 1)<br/>-T &lt;num&gt; = 	threshold by which to execute another cross
  /// validation<br/>	(standard deviation---expressed as a percentage of the
  /// mean).<br/>	(default: 0.01 (1%))<br/>-E &lt;acc | rmse | mae | f-meas | auc |
  /// auprc&gt; = 	Performance evaluation measure to use for selecting
  /// attributes.<br/>	(Default = accuracy for discrete class and rmse for numeric
  /// class)<br/>-IRclass &lt;label | index&gt; = 	Optional class value (label or 1-based
  /// index) to use in conjunction with<br/>	IR statistics (f-meas, auc or
  /// auprc). Omitting this option will use<br/>	the class-weighted
  /// average.<br/><br/>Options specific to scheme weka.classifiers.rules.ZeroR: = <br/>-D = 	If
  /// set, classifier is run in debug mode and<br/>	may output additional info to
  /// the console
  /// </summary>
  public class WrapperSubset<T> : BaseAttributeSelectionEvaluator<T, WrapperSubsetEval> where T : new()
  {
    public WrapperSubset(Runtime<T> rt) : base(rt, new WrapperSubsetEval()) {}
    
    /// <summary>
    /// Classifier to use for estimating the accuracy of subsets
    /// </summary>    
    public WrapperSubset<T> Classifier (Clss.IBaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
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