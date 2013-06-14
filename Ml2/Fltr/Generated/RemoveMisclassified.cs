using weka.filters.unsupervised.instance;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that removes instances which are incorrectly classified. Useful
  /// for removing outliers.<br/><br/>Options:<br/><br/>-W &lt;classifier
  /// specification&gt; = 	Full class name of classifier to use, followed<br/>	by scheme
  /// options. eg:<br/>		"weka.classifiers.bayes.NaiveBayes -D"<br/>	(default:
  /// weka.classifiers.rules.ZeroR)<br/>-C &lt;class index&gt; = 	Attribute on
  /// which misclassifications are based.<br/>	If < 0 will use any current set class
  /// or default to the last attribute.<br/>-F &lt;number of folds&gt; = 	The
  /// number of folds to use for cross-validation cleansing.<br/>	(<2 = no
  /// cross-validation - default).<br/>-T &lt;threshold&gt; = 	Threshold for the max
  /// error when predicting numeric class.<br/>	(Value should be >= 0, default =
  /// 0.1).<br/>-I = 	The maximum number of cleansing iterations to perform.<br/>	(<1
  /// = until fully cleansed - default)<br/>-V = 	Invert the match so that
  /// correctly classified instances are discarded.<br/>
  /// </summary>
  public class RemoveMisclassified<T> : BaseFilter<T, RemoveMisclassified> where T : new()
  {
    public RemoveMisclassified(Runtime<T> rt) : base(rt, new RemoveMisclassified()) {}

    /// <summary>
    /// The classifier upon which to base the misclassifications.
    /// </summary>    
    public RemoveMisclassified<T> Classifier (Clss.IBaseClassifier<T, weka.classifiers.Classifier> classifier) {
      ((RemoveMisclassified)Impl).setClassifier(classifier.Impl);
      return this;
    }

    /// <summary>
    /// Index of the class upon which to base the misclassifications. If < 0 will
    /// use any current set class or default to the last attribute.
    /// </summary>    
    public RemoveMisclassified<T> ClassIndex (int classIndex) {
      ((RemoveMisclassified)Impl).setClassIndex(classIndex);
      return this;
    }

    /// <summary>
    /// The number of cross-validation folds to use. If < 2 then no
    /// cross-validation will be performed.
    /// </summary>    
    public RemoveMisclassified<T> NumFolds (int numOfFolds) {
      ((RemoveMisclassified)Impl).setNumFolds(numOfFolds);
      return this;
    }

    /// <summary>
    /// Threshold for the max allowable error when predicting a numeric class.
    /// Should be >= 0.
    /// </summary>    
    public RemoveMisclassified<T> Threshold (double threshold) {
      ((RemoveMisclassified)Impl).setThreshold(threshold);
      return this;
    }

    /// <summary>
    /// The maximum number of iterations to perform. < 1 means filter will go
    /// until fully cleansed.
    /// </summary>    
    public RemoveMisclassified<T> MaxIterations (int iterations) {
      ((RemoveMisclassified)Impl).setMaxIterations(iterations);
      return this;
    }

    /// <summary>
    /// Whether or not to invert the selection. If true, correctly classified
    /// instances will be discarded.
    /// </summary>    
    public RemoveMisclassified<T> Invert (bool invert) {
      ((RemoveMisclassified)Impl).setInvert(invert);
      return this;
    }

        
        
  }
}