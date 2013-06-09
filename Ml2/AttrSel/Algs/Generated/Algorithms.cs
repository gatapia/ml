using weka.core;

namespace Ml2.AttrSel.Algs
{
  public class Algorithms
  {
    private readonly Instances inst;    
    public Algorithms(Instances inst) { this.inst = inst; }   

        public BestFirst BestFirst() { return new BestFirst(inst); }
        public GreedyStepwise GreedyStepwise() { return new GreedyStepwise(inst); }
        public Ranker Ranker() { return new Ranker(inst); }
        
  }
}