using weka.classifiers.functions;

namespace Ml2.Clss
{
  /// <summary>
  /// A Classifier that uses backpropagation to classify instances. This
  /// network can be built by hand, created by an algorithm or both. The network can
  /// also be monitored and modified during training time. The nodes in this
  /// network are all sigmoid (except for when the class is numeric in which case the
  /// the output nodes become unthresholded linear units).
  /// </summary>
  public class MultilayerPerceptron<T> : BaseClassifier<T>
  {
    public MultilayerPerceptron(Runtime<T> rt) : base(rt, new MultilayerPerceptron()) {}

    /// <summary>
    /// The amount the weights are updated.
    /// </summary>    
    public MultilayerPerceptron<T> LearningRate (double value) {
      ((MultilayerPerceptron)impl).setLearningRate(value);
      return this;
    }

    /// <summary>
    /// Momentum applied to the weights during updating.
    /// </summary>    
    public MultilayerPerceptron<T> Momentum (double value) {
      ((MultilayerPerceptron)impl).setMomentum(value);
      return this;
    }

    /// <summary>
    /// Adds and connects up hidden layers in the network.
    /// </summary>    
    public MultilayerPerceptron<T> AutoBuild (bool value) {
      ((MultilayerPerceptron)impl).setAutoBuild(value);
      return this;
    }

    /// <summary>
    /// This will allow the network to reset with a lower learning rate. If the
    /// network diverges from the answer this will automatically reset the network
    /// with a lower learning rate and begin training again. This option is only
    /// available if the gui is not set. Note that if the network diverges but isn't
    /// allowed to reset it will fail the training process and return an error
    /// message.
    /// </summary>    
    public MultilayerPerceptron<T> Reset (bool value) {
      ((MultilayerPerceptron)impl).setReset(value);
      return this;
    }

    /// <summary>
    /// The number of epochs to train through. If the validation set is non-zero
    /// then it can terminate the network early
    /// </summary>    
    public MultilayerPerceptron<T> TrainingTime (int value) {
      ((MultilayerPerceptron)impl).setTrainingTime(value);
      return this;
    }

    /// <summary>
    /// The percentage size of the validation set.(The training will continue
    /// until it is observed that the error on the validation set has been
    /// consistently getting worse, or if the training time is reached). If This is set to
    /// zero no validation set will be used and instead the network will train for the
    /// specified number of epochs.
    /// </summary>    
    public MultilayerPerceptron<T> ValidationSetSize (int value) {
      ((MultilayerPerceptron)impl).setValidationSetSize(value);
      return this;
    }

    /// <summary>
    /// Seed used to initialise the random number generator.Random numbers are
    /// used for setting the initial weights of the connections betweem nodes, and
    /// also for shuffling the training data.
    /// </summary>    
    public MultilayerPerceptron<T> Seed (int value) {
      ((MultilayerPerceptron)impl).setSeed(value);
      return this;
    }

    /// <summary>
    /// Used to terminate validation testing.The value here dictates how many
    /// times in a row the validation set error can get worse before training is
    /// terminated.
    /// </summary>    
    public MultilayerPerceptron<T> ValidationThreshold (int value) {
      ((MultilayerPerceptron)impl).setValidationThreshold(value);
      return this;
    }

    /// <summary>
    /// This defines the hidden layers of the neural network. This is a list of
    /// positive whole numbers. 1 for each hidden layer. Comma seperated. To have no
    /// hidden layers put a single 0 here. This will only be used if autobuild is
    /// set. There are also wildcard values 'a' = (attribs + classes) / 2, 'i' =
    /// attribs, 'o' = classes , 't' = attribs + classes.
    /// </summary>    
    public MultilayerPerceptron<T> HiddenLayers (string value) {
      ((MultilayerPerceptron)impl).setHiddenLayers(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MultilayerPerceptron<T> GUI (bool value) {
      ((MultilayerPerceptron)impl).setGUI(value);
      return this;
    }

    /// <summary>
    /// This will preprocess the instances with the filter. This could help
    /// improve performance if there are nominal attributes in the data.
    /// </summary>    
    public MultilayerPerceptron<T> NominalToBinaryFilter (bool value) {
      ((MultilayerPerceptron)impl).setNominalToBinaryFilter(value);
      return this;
    }

    /// <summary>
    /// This will normalize the class if it's numeric. This could help improve
    /// performance of the network, It normalizes the class to be between -1 and 1.
    /// Note that this is only internally, the output will be scaled back to the
    /// original range.
    /// </summary>    
    public MultilayerPerceptron<T> NormalizeNumericClass (bool value) {
      ((MultilayerPerceptron)impl).setNormalizeNumericClass(value);
      return this;
    }

    /// <summary>
    /// This will normalize the attributes. This could help improve performance
    /// of the network. This is not reliant on the class being numeric. This will
    /// also normalize nominal attributes as well (after they have been run through
    /// the nominal to binary filter if that is in use) so that the nominal values
    /// are between -1 and 1
    /// </summary>    
    public MultilayerPerceptron<T> NormalizeAttributes (bool value) {
      ((MultilayerPerceptron)impl).setNormalizeAttributes(value);
      return this;
    }

    /// <summary>
    /// This will cause the learning rate to decrease. This will divide the
    /// starting learning rate by the epoch number, to determine what the current
    /// learning rate should be. This may help to stop the network from diverging from
    /// the target output, as well as improve general performance. Note that the
    /// decaying learning rate will not be shown in the gui, only the original learning
    /// rate. If the learning rate is changed in the gui, this is treated as the
    /// starting learning rate.
    /// </summary>    
    public MultilayerPerceptron<T> Decay (bool value) {
      ((MultilayerPerceptron)impl).setDecay(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultilayerPerceptron<T> Debug (bool value) {
      ((MultilayerPerceptron)impl).setDebug(value);
      return this;
    }

        
  }
}