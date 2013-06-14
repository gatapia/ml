using System.Linq;
using weka.classifiers.lazy;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
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
  public class KStar<T> : BaseClassifier<T, KStar> where T : new()
  {
    public KStar(Runtime<T> rt) : base(rt, new KStar()) {}

    /// <summary>
    /// The parameter for global blending. Values are restricted to [0,100].
    /// </summary>    
    public KStar<T> GlobalBlend (int b) {
      ((KStar)Impl).setGlobalBlend(b);
      return this;
    }

    /// <summary>
    /// Whether entropy-based blending is to be used.
    /// </summary>    
    public KStar<T> EntropicAutoBlend (bool e) {
      ((KStar)Impl).setEntropicAutoBlend(e);
      return this;
    }

    /// <summary>
    /// Determines how missing attribute values are treated.
    /// </summary>    
    public KStar<T> MissingMode (EMissingMode newMode) {
      ((KStar)Impl).setMissingMode(new weka.core.SelectedTag((int) newMode, KStar.TAGS_MISSING));
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public KStar<T> Debug (bool debug) {
      ((KStar)Impl).setDebug(debug);
      return this;
    }

        
    public enum EMissingMode {
      Ignore_the_instances_with_missing_values = 1,
      Treat_missing_values_as_maximally_different = 2,
      Normalize_over_the_attributes = 3,
      Average_column_entropy_curves = 4
    }

        
  }
}