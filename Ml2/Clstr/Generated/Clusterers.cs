// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  public class Clusterers<T>
  {
    private readonly Runtime<T> rt;    
    public Clusterers(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// Class implementing the Cobweb and Classit clustering algorithms. Note:
    /// the application of node operators (merging, splitting etc.) in terms of
    /// ordering and priority differs (and is somewhat ambiguous) between the original
    /// Cobweb and Classit papers. This algorithm always compares the best host,
    /// adding a new leaf, merging the two best hosts, and splitting the best host
    /// when considering where to place a new instance. For more information see: D.
    /// Fisher (1987). Knowledge acquisition via incremental conceptual clustering.
    /// Machine Learning. 2(2):139-172. J. H. Gennari, P. Langley, D. Fisher
    /// (1990). Models of incremental concept formation. Artificial Intelligence.
    /// 40:11-61.
    /// </summary>
    public Cobweb<T> Cobweb() { return new Cobweb<T>(rt); }

    /// <summary>
    /// Simple EM (expectation maximisation) class. EM assigns a probability
    /// distribution to each instance which indicates the probability of it belonging
    /// to each of the clusters. EM can decide how many clusters to create by cross
    /// validation, or you may specify apriori how many clusters to generate. The
    /// cross validation performed to determine the number of clusters is done in
    /// the following steps: 1. the number of clusters is set to 1 2. the training
    /// set is split randomly into 10 folds. 3. EM is performed 10 times using the 10
    /// folds the usual CV way. 4. the loglikelihood is averaged over all 10
    /// results. 5. if loglikelihood has increased the number of clusters is increased
    /// by 1 and the program continues at step 2. The number of folds is fixed to
    /// 10, as long as the number of instances in the training set is not smaller 10.
    /// If this is the case the number of folds is set equal to the number of
    /// instances.
    /// </summary>
    public EM<T> EM() { return new EM<T>(rt); }

    /// <summary>
    /// Cluster data using the FarthestFirst algorithm. For more information see:
    /// Hochbaum, Shmoys (1985). A best possible heuristic for the k-center
    /// problem. Mathematics of Operations Research. 10(2):180-184. Sanjoy Dasgupta:
    /// Performance Guarantees for Hierarchical Clustering. In: 15th Annual Conference
    /// on Computational Learning Theory, 351-363, 2002. Notes: - works as a fast
    /// simple approximate clusterer - modelled after SimpleKMeans, might be a
    /// useful initializer for it
    /// </summary>
    public FarthestFirst<T> FarthestFirst() { return new FarthestFirst<T>(rt); }

    /// <summary>
    /// Class for running an arbitrary clusterer on data that has been passed
    /// through an arbitrary filter. Like the clusterer, the structure of the filter
    /// is based exclusively on the training data and test instances will be
    /// processed by the filter without changing their structure.
    /// </summary>
    public Filtered<T> Filtered() { return new Filtered<T>(rt); }

    /// <summary>
    /// Hierarchical clustering class. Implements a number of classic
    /// agglomorative (i.e. bottom up) hierarchical clustering methodsbased on .
    /// </summary>
    public Hierarchical<T> Hierarchical() { return new Hierarchical<T>(rt); }

    /// <summary>
    /// Class for wrapping a Clusterer to make it return a distribution and
    /// density. Fits normal distributions and discrete distributions within each
    /// cluster produced by the wrapped clusterer. Supports the
    /// NumberOfClustersRequestable interface only if the wrapped Clusterer does.
    /// </summary>
    public MakeDensityBased<T> MakeDensityBased() { return new MakeDensityBased<T>(rt); }

    /// <summary>
    /// Cluster data using the k means algorithm. Can use either the Euclidean
    /// distance (default) or the Manhattan distance. If the Manhattan distance is
    /// used, then centroids are computed as the component-wise median rather than
    /// mean. For more information see: D. Arthur, S. Vassilvitskii: k-means++: the
    /// advantages of carefull seeding. In: Proceedings of the eighteenth annual
    /// ACM-SIAM symposium on Discrete algorithms, 1027-1035, 2007.
    /// </summary>
    public SimpleKMeans<T> SimpleKMeans() { return new SimpleKMeans<T>(rt); }

    
  }
}