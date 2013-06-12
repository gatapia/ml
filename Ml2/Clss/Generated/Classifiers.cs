// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  public class Classifiers<T>
  {
    private readonly Runtime<T> rt;    
    public Classifiers(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures. Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and facilities
    /// common to Bayes Network learning algorithms like K2 and B. For more
    /// information see: http://www.cs.waikato.ac.nz/~remco/weka.pdf
    /// </summary>
    public BayesNet<T> BayesNet() { return new BayesNet<T>(rt); }

    /// <summary>
    /// Class for a Naive Bayes classifier using estimator classes. Numeric
    /// estimator precision values are chosen based on analysis of the training data.
    /// For this reason, the classifier is not an UpdateableClassifier (which in
    /// typical usage are initialized with zero training instances) -- if you need the
    /// UpdateableClassifier functionality, use the NaiveBayesUpdateable
    /// classifier. The NaiveBayesUpdateable classifier will use a default precision of 0.1
    /// for numeric attributes when buildClassifier is called with zero training
    /// instances. For more information on Naive Bayes classifiers, see George H.
    /// John, Pat Langley: Estimating Continuous Distributions in Bayesian Classifiers.
    /// In: Eleventh Conference on Uncertainty in Artificial Intelligence, San
    /// Mateo, 338-345, 1995.
    /// </summary>
    public NaiveBayes<T> NaiveBayes() { return new NaiveBayes<T>(rt); }

    /// <summary>
    /// Class for building and using a multinomial Naive Bayes classifier. For
    /// more information see, Andrew Mccallum, Kamal Nigam: A Comparison of Event
    /// Models for Naive Bayes Text Classification. In: AAAI-98 Workshop on 'Learning
    /// for Text Categorization', 1998. The core equation for this classifier:
    /// P[Ci|D] = (P[D|Ci] x P[Ci]) / P[D] (Bayes rule) where Ci is class i and D is a
    /// document.
    /// </summary>
    public NaiveBayesMultinomial<T> NaiveBayesMultinomial() { return new NaiveBayesMultinomial<T>(rt); }

    /// <summary>
    /// Multinomial naive bayes for text data. Operates directly (and only) on
    /// String attributes. Other types of input attributes are accepted but ignored
    /// during training and classification
    /// </summary>
    public NaiveBayesMultinomialText<T> NaiveBayesMultinomialText() { return new NaiveBayesMultinomialText<T>(rt); }

    /// <summary>
    /// Class for building and using a multinomial Naive Bayes classifier. For
    /// more information see, Andrew Mccallum, Kamal Nigam: A Comparison of Event
    /// Models for Naive Bayes Text Classification. In: AAAI-98 Workshop on 'Learning
    /// for Text Categorization', 1998. The core equation for this classifier:
    /// P[Ci|D] = (P[D|Ci] x P[Ci]) / P[D] (Bayes rule) where Ci is class i and D is a
    /// document. Incremental version of the algorithm.
    /// </summary>
    public NaiveBayesMultinomialUpdateable<T> NaiveBayesMultinomialUpdateable() { return new NaiveBayesMultinomialUpdateable<T>(rt); }

    /// <summary>
    /// Class for a Naive Bayes classifier using estimator classes. This is the
    /// updateable version of NaiveBayes. This classifier will use a default
    /// precision of 0.1 for numeric attributes when buildClassifier is called with zero
    /// training instances. For more information on Naive Bayes classifiers, see
    /// George H. John, Pat Langley: Estimating Continuous Distributions in Bayesian
    /// Classifiers. In: Eleventh Conference on Uncertainty in Artificial
    /// Intelligence, San Mateo, 338-345, 1995.
    /// </summary>
    public NaiveBayesUpdateable<T> NaiveBayesUpdateable() { return new NaiveBayesUpdateable<T>(rt); }

    /// <summary>
    /// Builds a description of a Bayes Net classifier stored in XML BIF 0.3
    /// format. For more details on XML BIF see: Fabio Cozman, Marek Druzdzel, Daniel
    /// Garcia (1998). XML BIF version 0.3. URL
    /// http://www-2.cs.cmu.edu/~fgcozman/Research/InterchangeFormat/.
    /// </summary>
    public BIFReader<T> BIFReader() { return new BIFReader<T>(rt); }

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures. Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and facilities
    /// common to Bayes Network learning algorithms like K2 and B. For more
    /// information see: http://www.cs.waikato.ac.nz/~remco/weka.pdf
    /// </summary>
    public BayesNetGenerator<T> BayesNetGenerator() { return new BayesNetGenerator<T>(rt); }

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures. Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and facilities
    /// common to Bayes Network learning algorithms like K2 and B. For more
    /// information see: http://www.cs.waikato.ac.nz/~remco/weka.pdf
    /// </summary>
    public EditableBayesNet<T> EditableBayesNet() { return new EditableBayesNet<T>(rt); }

    /// <summary>
    /// Implements Gaussian processes for regression without
    /// hyperparameter-tuning. To make choosing an appropriate noise level easier, this implementation
    /// applies normalization/standardization to the target attribute as well as
    /// the other attributes (if normalization/standardizaton is turned on). Missing
    /// values are replaced by the global mean/mode. Nominal attributes are
    /// converted to binary ones. Note that kernel caching is turned off if the kernel
    /// used implements CachedKernel.
    /// </summary>
    public GaussianProcesses<T> GaussianProcesses() { return new GaussianProcesses<T>(rt); }

    /// <summary>
    /// Class for using linear regression for prediction. Uses the Akaike
    /// criterion for model selection, and is able to deal with weighted instances.
    /// </summary>
    public LinearRegression<T> LinearRegression() { return new LinearRegression<T>(rt); }

    /// <summary>
    /// Class for building and using a multinomial logistic regression model with
    /// a ridge estimator. There are some modifications, however, compared to the
    /// paper of leCessie and van Houwelingen(1992): If there are k classes for n
    /// instances with m attributes, the parameter matrix B to be calculated will be
    /// an m*(k-1) matrix. The probability for class j with the exception of the
    /// last class is Pj(Xi) = exp(XiBj)/((sum[j=1..(k-1)]exp(Xi*Bj))+1) The last
    /// class has probability 1-(sum[j=1..(k-1)]Pj(Xi)) 	=
    /// 1/((sum[j=1..(k-1)]exp(Xi*Bj))+1) The (negative) multinomial log-likelihood is thus: L =
    /// -sum[i=1..n]{ 	sum[j=1..(k-1)](Yij * ln(Pj(Xi))) 	+(1 - (sum[j=1..(k-1)]Yij)) 	* ln(1 -
    /// sum[j=1..(k-1)]Pj(Xi)) 	} + ridge * (B^2) In order to find the matrix B
    /// for which L is minimised, a Quasi-Newton Method is used to search for the
    /// optimized values of the m*(k-1) variables. Note that before we use the
    /// optimization procedure, we 'squeeze' the matrix B into a m*(k-1) vector. For
    /// details of the optimization procedure, please check weka.core.Optimization
    /// class. Although original Logistic Regression does not deal with instance
    /// weights, we modify the algorithm a little bit to handle the instance weights. For
    /// more information see: le Cessie, S., van Houwelingen, J.C. (1992). Ridge
    /// Estimators in Logistic Regression. Applied Statistics. 41(1):191-201. Note:
    /// Missing values are replaced using a ReplaceMissingValuesFilter, and nominal
    /// attributes are transformed into numeric attributes using a
    /// NominalToBinaryFilter.
    /// </summary>
    public Logistic<T> Logistic() { return new Logistic<T>(rt); }

    /// <summary>
    /// A Classifier that uses backpropagation to classify instances. This
    /// network can be built by hand, created by an algorithm or both. The network can
    /// also be monitored and modified during training time. The nodes in this
    /// network are all sigmoid (except for when the class is numeric in which case the
    /// the output nodes become unthresholded linear units).
    /// </summary>
    public MultilayerPerceptron<T> MultilayerPerceptron() { return new MultilayerPerceptron<T>(rt); }

    /// <summary>
    /// Implements stochastic gradient descent for learning various linear models
    /// (binary class SVM, binary class logistic regression, squared loss, Huber
    /// loss and epsilon-insensitive loss linear regression). Globally replaces all
    /// missing values and transforms nominal attributes into binary ones. It also
    /// normalizes all attributes, so the coefficients in the output are based on
    /// the normalized data. For numeric class attributes, the squared, Huber or
    /// epsilon-insensitve loss function must be used. Epsilon-insensitive and Huber
    /// loss may require a much higher learning rate.
    /// </summary>
    public SGD<T> SGD() { return new SGD<T>(rt); }

    /// <summary>
    /// Implements stochastic gradient descent for learning a linear binary class
    /// SVM or binary class logistic regression on text data. Operates directly
    /// (and only) on String attributes. Other types of input attributes are accepted
    /// but ignored during training and classification.
    /// </summary>
    public SGDText<T> SGDText() { return new SGDText<T>(rt); }

    /// <summary>
    /// Implements John Platt's sequential minimal optimization algorithm for
    /// training a support vector classifier. This implementation globally replaces
    /// all missing values and transforms nominal attributes into binary ones. It
    /// also normalizes all attributes by default. (In that case the coefficients in
    /// the output are based on the normalized data, not the original data --- this
    /// is important for interpreting the classifier.) Multi-class problems are
    /// solved using pairwise classification (1-vs-1 and if logistic models are built
    /// pairwise coupling according to Hastie and Tibshirani, 1998). To obtain
    /// proper probability estimates, use the option that fits logistic regression
    /// models to the outputs of the support vector machine. In the multi-class case
    /// the predicted probabilities are coupled using Hastie and Tibshirani's
    /// pairwise coupling method. Note: for improved speed normalization should be turned
    /// off when operating on SparseInstances. For more information on the SMO
    /// algorithm, see J. Platt: Fast Training of Support Vector Machines using
    /// Sequential Minimal Optimization. In B. Schoelkopf and C. Burges and A. Smola,
    /// editors, Advances in Kernel Methods - Support Vector Learning, 1998. S.S.
    /// Keerthi, S.K. Shevade, C. Bhattacharyya, K.R.K. Murthy (2001). Improvements to
    /// Platt's SMO Algorithm for SVM Classifier Design. Neural Computation.
    /// 13(3):637-649. Trevor Hastie, Robert Tibshirani: Classification by Pairwise
    /// Coupling. In: Advances in Neural Information Processing Systems, 1998.
    /// </summary>
    public SMO<T> SMO() { return new SMO<T>(rt); }

    /// <summary>
    /// SMOreg implements the support vector machine for regression. The
    /// parameters can be learned using various algorithms. The algorithm is selected by
    /// setting the RegOptimizer. The most popular algorithm (RegSMOImproved) is due
    /// to Shevade, Keerthi et al and this is the default RegOptimizer. For more
    /// information see: S.K. Shevade, S.S. Keerthi, C. Bhattacharyya, K.R.K. Murthy:
    /// Improvements to the SMO Algorithm for SVM Regression. In: IEEE
    /// Transactions on Neural Networks, 1999. A.J. Smola, B. Schoelkopf (1998). A tutorial on
    /// support vector regression.
    /// </summary>
    public SMOreg<T> SMOreg() { return new SMOreg<T>(rt); }

    /// <summary>
    /// Learns a simple linear regression model. Picks the attribute that results
    /// in the lowest squared error. Missing values are not allowed. Can only deal
    /// with numeric attributes.
    /// </summary>
    public SimpleLinearRegression<T> SimpleLinearRegression() { return new SimpleLinearRegression<T>(rt); }

    /// <summary>
    /// Classifier for building linear logistic regression models. LogitBoost
    /// with simple regression functions as base learners is used for fitting the
    /// logistic models. The optimal number of LogitBoost iterations to perform is
    /// cross-validated, which leads to automatic attribute selection. For more
    /// information see: Niels Landwehr, Mark Hall, Eibe Frank (2005). Logistic Model
    /// Trees. Marc Sumner, Eibe Frank, Mark Hall: Speeding up Logistic Model Tree
    /// Induction. In: 9th European Conference on Principles and Practice of Knowledge
    /// Discovery in Databases, 675-683, 2005.
    /// </summary>
    public SimpleLogistic<T> SimpleLogistic() { return new SimpleLogistic<T>(rt); }

    /// <summary>
    /// Implementation of the voted perceptron algorithm by Freund and Schapire.
    /// Globally replaces all missing values, and transforms nominal attributes
    /// into binary ones. For more information, see: Y. Freund, R. E. Schapire: Large
    /// margin classification using the perceptron algorithm. In: 11th Annual
    /// Conference on Computational Learning Theory, New York, NY, 209-217, 1998.
    /// </summary>
    public VotedPerceptron<T> VotedPerceptron() { return new VotedPerceptron<T>(rt); }

    /// <summary>
    /// K-nearest neighbours classifier. Can select appropriate value of K based
    /// on cross-validation. Can also do distance weighting. For more information,
    /// see D. Aha, D. Kibler (1991). Instance-based learning algorithms. Machine
    /// Learning. 6:37-66.
    /// </summary>
    public IBk<T> IBk() { return new IBk<T>(rt); }

    /// <summary>
    /// K* is an instance-based classifier, that is the class of a test instance
    /// is based upon the class of those training instances similar to it, as
    /// determined by some similarity function. It differs from other instance-based
    /// learners in that it uses an entropy-based distance function. For more
    /// information on K*, see John G. Cleary, Leonard E. Trigg: K*: An Instance-based
    /// Learner Using an Entropic Distance Measure. In: 12th International Conference
    /// on Machine Learning, 108-114, 1995.
    /// </summary>
    public KStar<T> KStar() { return new KStar<T>(rt); }

    /// <summary>
    /// Locally weighted learning. Uses an instance-based algorithm to assign
    /// instance weights which are then used by a specified WeightedInstancesHandler.
    /// Can do classification (e.g. using naive Bayes) or regression (e.g. using
    /// linear regression). For more info, see Eibe Frank, Mark Hall, Bernhard
    /// Pfahringer: Locally Weighted Naive Bayes. In: 19th Conference in Uncertainty in
    /// Artificial Intelligence, 249-256, 2003. C. Atkeson, A. Moore, S. Schaal
    /// (1996). Locally weighted learning. AI Review..
    /// </summary>
    public LWL<T> LWL() { return new LWL<T>(rt); }

    /// <summary>
    /// Class for boosting a nominal class classifier using the Adaboost M1
    /// method. Only nominal class problems can be tackled. Often dramatically improves
    /// performance, but sometimes overfits. For more information, see Yoav Freund,
    /// Robert E. Schapire: Experiments with a new boosting algorithm. In:
    /// Thirteenth International Conference on Machine Learning, San Francisco, 148-156,
    /// 1996.
    /// </summary>
    public AdaBoostM1<T> AdaBoostM1() { return new AdaBoostM1<T>(rt); }

    /// <summary>
    /// Meta classifier that enhances the performance of a regression base
    /// classifier. Each iteration fits a model to the residuals left by the classifier
    /// on the previous iteration. Prediction is accomplished by adding the
    /// predictions of each classifier. Reducing the shrinkage (learning rate) parameter
    /// helps prevent overfitting and has a smoothing effect but increases the
    /// learning time. For more information see: J.H. Friedman (1999). Stochastic
    /// Gradient Boosting.
    /// </summary>
    public AdditiveRegression<T> AdditiveRegression() { return new AdditiveRegression<T>(rt); }

    /// <summary>
    /// Dimensionality of training and test data is reduced by attribute
    /// selection before being passed on to a classifier.
    /// </summary>
    public AttributeSelectedClassifier<T> AttributeSelectedClassifier() { return new AttributeSelectedClassifier<T>(rt); }

    /// <summary>
    /// Class for bagging a classifier to reduce variance. Can do classification
    /// and regression depending on the base learner. For more information, see Leo
    /// Breiman (1996). Bagging predictors. Machine Learning. 24(2):123-140.
    /// </summary>
    public Bagging<T> Bagging() { return new Bagging<T>(rt); }

    /// <summary>
    /// Class for performing parameter selection by cross-validation for any
    /// classifier. For more information, see: R. Kohavi (1995). Wrappers for
    /// Performance Enhancement and Oblivious Decision Graphs. Department of Computer
    /// Science, Stanford University.
    /// </summary>
    public CVParameterSelection<T> CVParameterSelection() { return new CVParameterSelection<T>(rt); }

    /// <summary>
    /// Class for doing classification using regression methods. Class is
    /// binarized and one regression model is built for each class value. For more
    /// information, see, for example E. Frank, Y. Wang, S. Inglis, G. Holmes, I.H. Witten
    /// (1998). Using model trees for classification. Machine Learning.
    /// 32(1):63-76.
    /// </summary>
    public ClassificationViaRegression<T> ClassificationViaRegression() { return new ClassificationViaRegression<T>(rt); }

    /// <summary>
    /// A metaclassifier that makes its base classifier cost-sensitive. Two
    /// methods can be used to introduce cost-sensitivity: reweighting training
    /// instances according to the total cost assigned to each class; or predicting the
    /// class with minimum expected misclassification cost (rather than the most
    /// likely class). Performance can often be improved by using a Bagged classifier to
    /// improve the probability estimates of the base classifier.
    /// </summary>
    public CostSensitiveClassifier<T> CostSensitiveClassifier() { return new CostSensitiveClassifier<T>(rt); }

    /// <summary>
    /// Class for running an arbitrary classifier on data that has been passed
    /// through an arbitrary filter. Like the classifier, the structure of the filter
    /// is based exclusively on the training data and test instances will be
    /// processed by the filter without changing their structure.
    /// </summary>
    public FilteredClassifier<T> FilteredClassifier() { return new FilteredClassifier<T>(rt); }

    /// <summary>
    /// Class for performing additive logistic regression. This class performs
    /// classification using a regression scheme as the base learner, and can handle
    /// multi-class problems. For more information, see J. Friedman, T. Hastie, R.
    /// Tibshirani (1998). Additive Logistic Regression: a Statistical View of
    /// Boosting. Stanford University. Can do efficient internal cross-validation to
    /// determine appropriate number of iterations.
    /// </summary>
    public LogitBoost<T> LogitBoost() { return new LogitBoost<T>(rt); }

    /// <summary>
    /// A metaclassifier for handling multi-class datasets with 2-class
    /// classifiers. This classifier is also capable of applying error correcting output
    /// codes for increased accuracy.
    /// </summary>
    public MultiClassClassifier<T> MultiClassClassifier() { return new MultiClassClassifier<T>(rt); }

    /// <summary>
    /// A metaclassifier for handling multi-class datasets with 2-class
    /// classifiers. This classifier is also capable of applying error correcting output
    /// codes for increased accuracy. The base classifier must be an updateable
    /// classifier
    /// </summary>
    public MultiClassClassifierUpdateable<T> MultiClassClassifierUpdateable() { return new MultiClassClassifierUpdateable<T>(rt); }

    /// <summary>
    /// Class for selecting a classifier from among several using cross
    /// validation on the training data or the performance on the training data. Performance
    /// is measured based on percent correct (classification) or mean-squared
    /// error (regression).
    /// </summary>
    public MultiScheme<T> MultiScheme() { return new MultiScheme<T>(rt); }

    /// <summary>
    /// Class for building an ensemble of randomizable base classifiers. Each
    /// base classifiers is built using a different random number seed (but based one
    /// the same data). The final prediction is a straight average of the
    /// predictions generated by the individual base classifiers.
    /// </summary>
    public RandomCommittee<T> RandomCommittee() { return new RandomCommittee<T>(rt); }

    /// <summary>
    /// This method constructs a decision tree based classifier that maintains
    /// highest accuracy on training data and improves on generalization accuracy as
    /// it grows in complexity. The classifier consists of multiple trees
    /// constructed systematically by pseudorandomly selecting subsets of components of the
    /// feature vector, that is, trees constructed in randomly chosen subspaces.
    /// For more information, see Tin Kam Ho (1998). The Random Subspace Method for
    /// Constructing Decision Forests. IEEE Transactions on Pattern Analysis and
    /// Machine Intelligence. 20(8):832-844. URL
    /// http://citeseer.ist.psu.edu/ho98random.html.
    /// </summary>
    public RandomSubSpace<T> RandomSubSpace() { return new RandomSubSpace<T>(rt); }

    /// <summary>
    /// A regression scheme that employs any classifier on a copy of the data
    /// that has the class attribute discretized. The predicted value is the expected
    /// value of the mean class value for each discretized interval (based on the
    /// predicted probabilities for each interval). This class now also supports
    /// conditional density estimation by building a univariate density estimator from
    /// the target values in the training data, weighted by the class
    /// probabilities. For more information on this process, see Eibe Frank, Remco R.
    /// Bouckaert: Conditional Density Estimation with Class Probability Estimators. In:
    /// First Asian Conference on Machine Learning, Berlin, 65-81, 2009.
    /// </summary>
    public RegressionByDiscretization<T> RegressionByDiscretization() { return new RegressionByDiscretization<T>(rt); }

    /// <summary>
    /// Combines several classifiers using the stacking method. Can do
    /// classification or regression. For more information, see David H. Wolpert (1992).
    /// Stacked generalization. Neural Networks. 5:241-259.
    /// </summary>
    public Stacking<T> Stacking() { return new Stacking<T>(rt); }

    /// <summary>
    /// Class for combining classifiers. Different combinations of probability
    /// estimates for classification are available. For more information see: Ludmila
    /// I. Kuncheva (2004). Combining Pattern Classifiers: Methods and Algorithms.
    /// John Wiley and Sons, Inc.. J. Kittler, M. Hatef, Robert P.W. Duin, J.
    /// Matas (1998). On combining classifiers. IEEE Transactions on Pattern Analysis
    /// and Machine Intelligence. 20(3):226-239.
    /// </summary>
    public Vote<T> Vote() { return new Vote<T>(rt); }

    /// <summary>
    /// Wrapper classifier that addresses incompatible training and test data by
    /// building a mapping between the training data that a classifier has been
    /// built with and the incoming test instances' structure. Model attributes that
    /// are not found in the incoming instances receive missing values, so do
    /// incoming nominal attribute values that the classifier has not seen before. A new
    /// classifier can be trained or an existing one loaded from a file.
    /// </summary>
    public InputMappedClassifier<T> InputMappedClassifier() { return new InputMappedClassifier<T>(rt); }

    /// <summary>
    /// A wrapper around a serialized classifier model. This classifier loads a
    /// serialized models and uses it to make predictions. Warning: since the
    /// serialized model doesn't get changed, cross-validation cannot bet used with this
    /// classifier.
    /// </summary>
    public SerializedClassifier<T> SerializedClassifier() { return new SerializedClassifier<T>(rt); }

    /// <summary>
    /// Class for building and using a simple decision table majority classifier.
    /// For more information see: Ron Kohavi: The Power of Decision Tables. In:
    /// 8th European Conference on Machine Learning, 174-189, 1995.
    /// </summary>
    public DecisionTable<T> DecisionTable() { return new DecisionTable<T>(rt); }

    /// <summary>
    /// This class implements a propositional rule learner, Repeated Incremental
    /// Pruning to Produce Error Reduction (RIPPER), which was proposed by William
    /// W. Cohen as an optimized version of IREP. The algorithm is briefly
    /// described as follows: Initialize RS = {}, and for each class from the less
    /// prevalent one to the more frequent one, DO: 1. Building stage: Repeat 1.1 and 1.2
    /// until the descrition length (DL) of the ruleset and examples is 64 bits
    /// greater than the smallest DL met so far, or there are no positive examples, or
    /// the error rate >= 50%. 1.1. Grow phase: Grow one rule by greedily adding
    /// antecedents (or conditions) to the rule until the rule is perfect (i.e. 100%
    /// accurate). The procedure tries every possible value of each attribute and
    /// selects the condition with highest information gain: p(log(p/t)-log(P/T)).
    /// 1.2. Prune phase: Incrementally prune each rule and allow the pruning of any
    /// final sequences of the antecedents;The pruning metric is (p-n)/(p+n) --
    /// but it's actually 2p/(p+n) -1, so in this implementation we simply use
    /// p/(p+n) (actually (p+1)/(p+n+2), thus if p+n is 0, it's 0.5). 2. Optimization
    /// stage: after generating the initial ruleset {Ri}, generate and prune two
    /// variants of each rule Ri from randomized data using procedure 1.1 and 1.2. But
    /// one variant is generated from an empty rule while the other is generated by
    /// greedily adding antecedents to the original rule. Moreover, the pruning
    /// metric used here is (TP+TN)/(P+N).Then the smallest possible DL for each
    /// variant and the original rule is computed. The variant with the minimal DL is
    /// selected as the final representative of Ri in the ruleset.After all the rules
    /// in {Ri} have been examined and if there are still residual positives, more
    /// rules are generated based on the residual positives using Building Stage
    /// again. 3. Delete the rules from the ruleset that would increase the DL of
    /// the whole ruleset if it were in it. and add resultant ruleset to RS. ENDDO
    /// Note that there seem to be 2 bugs in the original ripper program that would
    /// affect the ruleset size and accuracy slightly. This implementation avoids
    /// these bugs and thus is a little bit different from Cohen's original
    /// implementation. Even after fixing the bugs, since the order of classes with the same
    /// frequency is not defined in ripper, there still seems to be some trivial
    /// difference between this implementation and the original ripper, especially
    /// for audiology data in UCI repository, where there are lots of classes of few
    /// instances. Details please see: William W. Cohen: Fast Effective Rule
    /// Induction. In: Twelfth International Conference on Machine Learning, 115-123,
    /// 1995. PS. We have compared this implementation with the original ripper
    /// implementation in aspects of accuracy, ruleset size and running time on both
    /// artificial data "ab+bcd+defg" and UCI datasets. In all these aspects it seems
    /// to be quite comparable to the original ripper implementation. However, we
    /// didn't consider memory consumption optimization in this implementation.
    /// </summary>
    public JRip<T> JRip() { return new JRip<T>(rt); }

    /// <summary>
    /// Generates a decision list for regression problems using
    /// separate-and-conquer. In each iteration it builds a model tree using M5 and makes the "best"
    /// leaf into a rule. For more information see: Geoffrey Holmes, Mark Hall,
    /// Eibe Frank: Generating Rule Sets from Model Trees. In: Twelfth Australian
    /// Joint Conference on Artificial Intelligence, 1-12, 1999. Ross J. Quinlan:
    /// Learning with Continuous Classes. In: 5th Australian Joint Conference on
    /// Artificial Intelligence, Singapore, 343-348, 1992. Y. Wang, I. H. Witten:
    /// Induction of model trees for predicting continuous classes. In: Poster papers of
    /// the 9th European Conference on Machine Learning, 1997.
    /// </summary>
    public M5Rules<T> M5Rules() { return new M5Rules<T>(rt); }

    /// <summary>
    /// Class for building and using a 1R classifier; in other words, uses the
    /// minimum-error attribute for prediction, discretizing numeric attributes. For
    /// more information, see: R.C. Holte (1993). Very simple classification rules
    /// perform well on most commonly used datasets. Machine Learning. 11:63-91.
    /// </summary>
    public OneR<T> OneR() { return new OneR<T>(rt); }

    /// <summary>
    /// Class for generating a PART decision list. Uses separate-and-conquer.
    /// Builds a partial C4.5 decision tree in each iteration and makes the "best"
    /// leaf into a rule. For more information, see: Eibe Frank, Ian H. Witten:
    /// Generating Accurate Rule Sets Without Global Optimization. In: Fifteenth
    /// International Conference on Machine Learning, 144-151, 1998.
    /// </summary>
    public PART<T> PART() { return new PART<T>(rt); }

    /// <summary>
    /// Class for building and using a 0-R classifier. Predicts the mean (for a
    /// numeric class) or the mode (for a nominal class).
    /// </summary>
    public ZeroR<T> ZeroR() { return new ZeroR<T>(rt); }

    /// <summary>
    /// Class for building and using a decision stump. Usually used in
    /// conjunction with a boosting algorithm. Does regression (based on mean-squared error)
    /// or classification (based on entropy). Missing is treated as a separate
    /// value.
    /// </summary>
    public DecisionStump<T> DecisionStump() { return new DecisionStump<T>(rt); }

    /// <summary>
    /// A Hoeffding tree (VFDT) is an incremental, anytime decision tree
    /// induction algorithm that is capable of learning from massive data streams, assuming
    /// that the distribution generating examples does not change over time.
    /// Hoeffding trees exploit the fact that a small sample can often be enough to
    /// choose an optimal splitting attribute. This idea is supported mathematically by
    /// the Hoeffding bound, which quantifies the number of observations (in our
    /// case, examples) needed to estimate some statistics within a prescribed
    /// precision (in our case, the goodness of an attribute). A theoretically appealing
    /// feature of Hoeffding Trees not shared by otherincremental decision tree
    /// learners is that it has sound guarantees of performance. Using the Hoeffding
    /// bound one can show that its output is asymptotically nearly identical to
    /// that of a non-incremental learner using infinitely many examples. For more
    /// information see: Geoff Hulten, Laurie Spencer, Pedro Domingos: Mining
    /// time-changing data streams. In: ACM SIGKDD Intl. Conf. on Knowledge Discovery and
    /// Data Mining, 97-106, 2001.
    /// </summary>
    public HoeffdingTree<T> HoeffdingTree() { return new HoeffdingTree<T>(rt); }

    /// <summary>
    /// Class for generating a pruned or unpruned C4.5 decision tree. For more
    /// information, see Ross Quinlan (1993). C4.5: Programs for Machine Learning.
    /// Morgan Kaufmann Publishers, San Mateo, CA.
    /// </summary>
    public J48<T> J48() { return new J48<T>(rt); }

    /// <summary>
    /// Classifier for building 'logistic model trees', which are classification
    /// trees with logistic regression functions at the leaves. The algorithm can
    /// deal with binary and multi-class target variables, numeric and nominal
    /// attributes and missing values. For more information see: Niels Landwehr, Mark
    /// Hall, Eibe Frank (2005). Logistic Model Trees. Machine Learning.
    /// 95(1-2):161-205. Marc Sumner, Eibe Frank, Mark Hall: Speeding up Logistic Model Tree
    /// Induction. In: 9th European Conference on Principles and Practice of
    /// Knowledge Discovery in Databases, 675-683, 2005.
    /// </summary>
    public LMT<T> LMT() { return new LMT<T>(rt); }

    /// <summary>
    /// M5Base. Implements base routines for generating M5 Model trees and rules
    /// The original algorithm M5 was invented by R. Quinlan and Yong Wang made
    /// improvements. For more information see: Ross J. Quinlan: Learning with
    /// Continuous Classes. In: 5th Australian Joint Conference on Artificial
    /// Intelligence, Singapore, 343-348, 1992. Y. Wang, I. H. Witten: Induction of model trees
    /// for predicting continuous classes. In: Poster papers of the 9th European
    /// Conference on Machine Learning, 1997.
    /// </summary>
    public M5P<T> M5P() { return new M5P<T>(rt); }

    /// <summary>
    /// Fast decision tree learner. Builds a decision/regression tree using
    /// information gain/variance and prunes it using reduced-error pruning (with
    /// backfitting). Only sorts values for numeric attributes once. Missing values are
    /// dealt with by splitting the corresponding instances into pieces (i.e. as in
    /// C4.5).
    /// </summary>
    public REPTree<T> REPTree() { return new REPTree<T>(rt); }

    /// <summary>
    /// Class for constructing a forest of random trees. For more information
    /// see: Leo Breiman (2001). Random Forests. Machine Learning. 45(1):5-32.
    /// </summary>
    public RandomForest<T> RandomForest() { return new RandomForest<T>(rt); }

    /// <summary>
    /// Class for constructing a tree that considers K randomly chosen attributes
    /// at each node. Performs no pruning. Also has an option to allow estimation
    /// of class probabilities based on a hold-out set (backfitting).
    /// </summary>
    public RandomTree<T> RandomTree() { return new RandomTree<T>(rt); }

    /// <summary>
    /// No class description found.
    /// </summary>
    public LogisticBase<T> LogisticBase() { return new LogisticBase<T>(rt); }

    
  }
}