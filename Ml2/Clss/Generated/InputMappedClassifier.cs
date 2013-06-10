using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// Wrapper classifier that addresses incompatible training and test data by
  /// building a mapping between the training data that a classifier has been
  /// built with and the incoming test instances' structure. Model attributes that
  /// are not found in the incoming instances receive missing values, so do
  /// incoming nominal attribute values that the classifier has not seen before. A new
  /// classifier can be trained or an existing one loaded from a file.
  /// </summary>
  public class InputMappedClassifier<T> : BaseClassifier<T>
  {
    public InputMappedClassifier(Runtime<T> rt) : base(rt, new InputMappedClassifier()) {}

    /// <summary>
    /// Ignore case when matching attribute names and nomina values.
    /// </summary>    
    public InputMappedClassifier<T> IgnoreCaseForNames (bool value) {
      ((InputMappedClassifier)impl).setIgnoreCaseForNames(value);
      return this;
    }

    /// <summary>
    /// Don't output a report of model-to-input mappings.
    /// </summary>    
    public InputMappedClassifier<T> SuppressMappingReport (bool value) {
      ((InputMappedClassifier)impl).setSuppressMappingReport(value);
      return this;
    }

    /// <summary>
    /// Trim white space from each end of attribute names and nominal values
    /// before matching.
    /// </summary>    
    public InputMappedClassifier<T> Trim (bool value) {
      ((InputMappedClassifier)impl).setTrim(value);
      return this;
    }

    /// <summary>
    /// Set the path from which to load a model. Loading occurs when the first
    /// test instance is received. Environment variables can be used in the supplied
    /// path.
    /// </summary>    
    public InputMappedClassifier<T> ModelPath (string value) {
      ((InputMappedClassifier)impl).setModelPath(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public InputMappedClassifier<T> Debug (bool value) {
      ((InputMappedClassifier)impl).setDebug(value);
      return this;
    }

        
  }
}