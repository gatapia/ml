using weka.core;
using weka.classifiers.misc;

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
      ((InputMappedClassifier)Impl).setIgnoreCaseForNames(value);
      return this;
    }

    /// <summary>
    /// Don't output a report of model-to-input mappings.
    /// </summary>    
    public InputMappedClassifier<T> SuppressMappingReport (bool value) {
      ((InputMappedClassifier)Impl).setSuppressMappingReport(value);
      return this;
    }

    /// <summary>
    /// Trim white space from each end of attribute names and nominal values
    /// before matching.
    /// </summary>    
    public InputMappedClassifier<T> Trim (bool value) {
      ((InputMappedClassifier)Impl).setTrim(value);
      return this;
    }

    /// <summary>
    /// Set the path from which to load a model. Loading occurs when the first
    /// test instance is received. Environment variables can be used in the supplied
    /// path.
    /// </summary>    
    public InputMappedClassifier<T> ModelPath (string value) {
      ((InputMappedClassifier)Impl).setModelPath(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InputMappedClassifier<T> TestStructure (Runtime<T> value) {
      ((InputMappedClassifier)Impl).setTestStructure(value.Instances);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InputMappedClassifier<T> ModelHeader (Runtime<T> value) {
      ((InputMappedClassifier)Impl).setModelHeader(value.Instances);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public InputMappedClassifier<T> Classifier (Clss.BaseClassifier<T> value) {
      ((InputMappedClassifier)Impl).setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public InputMappedClassifier<T> Debug (bool value) {
      ((InputMappedClassifier)Impl).setDebug(value);
      return this;
    }

        
        
  }
}