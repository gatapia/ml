using System.Linq;
using weka.classifiers.rules;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
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
  public class JRip<T> : BaseClassifier<T, JRip> where T : new()
  {
    public JRip(Runtime<T> rt) : base(rt, new JRip()) {}

    /// <summary>
    /// Determines the amount of data used for pruning. One fold is used for
    /// pruning, the rest for growing the rules.
    /// </summary>    
    public JRip<T> Folds (int fold) {
      ((JRip)Impl).setFolds(fold);
      return this;
    }

    /// <summary>
    /// The minimum total weight of the instances in a rule.
    /// </summary>    
    public JRip<T> MinNo (double m) {
      ((JRip)Impl).setMinNo(m);
      return this;
    }

    /// <summary>
    /// The number of optimization runs.
    /// </summary>    
    public JRip<T> Optimizations (int run) {
      ((JRip)Impl).setOptimizations(run);
      return this;
    }

    /// <summary>
    /// Whether debug information is output to the console.
    /// </summary>    
    public JRip<T> Debug (bool d) {
      ((JRip)Impl).setDebug(d);
      return this;
    }

    /// <summary>
    /// Whether check for error rate >= 1/2 is included in stopping criterion.
    /// </summary>    
    public JRip<T> CheckErrorRate (bool d) {
      ((JRip)Impl).setCheckErrorRate(d);
      return this;
    }

    /// <summary>
    /// Whether pruning is performed.
    /// </summary>    
    public JRip<T> UsePruning (bool d) {
      ((JRip)Impl).setUsePruning(d);
      return this;
    }

        
        
  }
}