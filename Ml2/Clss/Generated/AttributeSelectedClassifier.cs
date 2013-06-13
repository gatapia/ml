using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Dimensionality of training and test data is reduced by attribute
  /// selection before being passed on to a classifier.
  /// </summary>
  public class AttributeSelectedClassifier<T> : BaseClassifier<T, AttributeSelectedClassifier>
  {
    public AttributeSelectedClassifier(Runtime<T> rt) : base(rt, new AttributeSelectedClassifier()) {}

    /// <summary>
    /// Set the attribute evaluator to use. This evaluator is used during the
    /// attribute selection phase before the classifier is invoked.
    /// </summary>    
    public AttributeSelectedClassifier<T> Evaluator (AttrSel.Evals.BaseAttributeSelectionEvaluator<T, weka.attributeSelection.ASEvaluation> evaluator) {
      ((AttributeSelectedClassifier)Impl).setEvaluator(evaluator.Impl);
      return this;
    }

    /// <summary>
    /// Set the search method. This search method is used during the attribute
    /// selection phase before the classifier is invoked.
    /// </summary>    
    public AttributeSelectedClassifier<T> Search (AttrSel.Algs.BaseAttributeSelectionAlgorithm<T, weka.attributeSelection.ASSearch> search) {
      ((AttributeSelectedClassifier)Impl).setSearch(search.Impl);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public AttributeSelectedClassifier<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((AttributeSelectedClassifier)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AttributeSelectedClassifier<T> Debug (bool debug) {
      ((AttributeSelectedClassifier)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}