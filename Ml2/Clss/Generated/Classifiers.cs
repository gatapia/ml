// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  public class Classifiers<T> where T : new()
  {
    private readonly Runtime<T> rt;    
    public Classifiers(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and
    /// facilities common to Bayes Network learning algorithms like K2 and
    /// B.<br/><br/>For more information
    /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-D = 	Do not use ADTree data
    /// structure<br/><br/>-B &lt;BIF file&gt; = 	BIF file to compare with<br/><br/>-Q
    /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
    /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
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
    /// instances.<br/><br/>For more information on Naive Bayes classifiers,
    /// see<br/><br/>George H. John, Pat Langley: Estimating Continuous Distributions in
    /// Bayesian Classifiers. In: Eleventh Conference on Uncertainty in Artificial
    /// Intelligence, San Mateo, 338-345, 1995.<br/><br/>Options:<br/><br/>-K = 	Use
    /// kernel density estimator rather than normal<br/>	distribution for numeric
    /// attributes<br/>-D = 	Use supervised discretization to process numeric
    /// attributes<br/><br/>-O = 	Display model in old format (good when there are many
    /// classes)<br/>
    /// </summary>
    public NaiveBayes<T> NaiveBayes() { return new NaiveBayes<T>(rt); }

    /// <summary>
    /// Class for building and using a multinomial Naive Bayes classifier. For
    /// more information see,<br/><br/>Andrew Mccallum, Kamal Nigam: A Comparison of
    /// Event Models for Naive Bayes Text Classification. In: AAAI-98 Workshop on
    /// 'Learning for Text Categorization', 1998.<br/><br/>The core equation for
    /// this classifier:<br/><br/>P[Ci|D] = (P[D|Ci] x P[Ci]) / P[D] (Bayes
    /// rule)<br/><br/>where Ci is class i and D is a document.<br/><br/>Options:<br/><br/>-D
    /// = 	If set, classifier is run in debug mode and<br/>	may output additional
    /// info to the console
    /// </summary>
    public NaiveBayesMultinomial<T> NaiveBayesMultinomial() { return new NaiveBayesMultinomial<T>(rt); }

    /// <summary>
    /// Multinomial naive bayes for text data. Operates directly (and only) on
    /// String attributes. Other types of input attributes are accepted but ignored
    /// during training and classification<br/><br/>Options:<br/><br/>-W = 	Use word
    /// frequencies instead of binary bag of words.<br/>-P &lt;# instances&gt; =
    /// 	How often to prune the dictionary of low frequency words (default = 0, i.e.
    /// don't prune)<br/>-M &lt;double&gt; = 	Minimum word frequency. Words with
    /// less than this frequence are ignored.<br/>	If periodic pruning is turned on
    /// then this is also used to determine which<br/>	words to remove from the
    /// dictionary (default = 3).<br/>-normalize = 	Normalize document length (use in
    /// conjunction with -norm and -lnorm)<br/>-norm &lt;num&gt; = 	Specify the
    /// norm that each instance must have (default 1.0)<br/>-lnorm &lt;num&gt; =
    /// 	Specify L-norm to use (default 2.0)<br/>-lowercase = 	Convert all tokens to
    /// lowercase before adding to the dictionary.<br/>-stoplist = 	Ignore words that
    /// are in the stoplist.<br/>-stopwords &lt;file&gt; = 	A file containing
    /// stopwords to override the default ones.<br/>	Using this option automatically
    /// sets the flag ('-stoplist') to use the<br/>	stoplist if the file
    /// exists.<br/>	Format: one stopword per line, lines starting with '#'<br/>	are interpreted
    /// as comments and ignored.<br/>-tokenizer &lt;spec&gt; = 	The tokenizing
    /// algorihtm (classname plus parameters) to use.<br/>	(default:
    /// weka.core.tokenizers.WordTokenizer)<br/>-stemmer &lt;spec&gt; = 	The stemmering algorihtm
    /// (classname plus parameters) to use.
    /// </summary>
    public NaiveBayesMultinomialText<T> NaiveBayesMultinomialText() { return new NaiveBayesMultinomialText<T>(rt); }

    /// <summary>
    /// Class for building and using a multinomial Naive Bayes classifier. For
    /// more information see,<br/><br/>Andrew Mccallum, Kamal Nigam: A Comparison of
    /// Event Models for Naive Bayes Text Classification. In: AAAI-98 Workshop on
    /// 'Learning for Text Categorization', 1998.<br/><br/>The core equation for
    /// this classifier:<br/><br/>P[Ci|D] = (P[D|Ci] x P[Ci]) / P[D] (Bayes
    /// rule)<br/><br/>where Ci is class i and D is a document.<br/><br/>Incremental version
    /// of the algorithm.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is
    /// run in debug mode and<br/>	may output additional info to the console
    /// </summary>
    public NaiveBayesMultinomialUpdateable<T> NaiveBayesMultinomialUpdateable() { return new NaiveBayesMultinomialUpdateable<T>(rt); }

    /// <summary>
    /// Class for a Naive Bayes classifier using estimator classes. This is the
    /// updateable version of NaiveBayes.<br/>This classifier will use a default
    /// precision of 0.1 for numeric attributes when buildClassifier is called with
    /// zero training instances.<br/><br/>For more information on Naive Bayes
    /// classifiers, see<br/><br/>George H. John, Pat Langley: Estimating Continuous
    /// Distributions in Bayesian Classifiers. In: Eleventh Conference on Uncertainty in
    /// Artificial Intelligence, San Mateo, 338-345,
    /// 1995.<br/><br/>Options:<br/><br/>-K = 	Use kernel density estimator rather than normal<br/>	distribution
    /// for numeric attributes<br/>-D = 	Use supervised discretization to process
    /// numeric attributes<br/><br/>-O = 	Display model in old format (good when
    /// there are many classes)<br/>
    /// </summary>
    public NaiveBayesUpdateable<T> NaiveBayesUpdateable() { return new NaiveBayesUpdateable<T>(rt); }

    /// <summary>
    /// Builds a description of a Bayes Net classifier stored in XML BIF 0.3
    /// format.<br/><br/>For more details on XML BIF see:<br/><br/>Fabio Cozman, Marek
    /// Druzdzel, Daniel Garcia (1998). XML BIF version 0.3. URL
    /// http://www-2.cs.cmu.edu/~fgcozman/Research/InterchangeFormat/.<br/><br/>Options:<br/><br/>-D
    /// = 	Do not use ADTree data structure<br/><br/>-B &lt;BIF file&gt; = 	BIF
    /// file to compare with<br/><br/>-Q
    /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
    /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
    /// </summary>
    public BIFReader<T> BIFReader() { return new BIFReader<T>(rt); }

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and
    /// facilities common to Bayes Network learning algorithms like K2 and
    /// B.<br/><br/>For more information
    /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-B = 	Generate network (instead of
    /// instances)<br/><br/>-N &lt;integer&gt; = 	Nr of nodes<br/><br/>-A &lt;integer&gt; =
    /// 	Nr of arcs<br/><br/>-M &lt;integer&gt; = 	Nr of instances<br/><br/>-C
    /// &lt;integer&gt; = 	Cardinality of the variables<br/><br/>-S &lt;integer&gt; =
    /// 	Seed for random number generator<br/><br/>-F &lt;file&gt; = 	The BIF file to
    /// obtain the structure from.<br/>
    /// </summary>
    public BayesNetGenerator<T> BayesNetGenerator() { return new BayesNetGenerator<T>(rt); }

    /// <summary>
    /// Bayes Network learning using various search algorithms and quality
    /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
    /// (network structure, conditional probability distributions, etc.) and
    /// facilities common to Bayes Network learning algorithms like K2 and
    /// B.<br/><br/>For more information
    /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-D = 	Do not use ADTree data
    /// structure<br/><br/>-B &lt;BIF file&gt; = 	BIF file to compare with<br/><br/>-Q
    /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
    /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
    /// </summary>
    public EditableBayesNet<T> EditableBayesNet() { return new EditableBayesNet<T>(rt); }

    /// <summary>
    /// Implements Gaussian processes for regression without
    /// hyperparameter-tuning. To make choosing an appropriate noise level easier, this implementation
    /// applies normalization/standardization to the target attribute as well as
    /// the other attributes (if normalization/standardizaton is turned on). Missing
    /// values are replaced by the global mean/mode. Nominal attributes are
    /// converted to binary ones. Note that kernel caching is turned off if the kernel
    /// used implements CachedKernel.<br/><br/>Options:<br/><br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-L &lt;double&gt; = 	Level of Gaussian Noise wrt transformed target.
    /// (default 1)<br/>-N = 	Whether to 0=normalize/1=standardize/2=neither.
    /// (default 0=normalize)<br/>-K &lt;classname and parameters&gt; = 	The Kernel to
    /// use.<br/>	(default:
    /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to kernel
    /// weka.classifiers.functions.supportVector.PolyKernel: = <br/>-D = 	Enables debugging output (if available) to be
    /// printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all checks - use with
    /// caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; = 	The size of the
    /// cache (a prime number), 0 for full cache and <br/>	-1 to turn it
    /// off.<br/>	(default: 250007)<br/>-E &lt;num&gt; = 	The Exponent to use.<br/>	(default:
    /// 1.0)<br/>-L = 	Use lower-order terms.<br/>	(default: no)
    /// </summary>
    public GaussianProcesses<T> GaussianProcesses() { return new GaussianProcesses<T>(rt); }

    /// <summary>
    /// Class for using linear regression for prediction. Uses the Akaike
    /// criterion for model selection, and is able to deal with weighted
    /// instances.<br/><br/>Options:<br/><br/>-D = 	Produce debugging output.<br/>	(default no
    /// debugging output)<br/>-S &lt;number of selection method&gt; = 	Set the attribute
    /// selection method to use. 1 = None, 2 = Greedy.<br/>	(default 0 = M5'
    /// method)<br/>-C = 	Do not try to eliminate colinear attributes.<br/><br/>-R
    /// &lt;double&gt; = 	Set ridge parameter (default 1.0e-8).<br/><br/>-minimal =
    /// 	Conserve memory, don't keep dataset header and means/stdevs.<br/>	Model cannot
    /// be printed out if this option is enabled.	(default: keep data)
    /// </summary>
    public LinearRegression<T> LinearRegression() { return new LinearRegression<T>(rt); }

    /// <summary>
    /// Class for building and using a multinomial logistic regression model with
    /// a ridge estimator.<br/><br/>There are some modifications, however,
    /// compared to the paper of leCessie and van Houwelingen(1992): <br/><br/>If there
    /// are k classes for n instances with m attributes, the parameter matrix B to be
    /// calculated will be an m*(k-1) matrix.<br/><br/>The probability for class j
    /// with the exception of the last class is<br/><br/>Pj(Xi) =
    /// exp(XiBj)/((sum[j=1..(k-1)]exp(Xi*Bj))+1) <br/><br/>The last class has
    /// probability<br/><br/>1-(sum[j=1..(k-1)]Pj(Xi)) <br/>	=
    /// 1/((sum[j=1..(k-1)]exp(Xi*Bj))+1)<br/><br/>The (negative) multinomial log-likelihood is thus: <br/><br/>L =
    /// -sum[i=1..n]{<br/>	sum[j=1..(k-1)](Yij * ln(Pj(Xi)))<br/>	+(1 -
    /// (sum[j=1..(k-1)]Yij)) <br/>	* ln(1 - sum[j=1..(k-1)]Pj(Xi))<br/>	} + ridge *
    /// (B^2)<br/><br/>In order to find the matrix B for which L is minimised, a Quasi-Newton
    /// Method is used to search for the optimized values of the m*(k-1) variables. Note
    /// that before we use the optimization procedure, we 'squeeze' the matrix B
    /// into a m*(k-1) vector. For details of the optimization procedure, please
    /// check weka.core.Optimization class.<br/><br/>Although original Logistic
    /// Regression does not deal with instance weights, we modify the algorithm a little
    /// bit to handle the instance weights.<br/><br/>For more information
    /// see:<br/><br/>le Cessie, S., van Houwelingen, J.C. (1992). Ridge Estimators in
    /// Logistic Regression. Applied Statistics. 41(1):191-201.<br/><br/>Note: Missing
    /// values are replaced using a ReplaceMissingValuesFilter, and nominal
    /// attributes are transformed into numeric attributes using a
    /// NominalToBinaryFilter.<br/><br/>Options:<br/><br/>-D = 	Turn on debugging output.<br/>-C = 	Use
    /// conjugate gradient descent rather than BFGS updates.<br/>-R &lt;ridge&gt; =
    /// 	Set the ridge in the log-likelihood.<br/>-M &lt;number&gt; = 	Set the
    /// maximum number of iterations (default -1, until convergence).
    /// </summary>
    public Logistic<T> Logistic() { return new Logistic<T>(rt); }

    /// <summary>
    /// A Classifier that uses backpropagation to classify instances.<br/>This
    /// network can be built by hand, created by an algorithm or both. The network
    /// can also be monitored and modified during training time. The nodes in this
    /// network are all sigmoid (except for when the class is numeric in which case
    /// the the output nodes become unthresholded linear
    /// units).<br/><br/>Options:<br/><br/>-L &lt;learning rate&gt; = 	Learning Rate for the backpropagation
    /// algorithm.<br/>	(Value should be between 0 - 1, Default = 0.3).<br/>-M
    /// &lt;momentum&gt; = 	Momentum Rate for the backpropagation algorithm.<br/>	(Value
    /// should be between 0 - 1, Default = 0.2).<br/>-N &lt;number of epochs&gt; =
    /// 	Number of epochs to train through.<br/>	(Default = 500).<br/>-V
    /// &lt;percentage size of validation set&gt; = 	Percentage size of validation set to
    /// use to terminate<br/>	training (if this is non zero it can pre-empt num of
    /// epochs.<br/>	(Value should be between 0 - 100, Default = 0).<br/>-S
    /// &lt;seed&gt; = 	The value used to seed the random number generator<br/>	(Value
    /// should be >= 0 and and a long, Default = 0).<br/>-E &lt;threshold for number of
    /// consequetive errors&gt; = 	The consequetive number of errors allowed for
    /// validation<br/>	testing before the netwrok terminates.<br/>	(Value should be
    /// > 0, Default = 20).<br/>-G = 	GUI will be opened.<br/>	(Use this to bring
    /// up a GUI).<br/>-A = 	Autocreation of the network connections will NOT be
    /// done.<br/>	(This will be ignored if -G is NOT set)<br/>-B = 	A NominalToBinary
    /// filter will NOT automatically be used.<br/>	(Set this to not use a
    /// NominalToBinary filter).<br/>-H &lt;comma seperated numbers for nodes on each
    /// layer&gt; = 	The hidden layers to be created for the network.<br/>	(Value
    /// should be a list of comma separated Natural <br/>	numbers or the letters 'a' =
    /// (attribs + classes) / 2, <br/>	'i' = attribs, 'o' = classes, 't' = attribs
    /// .+ classes)<br/>	for wildcard values, Default = a).<br/>-C = 	Normalizing a
    /// numeric class will NOT be done.<br/>	(Set this to not normalize the class
    /// if it's numeric).<br/>-I = 	Normalizing the attributes will NOT be
    /// done.<br/>	(Set this to not normalize the attributes).<br/>-R = 	Reseting the
    /// network will NOT be allowed.<br/>	(Set this to not allow the network to
    /// reset).<br/>-D = 	Learning rate decay will occur.<br/>	(Set this to cause the
    /// learning rate to decay).
    /// </summary>
    public MultilayerPerceptron<T> MultilayerPerceptron() { return new MultilayerPerceptron<T>(rt); }

    /// <summary>
    /// Implements stochastic gradient descent for learning various linear models
    /// (binary class SVM, binary class logistic regression, squared loss, Huber
    /// loss and epsilon-insensitive loss linear regression). Globally replaces all
    /// missing values and transforms nominal attributes into binary ones. It also
    /// normalizes all attributes, so the coefficients in the output are based on
    /// the normalized data.<br/>For numeric class attributes, the squared, Huber or
    /// epsilon-insensitve loss function must be used. Epsilon-insensitive and
    /// Huber loss may require a much higher learning
    /// rate.<br/><br/>Options:<br/><br/>-F = 	Set the loss function to minimize. 0 = hinge loss (SVM), 1 = log
    /// loss (logistic regression),<br/>	2 = squared loss (regression).<br/>	(default
    /// = 0)<br/>-L = 	The learning rate. If normalization is<br/>	turned off (as
    /// it is automatically for streaming data), then the<br/>	default learning rate
    /// will need to be reduced (try 0.0001).<br/>	(default = 0.01).<br/>-R
    /// &lt;double&gt; = 	The lambda regularization constant (default = 0.0001)<br/>-E
    /// &lt;integer&gt; = 	The number of epochs to perform (batch learning only,
    /// default = 500)<br/>-C &lt;double&gt; = 	The epsilon threshold
    /// (epsilon-insenstive and Huber loss only, default = 1e-3)<br/>-N = 	Don't normalize the
    /// data<br/>-M = 	Don't replace missing values
    /// </summary>
    public SGD<T> SGD() { return new SGD<T>(rt); }

    /// <summary>
    /// Implements stochastic gradient descent for learning a linear binary class
    /// SVM or binary class logistic regression on text data. Operates directly
    /// (and only) on String attributes. Other types of input attributes are accepted
    /// but ignored during training and
    /// classification.<br/><br/>Options:<br/><br/>-F = 	Set the loss function to minimize. 0 = hinge loss (SVM), 1 = log
    /// loss (logistic regression)<br/>	(default = 0)<br/>-outputProbs = 	Output
    /// probabilities for SVMs (fits a logsitic<br/>	model to the output of the
    /// SVM)<br/>-L = 	The learning rate (default = 0.01).<br/>-R &lt;double&gt; = 	The
    /// lambda regularization constant (default = 0.0001)<br/>-E &lt;integer&gt; =
    /// 	The number of epochs to perform (batch learning only, default = 500)<br/>-W =
    /// 	Use word frequencies instead of binary bag of words.<br/>-P &lt;#
    /// instances&gt; = 	How often to prune the dictionary of low frequency words (default
    /// = 0, i.e. don't prune)<br/>-M &lt;double&gt; = 	Minimum word frequency.
    /// Words with less than this frequence are ignored.<br/>	If periodic pruning is
    /// turned on then this is also used to determine which<br/>	words to remove
    /// from the dictionary (default = 3).<br/>-normalize = 	Normalize document
    /// length (use in conjunction with -norm and -lnorm)<br/>-norm &lt;num&gt; =
    /// 	Specify the norm that each instance must have (default 1.0)<br/>-lnorm
    /// &lt;num&gt; = 	Specify L-norm to use (default 2.0)<br/>-lowercase = 	Convert all
    /// tokens to lowercase before adding to the dictionary.<br/>-stoplist = 	Ignore
    /// words that are in the stoplist.<br/>-stopwords &lt;file&gt; = 	A file
    /// containing stopwords to override the default ones.<br/>	Using this option
    /// automatically sets the flag ('-stoplist') to use the<br/>	stoplist if the file
    /// exists.<br/>	Format: one stopword per line, lines starting with '#'<br/>	are
    /// interpreted as comments and ignored.<br/>-tokenizer &lt;spec&gt; = 	The
    /// tokenizing algorihtm (classname plus parameters) to use.<br/>	(default:
    /// weka.core.tokenizers.WordTokenizer)<br/>-stemmer &lt;spec&gt; = 	The stemmering
    /// algorihtm (classname plus parameters) to use.
    /// </summary>
    public SGDText<T> SGDText() { return new SGDText<T>(rt); }

    /// <summary>
    /// Implements John Platt's sequential minimal optimization algorithm for
    /// training a support vector classifier.<br/><br/>This implementation globally
    /// replaces all missing values and transforms nominal attributes into binary
    /// ones. It also normalizes all attributes by default. (In that case the
    /// coefficients in the output are based on the normalized data, not the original data
    /// --- this is important for interpreting the
    /// classifier.)<br/><br/>Multi-class problems are solved using pairwise classification (1-vs-1 and if logistic
    /// models are built pairwise coupling according to Hastie and Tibshirani,
    /// 1998).<br/><br/>To obtain proper probability estimates, use the option that
    /// fits logistic regression models to the outputs of the support vector machine.
    /// In the multi-class case the predicted probabilities are coupled using
    /// Hastie and Tibshirani's pairwise coupling method.<br/><br/>Note: for improved
    /// speed normalization should be turned off when operating on
    /// SparseInstances.<br/><br/>For more information on the SMO algorithm, see<br/><br/>J. Platt:
    /// Fast Training of Support Vector Machines using Sequential Minimal
    /// Optimization. In B. Schoelkopf and C. Burges and A. Smola, editors, Advances in
    /// Kernel Methods - Support Vector Learning, 1998.<br/><br/>S.S. Keerthi, S.K.
    /// Shevade, C. Bhattacharyya, K.R.K. Murthy (2001). Improvements to Platt's SMO
    /// Algorithm for SVM Classifier Design. Neural Computation.
    /// 13(3):637-649.<br/><br/>Trevor Hastie, Robert Tibshirani: Classification by Pairwise Coupling.
    /// In: Advances in Neural Information Processing Systems,
    /// 1998.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode and<br/>	may
    /// output additional info to the console<br/>-no-checks = 	Turns off all checks
    /// - use with caution!<br/>	Turning them off assumes that data is purely
    /// numeric, doesn't<br/>	contain any missing values, and has a nominal class.
    /// Turning them<br/>	off also means that no header information will be stored if
    /// the<br/>	machine is linear. Finally, it also assumes that no instance
    /// has<br/>	a weight equal to 0.<br/>	(default: checks on)<br/>-C &lt;double&gt; =
    /// 	The complexity constant C. (default 1)<br/>-N = 	Whether to
    /// 0=normalize/1=standardize/2=neither. (default 0=normalize)<br/>-L &lt;double&gt; = 	The
    /// tolerance parameter. (default 1.0e-3)<br/>-P &lt;double&gt; = 	The epsilon for
    /// round-off error. (default 1.0e-12)<br/>-M = 	Fit logistic models to SVM
    /// outputs. <br/>-V &lt;double&gt; = 	The number of folds for the
    /// internal<br/>	cross-validation. (default -1, use training data)<br/>-W &lt;double&gt; =
    /// 	The random number seed. (default 1)<br/>-K &lt;classname and parameters&gt;
    /// = 	The Kernel to use.<br/>	(default:
    /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to kernel
    /// weka.classifiers.functions.supportVector.PolyKernel: = <br/>-D = 	Enables debugging output (if
    /// available) to be printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all
    /// checks - use with caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; =
    /// 	The size of the cache (a prime number), 0 for full cache and <br/>	-1 to
    /// turn it off.<br/>	(default: 250007)<br/>-E &lt;num&gt; = 	The Exponent to
    /// use.<br/>	(default: 1.0)<br/>-L = 	Use lower-order terms.<br/>	(default: no)
    /// </summary>
    public SMO<T> SMO() { return new SMO<T>(rt); }

    /// <summary>
    /// SMOreg implements the support vector machine for regression. The
    /// parameters can be learned using various algorithms. The algorithm is selected by
    /// setting the RegOptimizer. The most popular algorithm (RegSMOImproved) is due
    /// to Shevade, Keerthi et al and this is the default
    /// RegOptimizer.<br/><br/>For more information see:<br/><br/>S.K. Shevade, S.S. Keerthi, C.
    /// Bhattacharyya, K.R.K. Murthy: Improvements to the SMO Algorithm for SVM Regression.
    /// In: IEEE Transactions on Neural Networks, 1999.<br/><br/>A.J. Smola, B.
    /// Schoelkopf (1998). A tutorial on support vector
    /// regression.<br/><br/>Options:<br/><br/>-C &lt;double&gt; = 	The complexity constant C.<br/>	(default
    /// 1)<br/>-N = 	Whether to 0=normalize/1=standardize/2=neither.<br/>	(default
    /// 0=normalize)<br/>-I &lt;classname and parameters&gt; = 	Optimizer class used for
    /// solving quadratic optimization problem<br/>	(default
    /// weka.classifiers.functions.supportVector.RegSMOImproved)<br/>-K &lt;classname and parameters&gt;
    /// = 	The Kernel to use.<br/>	(default:
    /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to optimizer ('-I')
    /// weka.classifiers.functions.supportVector.RegSMOImproved: = <br/>-T &lt;double&gt; = 	The
    /// tolerance parameter for checking the stopping criterion.<br/>	(default
    /// 0.001)<br/>-V = 	Use variant 1 of the algorithm when true, otherwise use
    /// variant 2.<br/>	(default true)<br/>-P &lt;double&gt; = 	The epsilon for round-off
    /// error.<br/>	(default 1.0e-12)<br/>-L &lt;double&gt; = 	The epsilon
    /// parameter in epsilon-insensitive loss function.<br/>	(default 1.0e-3)<br/>-W
    /// &lt;double&gt; = 	The random number seed.<br/>	(default 1)<br/><br/>Options
    /// specific to kernel ('-K') weka.classifiers.functions.supportVector.PolyKernel:
    /// = <br/>-D = 	Enables debugging output (if available) to be
    /// printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all checks - use with
    /// caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; = 	The size of the cache (a prime
    /// number), 0 for full cache and <br/>	-1 to turn it off.<br/>	(default:
    /// 250007)<br/>-E &lt;num&gt; = 	The Exponent to use.<br/>	(default: 1.0)<br/>-L =
    /// 	Use lower-order terms.<br/>	(default: no)
    /// </summary>
    public SMOreg<T> SMOreg() { return new SMOreg<T>(rt); }

    /// <summary>
    /// Learns a simple linear regression model. Picks the attribute that results
    /// in the lowest squared error. Missing values are not allowed. Can only deal
    /// with numeric attributes.<br/><br/>Options:<br/><br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the console
    /// </summary>
    public SimpleLinearRegression<T> SimpleLinearRegression() { return new SimpleLinearRegression<T>(rt); }

    /// <summary>
    /// Classifier for building linear logistic regression models. LogitBoost
    /// with simple regression functions as base learners is used for fitting the
    /// logistic models. The optimal number of LogitBoost iterations to perform is
    /// cross-validated, which leads to automatic attribute selection. For more
    /// information see:<br/>Niels Landwehr, Mark Hall, Eibe Frank (2005). Logistic Model
    /// Trees.<br/><br/>Marc Sumner, Eibe Frank, Mark Hall: Speeding up Logistic
    /// Model Tree Induction. In: 9th European Conference on Principles and Practice
    /// of Knowledge Discovery in Databases, 675-683,
    /// 2005.<br/><br/>Options:<br/><br/>-I &lt;iterations&gt; = 	Set fixed number of iterations for
    /// LogitBoost<br/>-S = 	Use stopping criterion on training set (instead
    /// of<br/>	cross-validation)<br/>-P = 	Use error on probabilities (rmse) instead
    /// of<br/>	misclassification error for stopping criterion<br/>-M &lt;iterations&gt; = 	Set
    /// maximum number of boosting iterations<br/>-H &lt;iterations&gt; = 	Set
    /// parameter for heuristic for early stopping of<br/>	LogitBoost.<br/>	If enabled,
    /// the minimum is selected greedily, stopping<br/>	if the current minimum has
    /// not changed for iter iterations.<br/>	By default, heuristic is enabled with
    /// value 50. Set to<br/>	zero to disable heuristic.<br/>-W &lt;beta&gt; =
    /// 	Set beta for weight trimming for LogitBoost. Set to 0 for no weight
    /// trimming.<br/><br/>-A = 	The AIC is used to choose the best iteration (instead of CV
    /// or training error).<br/>
    /// </summary>
    public SimpleLogistic<T> SimpleLogistic() { return new SimpleLogistic<T>(rt); }

    /// <summary>
    /// Implementation of the voted perceptron algorithm by Freund and Schapire.
    /// Globally replaces all missing values, and transforms nominal attributes
    /// into binary ones.<br/><br/>For more information, see:<br/><br/>Y. Freund, R.
    /// E. Schapire: Large margin classification using the perceptron algorithm. In:
    /// 11th Annual Conference on Computational Learning Theory, New York, NY,
    /// 209-217, 1998.<br/><br/>Options:<br/><br/>-I &lt;int&gt; = 	The number of
    /// iterations to be performed.<br/>	(default 1)<br/>-E &lt;double&gt; = 	The
    /// exponent for the polynomial kernel.<br/>	(default 1)<br/>-S &lt;int&gt; = 	The
    /// seed for the random number generation.<br/>	(default 1)<br/>-M &lt;int&gt; =
    /// 	The maximum number of alterations allowed.<br/>	(default 10000)
    /// </summary>
    public VotedPerceptron<T> VotedPerceptron() { return new VotedPerceptron<T>(rt); }

    /// <summary>
    /// K-nearest neighbours classifier. Can select appropriate value of K based
    /// on cross-validation. Can also do distance weighting.<br/><br/>For more
    /// information, see<br/><br/>D. Aha, D. Kibler (1991). Instance-based learning
    /// algorithms. Machine Learning. 6:37-66.<br/><br/>Options:<br/><br/>-I = 	Weight
    /// neighbours by the inverse of their distance<br/>	(use when k > 1)<br/>-F =
    /// 	Weight neighbours by 1 - their distance<br/>	(use when k > 1)<br/>-K
    /// &lt;number of neighbors&gt; = 	Number of nearest neighbours (k) used in
    /// classification.<br/>	(Default = 1)<br/>-E = 	Minimise mean squared error rather
    /// than mean absolute<br/>	error when using -X option with numeric
    /// prediction.<br/>-W &lt;window size&gt; = 	Maximum number of training instances
    /// maintained.<br/>	Training instances are dropped FIFO. (Default = no window)<br/>-X =
    /// 	Select the number of nearest neighbours between 1<br/>	and the k value
    /// specified using hold-one-out evaluation<br/>	on the training data (use when k
    /// > 1)<br/>-A = 	The nearest neighbour search algorithm to use (default:
    /// weka.core.neighboursearch.LinearNNSearch).<br/>
    /// </summary>
    public IBk<T> IBk() { return new IBk<T>(rt); }

    /// <summary>
    /// K* is an instance-based classifier, that is the class of a test instance
    /// is based upon the class of those training instances similar to it, as
    /// determined by some similarity function. It differs from other instance-based
    /// learners in that it uses an entropy-based distance function.<br/><br/>For more
    /// information on K*, see<br/><br/>John G. Cleary, Leonard E. Trigg: K*: An
    /// Instance-based Learner Using an Entropic Distance Measure. In: 12th
    /// International Conference on Machine Learning, 108-114,
    /// 1995.<br/><br/>Options:<br/><br/>-B &lt;num&gt; = 	Manual blend setting (default 20%)<br/><br/>-E =
    /// 	Enable entropic auto-blend setting (symbolic class only)<br/><br/>-M
    /// &lt;char&gt; = 	Specify the missing value treatment mode (default a)<br/>	Valid
    /// options are: a(verage), d(elete), m(axdiff), n(ormal)<br/>
    /// </summary>
    public KStar<T> KStar() { return new KStar<T>(rt); }

    /// <summary>
    /// Locally weighted learning. Uses an instance-based algorithm to assign
    /// instance weights which are then used by a specified
    /// WeightedInstancesHandler.<br/>Can do classification (e.g. using naive Bayes) or regression (e.g.
    /// using linear regression).<br/><br/>For more info, see<br/><br/>Eibe Frank, Mark
    /// Hall, Bernhard Pfahringer: Locally Weighted Naive Bayes. In: 19th
    /// Conference in Uncertainty in Artificial Intelligence, 249-256, 2003.<br/><br/>C.
    /// Atkeson, A. Moore, S. Schaal (1996). Locally weighted learning. AI
    /// Review..<br/><br/>Options:<br/><br/>-A = 	The nearest neighbour search algorithm to
    /// use (default: weka.core.neighboursearch.LinearNNSearch).<br/><br/>-K
    /// &lt;number of neighbours&gt; = 	Set the number of neighbours used to set the
    /// kernel bandwidth.<br/>	(default all)<br/>-U &lt;number of weighting method&gt; =
    /// 	Set the weighting kernel shape to use. 0=Linear,
    /// 1=Epanechnikov,<br/>	2=Tricube, 3=Inverse, 4=Gaussian.<br/>	(default 0 = Linear)<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier
    /// weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set, classifier is run in
    /// debug mode and<br/>	may output additional info to the console
    /// </summary>
    public LWL<T> LWL() { return new LWL<T>(rt); }

    /// <summary>
    /// Class for boosting a nominal class classifier using the Adaboost M1
    /// method. Only nominal class problems can be tackled. Often dramatically improves
    /// performance, but sometimes overfits.<br/><br/>For more information,
    /// see<br/><br/>Yoav Freund, Robert E. Schapire: Experiments with a new boosting
    /// algorithm. In: Thirteenth International Conference on Machine Learning, San
    /// Francisco, 148-156, 1996.<br/><br/>Options:<br/><br/>-P &lt;num&gt; =
    /// 	Percentage of weight mass to base training on.<br/>	(default 100, reduce to around
    /// 90 speed up)<br/>-Q = 	Use resampling for boosting.<br/>-S &lt;num&gt; =
    /// 	Random number seed.<br/>	(default 1)<br/>-I &lt;num&gt; = 	Number of
    /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of
    /// base classifier.<br/>	(default:
    /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier weka.classifiers.trees.DecisionStump: =
    /// <br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public AdaBoostM1<T> AdaBoostM1() { return new AdaBoostM1<T>(rt); }

    /// <summary>
    /// Meta classifier that enhances the performance of a regression base
    /// classifier. Each iteration fits a model to the residuals left by the classifier
    /// on the previous iteration. Prediction is accomplished by adding the
    /// predictions of each classifier. Reducing the shrinkage (learning rate) parameter
    /// helps prevent overfitting and has a smoothing effect but increases the
    /// learning time.<br/><br/>For more information see:<br/><br/>J.H. Friedman (1999).
    /// Stochastic Gradient Boosting.<br/><br/>Options:<br/><br/>-S = 	Specify
    /// shrinkage rate. (default = 1.0, ie. no shrinkage)<br/><br/>-I &lt;num&gt; =
    /// 	Number of iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run
    /// in debug mode and<br/>	may output additional info to the console<br/>-W =
    /// 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier
    /// weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set, classifier is run in debug mode and<br/>	may
    /// output additional info to the console
    /// </summary>
    public AdditiveRegression<T> AdditiveRegression() { return new AdditiveRegression<T>(rt); }

    /// <summary>
    /// Dimensionality of training and test data is reduced by attribute
    /// selection before being passed on to a classifier.<br/><br/>Options:<br/><br/>-E
    /// &lt;attribute evaluator specification&gt; = 	Full class name of attribute
    /// evaluator, followed<br/>	by its options.<br/>	eg:
    /// "weka.attributeSelection.CfsSubsetEval -L"<br/>	(default weka.attributeSelection.CfsSubsetEval)<br/>-S
    /// &lt;search method specification&gt; = 	Full class name of search method,
    /// followed<br/>	by its options.<br/>	eg: "weka.attributeSelection.BestFirst -D
    /// 1"<br/>	(default weka.attributeSelection.BestFirst)<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.J48)<br/><br/>Options specific to classifier
    /// weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned tree.<br/>-O = 	Do not collapse tree.<br/>-C
    /// &lt;pruning confidence&gt; = 	Set confidence threshold for
    /// pruning.<br/>	(default 0.25)<br/>-M &lt;minimum number of instances&gt; = 	Set minimum
    /// number of instances per leaf.<br/>	(default 2)<br/>-R = 	Use reduced error
    /// pruning.<br/>-N &lt;number of folds&gt; = 	Set number of folds for reduced
    /// error<br/>	pruning. One fold is used as pruning set.<br/>	(default 3)<br/>-B =
    /// 	Use binary splits only.<br/>-S = 	Don't perform subtree raising.<br/>-L =
    /// 	Do not clean up after the tree has been built.<br/>-A = 	Laplace smoothing
    /// for predicted probabilities.<br/>-J = 	Do not use MDL correction for info
    /// gain on numeric attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data
    /// shuffling (default 1).
    /// </summary>
    public AttributeSelectedClassifier<T> AttributeSelectedClassifier() { return new AttributeSelectedClassifier<T>(rt); }

    /// <summary>
    /// Class for bagging a classifier to reduce variance. Can do classification
    /// and regression depending on the base learner. <br/><br/>For more
    /// information, see<br/><br/>Leo Breiman (1996). Bagging predictors. Machine Learning.
    /// 24(2):123-140.<br/><br/>Options:<br/><br/>-P = 	Size of each bag, as a
    /// percentage of the<br/>	training set size. (default 100)<br/>-O = 	Calculate the
    /// out of bag error.<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
    /// 1)<br/>-num-slots &lt;num&gt; = 	Number of execution slots.<br/>	(default 1
    /// - i.e. no parallelism)<br/>-I &lt;num&gt; = 	Number of
    /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may
    /// output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.REPTree)<br/><br/>Options specific
    /// to classifier weka.classifiers.trees.REPTree: = <br/>-M &lt;minimum number
    /// of instances&gt; = 	Set minimum number of instances per leaf (default
    /// 2).<br/>-V &lt;minimum variance for split&gt; = 	Set minimum numeric class
    /// variance proportion<br/>	of train variance for split (default 1e-3).<br/>-N
    /// &lt;number of folds&gt; = 	Number of folds for reduced error pruning (default
    /// 3).<br/>-S &lt;seed&gt; = 	Seed for random data shuffling (default 1).<br/>-P
    /// = 	No pruning.<br/>-L = 	Maximum tree depth (default -1, no
    /// maximum)<br/>-I = 	Initial class value count (default 0)<br/>-R = 	Spread initial count
    /// over all class values (i.e. don't use 1 per value)
    /// </summary>
    public Bagging<T> Bagging() { return new Bagging<T>(rt); }

    /// <summary>
    /// Class for performing parameter selection by cross-validation for any
    /// classifier.<br/><br/>For more information, see:<br/><br/>R. Kohavi (1995).
    /// Wrappers for Performance Enhancement and Oblivious Decision Graphs. Department
    /// of Computer Science, Stanford University.<br/><br/>Options:<br/><br/>-X
    /// &lt;number of folds&gt; = 	Number of folds used for cross validation (default
    /// 10).<br/>-P &lt;classifier parameter&gt; = 	Classifier parameter
    /// options.<br/>	eg: "N 1 5 10" Sets an optimisation parameter for the<br/>	classifier
    /// with name -N, with lower bound 1, upper bound<br/>	5, and 10 optimisation
    /// steps. The upper bound may be the<br/>	character 'A' or 'I' to substitute the
    /// number of<br/>	attributes or instances in the training
    /// data,<br/>	respectively. This parameter may be supplied more than<br/>	once to optimise over
    /// several classifier options<br/>	simultaneously.<br/>-S &lt;num&gt; = 	Random
    /// number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is run in debug
    /// mode and<br/>	may output additional info to the console<br/>-W = 	Full
    /// name of base classifier.<br/>	(default:
    /// weka.classifiers.rules.ZeroR)<br/><br/>Options specific to classifier weka.classifiers.rules.ZeroR: = <br/>-D =
    /// 	If set, classifier is run in debug mode and<br/>	may output additional info
    /// to the console
    /// </summary>
    public CVParameterSelection<T> CVParameterSelection() { return new CVParameterSelection<T>(rt); }

    /// <summary>
    /// Class for doing classification using regression methods. Class is
    /// binarized and one regression model is built for each class value. For more
    /// information, see, for example<br/><br/>E. Frank, Y. Wang, S. Inglis, G. Holmes,
    /// I.H. Witten (1998). Using model trees for classification. Machine Learning.
    /// 32(1):63-76.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in
    /// debug mode and<br/>	may output additional info to the console<br/>-W = 	Full
    /// name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.M5P)<br/><br/>Options specific to classifier weka.classifiers.trees.M5P: = <br/>-N =
    /// 	Use unpruned tree/rules<br/>-U = 	Use unsmoothed predictions<br/>-R =
    /// 	Build regression tree/rule rather than a model tree/rule<br/>-M &lt;minimum
    /// number of instances&gt; = 	Set minimum number of instances per
    /// leaf<br/>	(default 4)<br/>-L = 	Save instances at the nodes in<br/>	the tree (for
    /// visualization purposes)
    /// </summary>
    public ClassificationViaRegression<T> ClassificationViaRegression() { return new ClassificationViaRegression<T>(rt); }

    /// <summary>
    /// A metaclassifier that makes its base classifier cost-sensitive. Two
    /// methods can be used to introduce cost-sensitivity: reweighting training
    /// instances according to the total cost assigned to each class; or predicting the
    /// class with minimum expected misclassification cost (rather than the most
    /// likely class). Performance can often be improved by using a Bagged classifier to
    /// improve the probability estimates of the base
    /// classifier.<br/><br/>Options:<br/><br/>-M = 	Minimize expected misclassification cost. Default is
    /// to<br/>	reweight training instances according to costs per class<br/>-C &lt;cost
    /// file name&gt; = 	File name of a cost matrix to use. If this is not
    /// supplied,<br/>	a cost matrix will be loaded on demand. The name of
    /// the<br/>	on-demand file is the relation name of the training data<br/>	plus ".cost", and
    /// the path to the on-demand file is<br/>	specified with the -N option.<br/>-N
    /// &lt;directory&gt; = 	Name of a directory to search for cost files when
    /// loading<br/>	costs on demand (default current directory).<br/>-cost-matrix
    /// &lt;matrix&gt; = 	The cost matrix in Matlab single line format.<br/>-S
    /// &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is
    /// run in debug mode and<br/>	may output additional info to the
    /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.rules.ZeroR)<br/><br/>Options specific to classifier weka.classifiers.rules.ZeroR:
    /// = <br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public CostSensitiveClassifier<T> CostSensitiveClassifier() { return new CostSensitiveClassifier<T>(rt); }

    /// <summary>
    /// Class for running an arbitrary classifier on data that has been passed
    /// through an arbitrary filter. Like the classifier, the structure of the filter
    /// is based exclusively on the training data and test instances will be
    /// processed by the filter without changing their
    /// structure.<br/><br/>Options:<br/><br/>-F &lt;filter specification&gt; = 	Full class name of filter to use,
    /// followed<br/>	by filter options.<br/>	eg:
    /// "weka.filters.unsupervised.attribute.Remove -V -R 1,2"<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.J48)<br/><br/>Options
    /// specific to classifier weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned
    /// tree.<br/>-O = 	Do not collapse tree.<br/>-C &lt;pruning confidence&gt; =
    /// 	Set confidence threshold for pruning.<br/>	(default 0.25)<br/>-M &lt;minimum
    /// number of instances&gt; = 	Set minimum number of instances per
    /// leaf.<br/>	(default 2)<br/>-R = 	Use reduced error pruning.<br/>-N &lt;number of
    /// folds&gt; = 	Set number of folds for reduced error<br/>	pruning. One fold is
    /// used as pruning set.<br/>	(default 3)<br/>-B = 	Use binary splits only.<br/>-S
    /// = 	Don't perform subtree raising.<br/>-L = 	Do not clean up after the tree
    /// has been built.<br/>-A = 	Laplace smoothing for predicted
    /// probabilities.<br/>-J = 	Do not use MDL correction for info gain on numeric
    /// attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling (default 1).
    /// </summary>
    public FilteredClassifier<T> FilteredClassifier() { return new FilteredClassifier<T>(rt); }

    /// <summary>
    /// Class for performing additive logistic regression. <br/>This class
    /// performs classification using a regression scheme as the base learner, and can
    /// handle multi-class problems. For more information, see<br/><br/>J. Friedman,
    /// T. Hastie, R. Tibshirani (1998). Additive Logistic Regression: a
    /// Statistical View of Boosting. Stanford University.<br/><br/>Can do efficient internal
    /// cross-validation to determine appropriate number of
    /// iterations.<br/><br/>Options:<br/><br/>-Q = 	Use resampling instead of reweighting for
    /// boosting.<br/>-P &lt;percent&gt; = 	Percentage of weight mass to base training
    /// on.<br/>	(default 100, reduce to around 90 speed up)<br/>-F &lt;num&gt; = 	Number
    /// of folds for internal cross-validation.<br/>	(default 0 -- no
    /// cross-validation)<br/>-R &lt;num&gt; = 	Number of runs for internal
    /// cross-validation.<br/>	(default 1)<br/>-L &lt;num&gt; = 	Threshold on the improvement of the
    /// likelihood.<br/>	(default -Double.MAX_VALUE)<br/>-H &lt;num&gt; = 	Shrinkage
    /// parameter.<br/>	(default 1)<br/>-S &lt;num&gt; = 	Random number
    /// seed.<br/>	(default 1)<br/>-I &lt;num&gt; = 	Number of iterations.<br/>	(default
    /// 10)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to
    /// classifier weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the console
    /// </summary>
    public LogitBoost<T> LogitBoost() { return new LogitBoost<T>(rt); }

    /// <summary>
    /// A metaclassifier for handling multi-class datasets with 2-class
    /// classifiers. This classifier is also capable of applying error correcting output
    /// codes for increased accuracy.<br/><br/>Options:<br/><br/>-M &lt;num&gt; =
    /// 	Sets the method to use. Valid values are 0 (1-against-all),<br/>	1 (random
    /// codes), 2 (exhaustive code), and 3 (1-against-1). (default 0)<br/><br/>-R
    /// &lt;num&gt; = 	Sets the multiplier when using random codes. (default
    /// 2.0)<br/>-P = 	Use pairwise coupling (only has an effect for 1-against1)<br/>-S
    /// &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-D = 	If set, classifier
    /// is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.functions.Logistic)<br/><br/>Options specific to classifier
    /// weka.classifiers.functions.Logistic: = <br/>-D = 	Turn on debugging output.<br/>-C = 	Use
    /// conjugate gradient descent rather than BFGS updates.<br/>-R &lt;ridge&gt; = 	Set
    /// the ridge in the log-likelihood.<br/>-M &lt;number&gt; = 	Set the maximum
    /// number of iterations (default -1, until convergence).
    /// </summary>
    public MultiClassClassifier<T> MultiClassClassifier() { return new MultiClassClassifier<T>(rt); }

    /// <summary>
    /// A metaclassifier for handling multi-class datasets with 2-class
    /// classifiers. This classifier is also capable of applying error correcting output
    /// codes for increased accuracy. The base classifier must be an updateable
    /// classifier<br/><br/>Options:<br/><br/>-M &lt;num&gt; = 	Sets the method to use.
    /// Valid values are 0 (1-against-all),<br/>	1 (random codes), 2 (exhaustive
    /// code), and 3 (1-against-1). (default 0)<br/><br/>-R &lt;num&gt; = 	Sets the
    /// multiplier when using random codes. (default 2.0)<br/>-P = 	Use pairwise
    /// coupling (only has an effect for 1-against1)<br/>-S &lt;num&gt; = 	Random
    /// number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of
    /// base classifier.<br/>	(default:
    /// weka.classifiers.functions.Logistic)<br/><br/>Options specific to classifier weka.classifiers.functions.SGD: = <br/>-F
    /// = 	Set the loss function to minimize. 0 = hinge loss (SVM), 1 = log loss
    /// (logistic regression),<br/>	2 = squared loss (regression).<br/>	(default =
    /// 0)<br/>-L = 	The learning rate. If normalization is<br/>	turned off (as it is
    /// automatically for streaming data), then the<br/>	default learning rate
    /// will need to be reduced (try 0.0001).<br/>	(default = 0.01).<br/>-R
    /// &lt;double&gt; = 	The lambda regularization constant (default = 0.0001)<br/>-E
    /// &lt;integer&gt; = 	The number of epochs to perform (batch learning only, default
    /// = 500)<br/>-C &lt;double&gt; = 	The epsilon threshold (epsilon-insenstive
    /// and Huber loss only, default = 1e-3)<br/>-N = 	Don't normalize the
    /// data<br/>-M = 	Don't replace missing values
    /// </summary>
    public MultiClassClassifierUpdateable<T> MultiClassClassifierUpdateable() { return new MultiClassClassifierUpdateable<T>(rt); }

    /// <summary>
    /// Class for selecting a classifier from among several using cross
    /// validation on the training data or the performance on the training data. Performance
    /// is measured based on percent correct (classification) or mean-squared
    /// error (regression).<br/><br/>Options:<br/><br/>-X &lt;number of folds&gt; =
    /// 	Use cross validation for model selection using the<br/>	given number of
    /// folds. (default 0, is to<br/>	use training error)<br/>-S &lt;num&gt; = 	Random
    /// number seed.<br/>	(default 1)<br/>-B &lt;classifier specification&gt; =
    /// 	Full class name of classifier to include, followed<br/>	by scheme options. May
    /// be specified multiple times.<br/>	(default:
    /// "weka.classifiers.rules.ZeroR")<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public MultiScheme<T> MultiScheme() { return new MultiScheme<T>(rt); }

    /// <summary>
    /// Class for building an ensemble of randomizable base classifiers. Each
    /// base classifiers is built using a different random number seed (but based one
    /// the same data). The final prediction is a straight average of the
    /// predictions generated by the individual base
    /// classifiers.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-num-slots
    /// &lt;num&gt; = 	Number of execution slots.<br/>	(default 1 - i.e. no
    /// parallelism)<br/>-I &lt;num&gt; = 	Number of iterations.<br/>	(default 10)<br/>-D =
    /// 	If set, classifier is run in debug mode and<br/>	may output additional info
    /// to the console<br/>-W = 	Full name of base classifier.<br/>	(default:
    /// weka.classifiers.trees.RandomTree)<br/><br/>Options specific to classifier
    /// weka.classifiers.trees.RandomTree: = <br/>-K &lt;number of attributes&gt; =
    /// 	Number of attributes to randomly investigate<br/>	(<0 =
    /// int(log_2(#attributes)+1)).<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
    /// instances per leaf.<br/>-S &lt;num&gt; = 	Seed for random number
    /// generator.<br/>	(default 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the tree, 0
    /// for unlimited.<br/>	(default 0)<br/>-N &lt;num&gt; = 	Number of folds for
    /// backfitting (default 0, no backfitting).<br/>-U = 	Allow unclassified
    /// instances.<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public RandomCommittee<T> RandomCommittee() { return new RandomCommittee<T>(rt); }

    /// <summary>
    /// This method constructs a decision tree based classifier that maintains
    /// highest accuracy on training data and improves on generalization accuracy as
    /// it grows in complexity. The classifier consists of multiple trees
    /// constructed systematically by pseudorandomly selecting subsets of components of the
    /// feature vector, that is, trees constructed in randomly chosen
    /// subspaces.<br/><br/>For more information, see<br/><br/>Tin Kam Ho (1998). The Random
    /// Subspace Method for Constructing Decision Forests. IEEE Transactions on
    /// Pattern Analysis and Machine Intelligence. 20(8):832-844. URL
    /// http://citeseer.ist.psu.edu/ho98random.html.<br/><br/>Options:<br/><br/>-P = 	Size of each
    /// subspace:<br/>		< 1: percentage of the number of attributes<br/>		>=1:
    /// absolute number of attributes<br/><br/>-S &lt;num&gt; = 	Random number
    /// seed.<br/>	(default 1)<br/>-num-slots &lt;num&gt; = 	Number of execution
    /// slots.<br/>	(default 1 - i.e. no parallelism)<br/>-I &lt;num&gt; = 	Number of
    /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.REPTree)<br/><br/>Options
    /// specific to classifier weka.classifiers.trees.REPTree: = <br/>-M
    /// &lt;minimum number of instances&gt; = 	Set minimum number of instances per leaf
    /// (default 2).<br/>-V &lt;minimum variance for split&gt; = 	Set minimum numeric
    /// class variance proportion<br/>	of train variance for split (default
    /// 1e-3).<br/>-N &lt;number of folds&gt; = 	Number of folds for reduced error pruning
    /// (default 3).<br/>-S &lt;seed&gt; = 	Seed for random data shuffling (default
    /// 1).<br/>-P = 	No pruning.<br/>-L = 	Maximum tree depth (default -1, no
    /// maximum)<br/>-I = 	Initial class value count (default 0)<br/>-R = 	Spread
    /// initial count over all class values (i.e. don't use 1 per value)
    /// </summary>
    public RandomSubSpace<T> RandomSubSpace() { return new RandomSubSpace<T>(rt); }

    /// <summary>
    /// A regression scheme that employs any classifier on a copy of the data
    /// that has the class attribute discretized. The predicted value is the expected
    /// value of the mean class value for each discretized interval (based on the
    /// predicted probabilities for each interval). This class now also supports
    /// conditional density estimation by building a univariate density estimator from
    /// the target values in the training data, weighted by the class
    /// probabilities. <br/><br/>For more information on this process, see<br/><br/>Eibe Frank,
    /// Remco R. Bouckaert: Conditional Density Estimation with Class Probability
    /// Estimators. In: First Asian Conference on Machine Learning, Berlin, 65-81,
    /// 2009.<br/><br/>Options:<br/><br/>-B &lt;int&gt; = 	Number of bins for
    /// equal-width discretization<br/>	(default 10).<br/><br/>-E = 	Whether to delete
    /// empty bins after discretization<br/>	(default false).<br/><br/>-A = 	Whether
    /// to minimize absolute error, rather than squared error.<br/>	(default
    /// false).<br/><br/>-F = 	Use equal-frequency instead of equal-width
    /// discretization.<br/>-K = 	What type of density estimator to use:
    /// 0=histogram/1=kernel/2=normal (default: 0).<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.trees.J48)<br/><br/>Options
    /// specific to classifier weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned
    /// tree.<br/>-O = 	Do not collapse tree.<br/>-C &lt;pruning confidence&gt; =
    /// 	Set confidence threshold for pruning.<br/>	(default 0.25)<br/>-M &lt;minimum
    /// number of instances&gt; = 	Set minimum number of instances per
    /// leaf.<br/>	(default 2)<br/>-R = 	Use reduced error pruning.<br/>-N &lt;number of
    /// folds&gt; = 	Set number of folds for reduced error<br/>	pruning. One fold is used
    /// as pruning set.<br/>	(default 3)<br/>-B = 	Use binary splits only.<br/>-S
    /// = 	Don't perform subtree raising.<br/>-L = 	Do not clean up after the tree
    /// has been built.<br/>-A = 	Laplace smoothing for predicted
    /// probabilities.<br/>-J = 	Do not use MDL correction for info gain on numeric
    /// attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling (default 1).
    /// </summary>
    public RegressionByDiscretization<T> RegressionByDiscretization() { return new RegressionByDiscretization<T>(rt); }

    /// <summary>
    /// Combines several classifiers using the stacking method. Can do
    /// classification or regression.<br/><br/>For more information, see<br/><br/>David H.
    /// Wolpert (1992). Stacked generalization. Neural Networks.
    /// 5:241-259.<br/><br/>Options:<br/><br/>-M &lt;scheme specification&gt; = 	Full name of meta
    /// classifier, followed by options.<br/>	(default:
    /// "weka.classifiers.rules.Zero")<br/>-X &lt;number of folds&gt; = 	Sets the number of cross-validation
    /// folds.<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-num-slots
    /// &lt;num&gt; = 	Number of execution slots.<br/>	(default 1 - i.e. no
    /// parallelism)<br/>-B &lt;classifier specification&gt; = 	Full class name of
    /// classifier to include, followed<br/>	by scheme options. May be specified multiple
    /// times.<br/>	(default: "weka.classifiers.rules.ZeroR")<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console
    /// </summary>
    public Stacking<T> Stacking() { return new Stacking<T>(rt); }

    /// <summary>
    /// Class for combining classifiers. Different combinations of probability
    /// estimates for classification are available.<br/><br/>For more information
    /// see:<br/><br/>Ludmila I. Kuncheva (2004). Combining Pattern Classifiers:
    /// Methods and Algorithms. John Wiley and Sons, Inc..<br/><br/>J. Kittler, M.
    /// Hatef, Robert P.W. Duin, J. Matas (1998). On combining classifiers. IEEE
    /// Transactions on Pattern Analysis and Machine Intelligence.
    /// 20(3):226-239.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
    /// 1)<br/>-B &lt;classifier specification&gt; = 	Full class name of classifier to
    /// include, followed<br/>	by scheme options. May be specified multiple
    /// times.<br/>	(default: "weka.classifiers.rules.ZeroR")<br/>-D = 	If set, classifier
    /// is run in debug mode and<br/>	may output additional info to the
    /// console<br/>-P &lt;path to serialized classifier&gt; = 	Full path to serialized
    /// classifier to include.<br/>	May be specified multiple times to
    /// include<br/>	multiple serialized classifiers. Note: it does<br/>	not make sense to use
    /// pre-built classifiers in<br/>	a cross-validation.<br/>-R
    /// &lt;AVG|PROD|MAJ|MIN|MAX|MED&gt; = 	The combination rule to use<br/>	(default: AVG)
    /// </summary>
    public Vote<T> Vote() { return new Vote<T>(rt); }

    /// <summary>
    /// Wrapper classifier that addresses incompatible training and test data by
    /// building a mapping between the training data that a classifier has been
    /// built with and the incoming test instances' structure. Model attributes that
    /// are not found in the incoming instances receive missing values, so do
    /// incoming nominal attribute values that the classifier has not seen before. A new
    /// classifier can be trained or an existing one loaded from a
    /// file.<br/><br/>Options:<br/><br/>-I = 	Ignore case when matching attribute names and
    /// nominal values.<br/>-M = 	Suppress the output of the mapping report.<br/>-trim =
    /// 	Trim white space from either end of names before matching.<br/>-L &lt;path
    /// to model to load&gt; = 	Path to a model to load. If set, this
    /// model<br/>	will be used for prediction and any base classifier<br/>	specification will
    /// be ignored. Environment variables<br/>	may be used in the path (e.g.
    /// ${HOME}/myModel.model)<br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
    /// classifier.<br/>	(default: weka.classifiers.rules.ZeroR)<br/><br/>Options
    /// specific to classifier weka.classifiers.rules.ZeroR: = <br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console
    /// </summary>
    public InputMappedClassifier<T> InputMappedClassifier() { return new InputMappedClassifier<T>(rt); }

    /// <summary>
    /// A wrapper around a serialized classifier model. This classifier loads a
    /// serialized models and uses it to make predictions.<br/><br/>Warning: since
    /// the serialized model doesn't get changed, cross-validation cannot bet used
    /// with this classifier.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is
    /// run in debug mode and<br/>	may output additional info to the
    /// console<br/>-model &lt;filename&gt; = 	The file containing the serialized
    /// model.<br/>	(required)
    /// </summary>
    public SerializedClassifier<T> SerializedClassifier() { return new SerializedClassifier<T>(rt); }

    /// <summary>
    /// Class for building and using a simple decision table majority
    /// classifier.<br/><br/>For more information see: <br/><br/>Ron Kohavi: The Power of
    /// Decision Tables. In: 8th European Conference on Machine Learning, 174-189,
    /// 1995.<br/><br/>Options:<br/><br/>-S &lt;search method specification&gt; = 	Full
    /// class name of search method, followed<br/>	by its options.<br/>	eg:
    /// "weka.attributeSelection.BestFirst -D 1"<br/>	(default
    /// weka.attributeSelection.BestFirst)<br/>-X &lt;number of folds&gt; = 	Use cross validation to evaluate
    /// features.<br/>	Use number of folds = 1 for leave one out CV.<br/>	(Default
    /// = leave one out CV)<br/>-E &lt;acc | rmse | mae | auc&gt; = 	Performance
    /// evaluation measure to use for selecting attributes.<br/>	(Default = accuracy
    /// for discrete class and rmse for numeric class)<br/>-I = 	Use nearest
    /// neighbour instead of global table majority.<br/>-R = 	Display decision table
    /// rules.<br/><br/><br/>Options specific to search method
    /// weka.attributeSelection.BestFirst: = <br/>-P &lt;start set&gt; = 	Specify a starting set of
    /// attributes.<br/>	Eg. 1,3,5-7.<br/>-D &lt;0 = backward | 1 = forward | 2 =
    /// bi-directional&gt; = 	Direction of search. (default = 1).<br/>-N &lt;num&gt; =
    /// 	Number of non-improving nodes to<br/>	consider before terminating
    /// search.<br/>-S &lt;num&gt; = 	Size of lookup cache for evaluated
    /// subsets.<br/>	Expressed as a multiple of the number of<br/>	attributes in the data set. (default
    /// = 1)
    /// </summary>
    public DecisionTable<T> DecisionTable() { return new DecisionTable<T>(rt); }

    /// <summary>
    /// This class implements a propositional rule learner, Repeated Incremental
    /// Pruning to Produce Error Reduction (RIPPER), which was proposed by William
    /// W. Cohen as an optimized version of IREP. <br/><br/>The algorithm is
    /// briefly described as follows: <br/><br/>Initialize RS = {}, and for each class
    /// from the less prevalent one to the more frequent one, DO: <br/><br/>1.
    /// Building stage:<br/>Repeat 1.1 and 1.2 until the descrition length (DL) of the
    /// ruleset and examples is 64 bits greater than the smallest DL met so far, or
    /// there are no positive examples, or the error rate >= 50%. <br/><br/>1.1.
    /// Grow phase:<br/>Grow one rule by greedily adding antecedents (or conditions)
    /// to the rule until the rule is perfect (i.e. 100% accurate). The procedure
    /// tries every possible value of each attribute and selects the condition with
    /// highest information gain: p(log(p/t)-log(P/T)).<br/><br/>1.2. Prune
    /// phase:<br/>Incrementally prune each rule and allow the pruning of any final
    /// sequences of the antecedents;The pruning metric is (p-n)/(p+n) -- but it's
    /// actually 2p/(p+n) -1, so in this implementation we simply use p/(p+n) (actually
    /// (p+1)/(p+n+2), thus if p+n is 0, it's 0.5).<br/><br/>2. Optimization
    /// stage:<br/> after generating the initial ruleset {Ri}, generate and prune two
    /// variants of each rule Ri from randomized data using procedure 1.1 and 1.2. But
    /// one variant is generated from an empty rule while the other is generated by
    /// greedily adding antecedents to the original rule. Moreover, the pruning
    /// metric used here is (TP+TN)/(P+N).Then the smallest possible DL for each
    /// variant and the original rule is computed. The variant with the minimal DL is
    /// selected as the final representative of Ri in the ruleset.After all the rules
    /// in {Ri} have been examined and if there are still residual positives, more
    /// rules are generated based on the residual positives using Building Stage
    /// again. <br/>3. Delete the rules from the ruleset that would increase the DL
    /// of the whole ruleset if it were in it. and add resultant ruleset to RS.
    /// <br/>ENDDO<br/><br/>Note that there seem to be 2 bugs in the original ripper
    /// program that would affect the ruleset size and accuracy slightly. This
    /// implementation avoids these bugs and thus is a little bit different from Cohen's
    /// original implementation. Even after fixing the bugs, since the order of
    /// classes with the same frequency is not defined in ripper, there still seems
    /// to be some trivial difference between this implementation and the original
    /// ripper, especially for audiology data in UCI repository, where there are
    /// lots of classes of few instances.<br/><br/>Details please
    /// see:<br/><br/>William W. Cohen: Fast Effective Rule Induction. In: Twelfth International
    /// Conference on Machine Learning, 115-123, 1995.<br/><br/>PS. We have compared this
    /// implementation with the original ripper implementation in aspects of
    /// accuracy, ruleset size and running time on both artificial data "ab+bcd+defg"
    /// and UCI datasets. In all these aspects it seems to be quite comparable to the
    /// original ripper implementation. However, we didn't consider memory
    /// consumption optimization in this
    /// implementation.<br/><br/><br/><br/>Options:<br/><br/>-F &lt;number of folds&gt; = 	Set number of folds for REP<br/>	One fold
    /// is used as pruning set.<br/>	(default 3)<br/>-N &lt;min. weights&gt; =
    /// 	Set the minimal weights of instances<br/>	within a split.<br/>	(default
    /// 2.0)<br/>-O &lt;number of runs&gt; = 	Set the number of runs
    /// of<br/>	optimizations. (Default: 2)<br/>-D = 	Set whether turn on the<br/>	debug mode
    /// (Default: false)<br/>-S &lt;seed&gt; = 	The seed of randomization<br/>	(Default:
    /// 1)<br/>-E = 	Whether NOT check the error rate>=0.5<br/>	in stopping criteria
    /// 	(default: check)<br/>-P = 	Whether NOT use pruning<br/>	(default: use
    /// pruning)
    /// </summary>
    public JRip<T> JRip() { return new JRip<T>(rt); }

    /// <summary>
    /// Generates a decision list for regression problems using
    /// separate-and-conquer. In each iteration it builds a model tree using M5 and makes the "best"
    /// leaf into a rule.<br/><br/>For more information see:<br/><br/>Geoffrey
    /// Holmes, Mark Hall, Eibe Frank: Generating Rule Sets from Model Trees. In:
    /// Twelfth Australian Joint Conference on Artificial Intelligence, 1-12,
    /// 1999.<br/><br/>Ross J. Quinlan: Learning with Continuous Classes. In: 5th Australian
    /// Joint Conference on Artificial Intelligence, Singapore, 343-348,
    /// 1992.<br/><br/>Y. Wang, I. H. Witten: Induction of model trees for predicting
    /// continuous classes. In: Poster papers of the 9th European Conference on Machine
    /// Learning, 1997.<br/><br/>Options:<br/><br/>-N = 	Use unpruned
    /// tree/rules<br/>-U = 	Use unsmoothed predictions<br/>-R = 	Build regression tree/rule
    /// rather than a model tree/rule<br/>-M &lt;minimum number of instances&gt; = 	Set
    /// minimum number of instances per leaf<br/>	(default 4)
    /// </summary>
    public M5Rules<T> M5Rules() { return new M5Rules<T>(rt); }

    /// <summary>
    /// Class for building and using a 1R classifier; in other words, uses the
    /// minimum-error attribute for prediction, discretizing numeric attributes. For
    /// more information, see:<br/><br/>R.C. Holte (1993). Very simple
    /// classification rules perform well on most commonly used datasets. Machine Learning.
    /// 11:63-91.<br/><br/>Options:<br/><br/>-B &lt;minimum bucket size&gt; = 	The
    /// minimum number of objects in a bucket (default: 6).
    /// </summary>
    public OneR<T> OneR() { return new OneR<T>(rt); }

    /// <summary>
    /// Class for generating a PART decision list. Uses separate-and-conquer.
    /// Builds a partial C4.5 decision tree in each iteration and makes the "best"
    /// leaf into a rule.<br/><br/>For more information, see:<br/><br/>Eibe Frank, Ian
    /// H. Witten: Generating Accurate Rule Sets Without Global Optimization. In:
    /// Fifteenth International Conference on Machine Learning, 144-151,
    /// 1998.<br/><br/>Options:<br/><br/>-C &lt;pruning confidence&gt; = 	Set confidence
    /// threshold for pruning.<br/>	(default 0.25)<br/>-M &lt;minimum number of
    /// objects&gt; = 	Set minimum number of objects per leaf.<br/>	(default 2)<br/>-R =
    /// 	Use reduced error pruning.<br/>-N &lt;number of folds&gt; = 	Set number of
    /// folds for reduced error<br/>	pruning. One fold is used as pruning
    /// set.<br/>	(default 3)<br/>-B = 	Use binary splits only.<br/>-U = 	Generate unpruned
    /// decision list.<br/>-J = 	Do not use MDL correction for info gain on numeric
    /// attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling (default
    /// 1).
    /// </summary>
    public PART<T> PART() { return new PART<T>(rt); }

    /// <summary>
    /// Class for building and using a 0-R classifier. Predicts the mean (for a
    /// numeric class) or the mode (for a nominal
    /// class).<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
    /// additional info to the console
    /// </summary>
    public ZeroR<T> ZeroR() { return new ZeroR<T>(rt); }

    /// <summary>
    /// Class for building and using a decision stump. Usually used in
    /// conjunction with a boosting algorithm. Does regression (based on mean-squared error)
    /// or classification (based on entropy). Missing is treated as a separate
    /// value.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode
    /// and<br/>	may output additional info to the console
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
    /// precision (in our case, the goodness of an attribute).<br/><br/>A theoretically
    /// appealing feature of Hoeffding Trees not shared by otherincremental
    /// decision tree learners is that it has sound guarantees of performance. Using the
    /// Hoeffding bound one can show that its output is asymptotically nearly
    /// identical to that of a non-incremental learner using infinitely many examples.
    /// For more information see: <br/><br/>Geoff Hulten, Laurie Spencer, Pedro
    /// Domingos: Mining time-changing data streams. In: ACM SIGKDD Intl. Conf. on
    /// Knowledge Discovery and Data Mining, 97-106, 2001.<br/><br/>Options:<br/><br/>-L
    /// = 	The leaf prediction strategy to use. 0 = majority class, 1 = naive
    /// Bayes, 2 = naive Bayes adaptive.<br/>	(default = 0)<br/>-S = 	The splitting
    /// criterion to use. 0 = Gini, 1 = Info gain<br/>	(default = 0)<br/>-E = 	The
    /// allowable error in a split decision - values closer to zero will take longer
    /// to decide<br/>	(default = 1e-7)<br/>-H = 	Threshold below which a split will
    /// be forced to break ties<br/>	(default = 0.05)<br/>-M = 	Minimum fraction
    /// of weight required down at least two branches for info gain
    /// splitting<br/>	(default = 0.01)<br/>-G = 	Grace period - the number of instances a leaf
    /// should observe between split attempts<br/>	(default = 200)<br/>-N = 	The
    /// number of instances (weight) a leaf should observe before allowing naive Bayes
    /// to make predictions (NB or NB adaptive only)<br/>	(default = 0)<br/>-P =
    /// 	Print leaf models when using naive Bayes at the leaves.
    /// </summary>
    public HoeffdingTree<T> HoeffdingTree() { return new HoeffdingTree<T>(rt); }

    /// <summary>
    /// Class for generating a pruned or unpruned C4.5 decision tree. For more
    /// information, see<br/><br/>Ross Quinlan (1993). C4.5: Programs for Machine
    /// Learning. Morgan Kaufmann Publishers, San Mateo,
    /// CA.<br/><br/>Options:<br/><br/>-U = 	Use unpruned tree.<br/>-O = 	Do not collapse tree.<br/>-C
    /// &lt;pruning confidence&gt; = 	Set confidence threshold for pruning.<br/>	(default
    /// 0.25)<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
    /// instances per leaf.<br/>	(default 2)<br/>-R = 	Use reduced error
    /// pruning.<br/>-N &lt;number of folds&gt; = 	Set number of folds for reduced
    /// error<br/>	pruning. One fold is used as pruning set.<br/>	(default 3)<br/>-B = 	Use
    /// binary splits only.<br/>-S = 	Don't perform subtree raising.<br/>-L = 	Do not
    /// clean up after the tree has been built.<br/>-A = 	Laplace smoothing for
    /// predicted probabilities.<br/>-J = 	Do not use MDL correction for info gain on
    /// numeric attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling
    /// (default 1).
    /// </summary>
    public J48<T> J48() { return new J48<T>(rt); }

    /// <summary>
    /// Classifier for building 'logistic model trees', which are classification
    /// trees with logistic regression functions at the leaves. The algorithm can
    /// deal with binary and multi-class target variables, numeric and nominal
    /// attributes and missing values.<br/><br/>For more information see:
    /// <br/><br/>Niels Landwehr, Mark Hall, Eibe Frank (2005). Logistic Model Trees. Machine
    /// Learning. 95(1-2):161-205.<br/><br/>Marc Sumner, Eibe Frank, Mark Hall:
    /// Speeding up Logistic Model Tree Induction. In: 9th European Conference on
    /// Principles and Practice of Knowledge Discovery in Databases, 675-683,
    /// 2005.<br/><br/>Options:<br/><br/>-B = 	Binary splits (convert nominal attributes to
    /// binary ones)<br/>-R = 	Split on residuals instead of class values<br/>-C =
    /// 	Use cross-validation for boosting at all nodes (i.e., disable
    /// heuristic)<br/>-P = 	Use error on probabilities instead of misclassification error for
    /// stopping criterion of LogitBoost.<br/>-I &lt;numIterations&gt; = 	Set fixed
    /// number of iterations for LogitBoost (instead of using
    /// cross-validation)<br/>-M &lt;numInstances&gt; = 	Set minimum number of instances at which a node
    /// can be split (default 15)<br/>-W &lt;beta&gt; = 	Set beta for weight
    /// trimming for LogitBoost. Set to 0 (default) for no weight trimming.<br/>-A = 	The
    /// AIC is used to choose the best iteration.
    /// </summary>
    public LMT<T> LMT() { return new LMT<T>(rt); }

    /// <summary>
    /// M5Base. Implements base routines for generating M5 Model trees and
    /// rules<br/>The original algorithm M5 was invented by R. Quinlan and Yong Wang made
    /// improvements.<br/><br/>For more information see:<br/><br/>Ross J. Quinlan:
    /// Learning with Continuous Classes. In: 5th Australian Joint Conference on
    /// Artificial Intelligence, Singapore, 343-348, 1992.<br/><br/>Y. Wang, I. H.
    /// Witten: Induction of model trees for predicting continuous classes. In:
    /// Poster papers of the 9th European Conference on Machine Learning,
    /// 1997.<br/><br/>Options:<br/><br/>-N = 	Use unpruned tree/rules<br/>-U = 	Use unsmoothed
    /// predictions<br/>-R = 	Build regression tree/rule rather than a model
    /// tree/rule<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
    /// instances per leaf<br/>	(default 4)<br/>-L = 	Save instances at the nodes
    /// in<br/>	the tree (for visualization purposes)
    /// </summary>
    public M5P<T> M5P() { return new M5P<T>(rt); }

    /// <summary>
    /// Fast decision tree learner. Builds a decision/regression tree using
    /// information gain/variance and prunes it using reduced-error pruning (with
    /// backfitting). Only sorts values for numeric attributes once. Missing values are
    /// dealt with by splitting the corresponding instances into pieces (i.e. as in
    /// C4.5).<br/><br/>Options:<br/><br/>-M &lt;minimum number of instances&gt; =
    /// 	Set minimum number of instances per leaf (default 2).<br/>-V &lt;minimum
    /// variance for split&gt; = 	Set minimum numeric class variance
    /// proportion<br/>	of train variance for split (default 1e-3).<br/>-N &lt;number of folds&gt;
    /// = 	Number of folds for reduced error pruning (default 3).<br/>-S
    /// &lt;seed&gt; = 	Seed for random data shuffling (default 1).<br/>-P = 	No
    /// pruning.<br/>-L = 	Maximum tree depth (default -1, no maximum)<br/>-I = 	Initial class
    /// value count (default 0)<br/>-R = 	Spread initial count over all class
    /// values (i.e. don't use 1 per value)
    /// </summary>
    public REPTree<T> REPTree() { return new REPTree<T>(rt); }

    /// <summary>
    /// Class for constructing a forest of random trees.<br/><br/>For more
    /// information see: <br/><br/>Leo Breiman (2001). Random Forests. Machine Learning.
    /// 45(1):5-32.<br/><br/>Options:<br/><br/>-I &lt;number of trees&gt; = 	Number
    /// of trees to build.<br/>-K &lt;number of features&gt; = 	Number of features
    /// to consider (<1=int(logM+1)).<br/>-S = 	Seed for random number
    /// generator.<br/>	(default 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the trees,
    /// 0 for unlimited.<br/>	(default 0)<br/>-print = 	Print the individual trees
    /// in the output<br/>-num-slots &lt;num&gt; = 	Number of execution
    /// slots.<br/>	(default 1 - i.e. no parallelism)<br/>-D = 	If set, classifier is run in
    /// debug mode and<br/>	may output additional info to the console
    /// </summary>
    public RandomForest<T> RandomForest() { return new RandomForest<T>(rt); }

    /// <summary>
    /// Class for constructing a tree that considers K randomly chosen attributes
    /// at each node. Performs no pruning. Also has an option to allow estimation
    /// of class probabilities based on a hold-out set
    /// (backfitting).<br/><br/>Options:<br/><br/>-K &lt;number of attributes&gt; = 	Number of attributes to
    /// randomly investigate<br/>	(<0 = int(log_2(#attributes)+1)).<br/>-M
    /// &lt;minimum number of instances&gt; = 	Set minimum number of instances per
    /// leaf.<br/>-S &lt;num&gt; = 	Seed for random number generator.<br/>	(default
    /// 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the tree, 0 for
    /// unlimited.<br/>	(default 0)<br/>-N &lt;num&gt; = 	Number of folds for backfitting (default 0,
    /// no backfitting).<br/>-U = 	Allow unclassified instances.<br/>-D = 	If set,
    /// classifier is run in debug mode and<br/>	may output additional info to the
    /// console
    /// </summary>
    public RandomTree<T> RandomTree() { return new RandomTree<T>(rt); }

    /// <summary>
    /// No class description found.
    /// </summary>
    public LogisticBase<T> LogisticBase() { return new LogisticBase<T>(rt); }

    
  }
}