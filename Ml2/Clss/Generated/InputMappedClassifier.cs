using System.Linq;
using weka.classifiers.misc;

// ReSharper disable once CheckNamespace
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
  public class InputMappedClassifier<T> : BaseClassifier<T, InputMappedClassifier>
  {
    public InputMappedClassifier(Runtime<T> rt) : base(rt, new InputMappedClassifier()) {}

    /// <summary>
    /// Ignore case when matching attribute names and nomina values.
    /// </summary>    
    public InputMappedClassifier<T> IgnoreCaseForNames (bool ignore) {
      ((InputMappedClassifier)Impl).setIgnoreCaseForNames(ignore);
      return this;
    }

    /// <summary>
    /// Don't output a report of model-to-input mappings.
    /// </summary>    
    public InputMappedClassifier<T> SuppressMappingReport (bool suppress) {
      ((InputMappedClassifier)Impl).setSuppressMappingReport(suppress);
      return this;
    }

    /// <summary>
    /// Trim white space from each end of attribute names and nominal values
    /// before matching.
    /// </summary>    
    public InputMappedClassifier<T> Trim (bool trim) {
      ((InputMappedClassifier)Impl).setTrim(trim);
      return this;
    }

    /// <summary>
    /// Set the path from which to load a model. Loading occurs when the first
    /// test instance is received. Environment variables can be used in the supplied
    /// path.
    /// </summary>    
    public InputMappedClassifier<T> ModelPath (string modelPath) {
      ((InputMappedClassifier)Impl).setModelPath(modelPath);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InputMappedClassifier<T> TestStructure (Runtime<T> testStructure) {
      ((InputMappedClassifier)Impl).setTestStructure(testStructure.Instances);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InputMappedClassifier<T> ModelHeader (Runtime<T> modelHeader) {
      ((InputMappedClassifier)Impl).setModelHeader(modelHeader.Instances);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public InputMappedClassifier<T> Classifier (Clss.BaseClassifier<T, weka.classifiers.Classifier> newClassifier) {
      ((InputMappedClassifier)Impl).setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public InputMappedClassifier<T> Debug (bool debug) {
      ((InputMappedClassifier)Impl).setDebug(debug);
      return this;
    }

        
        
  }
}