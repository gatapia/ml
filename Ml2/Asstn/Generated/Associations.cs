// ReSharper disable once CheckNamespace
namespace Ml2.Asstn
{
  public class Associations<T>
  {
    private readonly Runtime<T> rt;    
    public Associations(Runtime<T> rt) { this.rt = rt; }   

    /// <summary>
    /// Class implementing an Apriori-type algorithm. Iteratively reduces the
    /// minimum support until it finds the required number of rules with the given
    /// minimum confidence. The algorithm has an option to mine class association
    /// rules. It is adapted as explained in the second reference. For more information
    /// see: R. Agrawal, R. Srikant: Fast Algorithms for Mining Association Rules
    /// in Large Databases. In: 20th International Conference on Very Large Data
    /// Bases, 478-499, 1994. Bing Liu, Wynne Hsu, Yiming Ma: Integrating
    /// Classification and Association Rule Mining. In: Fourth International Conference on
    /// Knowledge Discovery and Data Mining, 80-86, 1998.
    /// </summary>
    public Apriori<T> Apriori() { return new Apriori<T>(rt); }

    /// <summary>
    /// Class implementing the FP-growth algorithm for finding large item sets
    /// without candidate generation. Iteratively reduces the minimum support until
    /// it finds the required number of rules with the given minimum metric. For
    /// more information see: J. Han, J.Pei, Y. Yin: Mining frequent patterns without
    /// candidate generation. In: Proceedings of the 2000 ACM-SIGMID International
    /// Conference on Management of Data, 1-12, 2000.
    /// </summary>
    public FPGrowth<T> FPGrowth() { return new FPGrowth<T>(rt); }

    /// <summary>
    /// Class for running an arbitrary associator on data that has been passed
    /// through an arbitrary filter. Like the associator, the structure of the filter
    /// is based exclusively on the training data and test instances will be
    /// processed by the filter without changing their structure.
    /// </summary>
    public FilteredAssociator<T> FilteredAssociator() { return new FilteredAssociator<T>(rt); }

    
  }
}