using weka.core;

namespace Ml2.AttrSel.Evals
{
  public class Evaluators
  {
        public CfsSubset CfsSubset() { return new CfsSubset(); }
        public CorrelationAttribute CorrelationAttribute() { return new CorrelationAttribute(); }
        public GainRatioAttribute GainRatioAttribute() { return new GainRatioAttribute(); }
        public InfoGainAttribute InfoGainAttribute() { return new InfoGainAttribute(); }
        public OneRAttribute OneRAttribute() { return new OneRAttribute(); }
        public PrincipalComponents PrincipalComponents() { return new PrincipalComponents(); }
        public ReliefFAttribute ReliefFAttribute() { return new ReliefFAttribute(); }
        public SymmetricalUncertAttribute SymmetricalUncertAttribute() { return new SymmetricalUncertAttribute(); }
        public WrapperSubset WrapperSubset() { return new WrapperSubset(); }
        
  }
}