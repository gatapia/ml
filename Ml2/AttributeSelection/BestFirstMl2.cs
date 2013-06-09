using System;
using weka.attributeSelection;
using weka.core;

namespace Ml2.AttributeSelection
{
  public class BestFirstMl2
  {    
    private readonly BestFirst impl = new BestFirst();    

    private readonly Instances inst;
    private int[] startset;
    private int lookupsize = 1;
    private int numnodes;
    private EDirection direction = EDirection.Forward;

    public BestFirstMl2(Instances inst) { this.inst = inst; }


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
      impl.setDirection(new SelectedTag((int) Direction, BestFirst.TAGS_SELECTION));
      impl.setSearchTermination(numnodes);
      impl.setLookupCacheSize(lookupsize);      
    }
  }
}