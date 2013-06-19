using System;
using System.Linq;
using System.IO;
using System.Media;
using Ml2.Clss;
using Ml2.Tests.Kaggle.AmazonEmployee.Data;
using NUnit.Framework;
using weka.classifiers;
using weka.core;

namespace Ml2.Tests.Kaggle.AmazonEmployee
{    
  [TestFixture] public class ClassifierExperimentsWithSmote
  {    
    [Test] public void prepare_training_data() { LoadTrainingRuntime(); }

    /// <summary>
    /// Without smote - With Depth 3 (from 2): 91.1462 % - Predictions: 22310 rejections and 36611 approvals
    ///
    /// 
    /// On Kaggle: 66.10822 %
    /// </summary>
    [Test] public void build_random_forest_classifier()
    {
      evaluate_classifier(c => c.Trees.RandomForest().          
          NumExecutionSlots(2).
          MaxDepth(2).
          NumFeatures(2).
          NumTrees(25),
        flushModelToDisk: false);
    }

    /// <summary>
    /// Without smote - Max Its: 100: 67.9315 %
    /// With smote - Too slow...
    /// </summary>
    [Test] public void build_logistic_regression_classifier() {
      evaluate_classifier(c => c.Functions.Logistic().MaxIts(50));
    }  

    // Too slow
    [Test] public void build_svm_classifier() { 
      evaluate_classifier(c => c.Functions.SMO()); 
    }

    /// <summary>
    /// Without smote - 94.5718 % - Predictions: has 8782 rejections and 50139 approvals
    /// With smote - 80.5131 % - Predictions: 26744 rejections and 32177 approvals.
    /// </summary>
    [Test] public void build_j48_classifier()
    {
      evaluate_classifier(c => c.Trees.J48());
    }

    /// <summary>
    /// Without smote - k=3 - 72.7273 % Predictions: 35692 rejections and 23229 approvals
    /// With smote - k=2 - 84.9411 % Predictions: 27991 rejections and 30930 approvals.
    /// </summary>
    [Test] public void build_ibk_classifier() {
      evaluate_classifier(c => c.Lazy.IBk().KNN(2));
    }

    /// <summary>        
    /// Without smote - 93.8076 % - Predictions: 12278 rejections and 46643 approvals
    /// With smote - 84.9323 % - Predictions: 13746 rejections and 45175 approvals
    /// Seems to suggest that without smote it was highly biased (overfitted).
    /// </summary>
    [Test] public void build_nb_classifier()
    {      
      evaluate_classifier(c => c.Bayes.NaiveBayes().
          UseKernelEstimator(true).
          UseSupervisedDiscretization(true));
    }    

    private Runtime<AmazonTrainDataRow> LoadTrainingRuntime() {          
      var file = "training_runtime.arff";
      
      if (File.Exists(file)) {        
        var rtcached = new Runtime<AmazonTrainDataRow>(0, file);
        Console.WriteLine("Using cached trainingset runtime. Total Instances: " + 
            rtcached.Instances.numInstances());
        return rtcached;
      }

      var start = DateTime.Now;
      var rt = new Runtime<AmazonTrainDataRow>(0, @"resources\kaggle\amazon-employee\train.csv");
      rt = rt.Filters.SupervisedInstance.SpreadSubsample().
          DistributionSpread(3).
          RunFilter();
      
      rt = rt.Filters.SupervisedInstance.SMOTE().
          Percentage(200).
          ClassValue(((int) EAction.Rejected).ToString()).
          RunFilter();
      
      rt.SaveToArffFile(file);

      // Debug
      var en = rt.Instances.enumerateInstances();
      var rejections = 0;
      var approvals = 0;
      while (en.hasMoreElements()) {
        var instance = (Instance) en.nextElement();
        if (instance.classValue() == 1.0) approvals ++;
        else rejections ++;
      }      
      Console.WriteLine("Created runtime took: {0}ms. Rejections[{1}] Approvals[{2}]", 
          DateTime.Now.Subtract(start).TotalMilliseconds, rejections, approvals);
      return rt;
    }

    private void evaluate_classifier(
      Func<Classifiers<AmazonTrainDataRow>, IBaseClassifier<AmazonTrainDataRow, Classifier>> builder,
      bool runPredictions = true,
      bool flushModelToDisk = true) {
      var training = LoadTrainingRuntime();      
      var classifier = builder(training.Classifiers);

      if (flushModelToDisk) {
        var file = GetType().Name + "_" + classifier.Impl.GetType().Name + ".model";
        classifier.FlushToFile(file);
      }
      classifier.EvaluateWithCrossValidation(); 

      if (runPredictions) run_predictions(classifier.Impl);
      
      SystemSounds.Beep.Play(); // I'm finnished
    }

    private void run_predictions(params Classifier[] classifiers)
    {
      var testset = new Runtime<AmazonTrainDataRow>(0, @"resources\kaggle\amazon-employee\test.csv");
      Func<double, Instance, int, string> formatter = 
          (outcome, obs, idx) => (idx + 1).ToString() + ',' + outcome;
      
      var lines = testset.GeneratePredictions(formatter, "id,ACTION", classifiers);
      
      File.WriteAllLines(GetType().Name + "_" + classifiers.GetType().Name + "_predictions.csv", lines);

      var rejections = lines.Count(r => r.EndsWith(",0"));
      var approvals = lines.Count(r => r.EndsWith(",1"));
      Console.WriteLine("Predictions: " + rejections + " rejections and " + approvals + " approvals.");
    }
  }
}