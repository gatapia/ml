using weka.core;
using weka.classifiers.meta;

namespace Ml2.Clss
{
  /// <summary>
  /// Class for running an arbitrary classifier on data that has been passed
  /// through an arbitrary filter. Like the classifier, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their structure.
  /// </summary>
  public class FilteredClassifier<T> : BaseClassifier<T>
  {
    public FilteredClassifier(Runtime<T> rt) : base(rt, new FilteredClassifier()) {}

    /// <summary>
    /// The filter to be used.
    /// </summary>    
    public FilteredClassifier<T> Filter (Fltr.BaseFilter<T> value) {
      ((FilteredClassifier)Impl).setFilter(value.Impl);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public FilteredClassifier<T> Classifier (Clss.BaseClassifier<T> value) {
      ((FilteredClassifier)Impl).setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public FilteredClassifier<T> Debug (bool value) {
      ((FilteredClassifier)Impl).setDebug(value);
      return this;
    }

        
        
  }
}