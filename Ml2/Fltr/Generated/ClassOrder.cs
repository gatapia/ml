using weka.filters.supervised.attribute;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Changes the order of the classes so that the class values are no longer
  /// of in the order specified in the header. The values will be in the order
  /// specified by the user -- it could be either in ascending/descending order by
  /// the class frequency or in random order. Note that this filter currently does
  /// not change the header, only the class values of the instances, so there is
  /// not much point in using it in conjunction with the FilteredClassifier. The
  /// value can also be converted back using 'originalValue(double value)'
  /// procedure.<br/><br/>Options:<br/><br/>-R &lt;seed&gt; = 	Specify the seed of
  /// randomization<br/>	used to randomize the class<br/>	order (default: 1)<br/>-C
  /// &lt;order&gt; = 	Specify the class order to be<br/>	sorted, could be 0:
  /// ascending<br/>	1: descending and 2: random.(default: 0)
  /// </summary>
  public class ClassOrder<T> : BaseFilter<T, ClassOrder> where T : new()
  {
    public ClassOrder(Runtime<T> rt) : base(rt, new ClassOrder()) {}

    /// <summary>
    /// Specify the seed of randomization of the class order
    /// </summary>    
    public ClassOrder<T> Seed (long seed) {
      ((ClassOrder)Impl).setSeed(seed);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public ClassOrder<T> SetClassOrder (int order) {
      ((ClassOrder)Impl).setClassOrder(order);
      return this;
    }

        
        
  }
}