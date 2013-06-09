using System;
using weka.attributeSelection;
using weka.core;

namespace Ml2.AttrSel.Algs
{
  /// <summary>
  /// Searches the space of attribute subsets by greedy hillclimbing augmented 
  /// with a backtracking facility. Setting the number of consecutive 
  /// non-improving nodes allowed controls the level of backtracking done. 
  /// Best first may start with the empty set of attributes and search forward, 
  /// or start with the full set of attributes and search backward, or start 
  /// at any point and search in both directions (by considering all possible 
  /// single attribute additions and deletions at a given point).
  /// </summary>
  public class BestFirst
  {    
    private readonly weka.attributeSelection.BestFirst impl = new weka.attributeSelection.BestFirst();    

    private readonly Instances inst;
    private int[] startset;
    private int lookupsize = 1;
    private int numnodes;
    private EDirection direction = EDirection.Forward;

    public BestFirst(Instances inst) { this.inst = inst; }


    /// <summary>
    /// The starting set of attributes.
    /// </summary>
    public int[] Startset { 
      get { return startset; } 
      set
      {
        startset = value;
        FlushOptions();
      }
    }

    /// <summary>
    /// Direction of search (default Forward) 
    /// </summary>
    public EDirection Direction { 
      get { return direction; } 
      set
      {
        direction = value;
        FlushOptions();
      }
    }

    /// <summary>
    /// Number of non-improving nodes to consider 
    /// before terminating search 
    /// </summary>
    public int NumOfNodesLimit { 
      get { return numnodes; } 
      set
      {
        numnodes = value;
        FlushOptions();
      }
    }

    /// <summary>
    /// Size of lookup cache for evaluated subsets. 
    /// Expressed as a multiple of the number of
    /// attributes in the data set. (default = 1)
    /// </summary>
    public int SizeOfLookupCache { 
      get { return lookupsize; } 
      set
      {
        lookupsize = value;
        FlushOptions();
      }
    }

    public int[] Search(IAttributeSelectionEvaluation asevaluation)
    {
      return impl.search(asevaluation.GetImpl(), inst);
    }

    private void FlushOptions()
    {
      impl.setStartSet(String.Join(",", startset));
      impl.setDirection(new SelectedTag((int) Direction, weka.attributeSelection.BestFirst.TAGS_SELECTION));
      impl.setSearchTermination(numnodes);
      impl.setLookupCacheSize(lookupsize);      
    }
  }
}