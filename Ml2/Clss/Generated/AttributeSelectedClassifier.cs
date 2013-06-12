using weka.core;
using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// Dimensionality of training and test data is reduced by attribute
  /// selection before being passed on to a classifier.
  /// </summary>
  public class AttributeSelectedClassifier<T> : BaseClassifier<T>
  {
    public AttributeSelectedClassifier(Runtime<T> rt) : base(rt, new AttributeSelectedClassifier()) {}

    /// <summary>
    /// Set the attribute evaluator to use. This evaluator is used during the
    /// attribute selection phase before the classifier is invoked.
    /// </summary>    
    public AttributeSelectedClassifier<T> Evaluator (AttrSel.Evals.BaseAttributeSelectionEvaluator<T> value) {
      ((AttributeSelectedClassifier)Impl).setEvaluator(value.Impl);
      return this;
    }

    /// <summary>
    /// Set the search method. This search method is used during the attribute
    /// selection phase before the classifier is invoked.
    /// </summary>    
    public AttributeSelectedClassifier<T> Search (AttrSel.Algs.BaseAttributeSelectionAlgorithm<T> value) {
      ((AttributeSelectedClassifier)Impl).setSearch(value.Impl);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public AttributeSelectedClassifier<T> Classifier (Clss.BaseClassifier<T> value) {
      ((AttributeSelectedClassifier)Impl).setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AttributeSelectedClassifier<T> Debug (bool value) {
      ((AttributeSelectedClassifier)Impl).setDebug(value);
      return this;
    }

        
        
  }
}