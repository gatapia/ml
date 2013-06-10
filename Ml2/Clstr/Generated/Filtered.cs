using weka.clusterers;

namespace Ml2.Clstr.Generated
{
  /// <summary>
  /// Class for running an arbitrary clusterer on data that has been passed
  /// through an arbitrary filter. Like the clusterer, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their structure.
  /// </summary>
  public class Filtered<T> : BaseClusterer<T>
  {
    private readonly FilteredClusterer impl = new FilteredClusterer();
    
    public Filtered(Runtime<T> rt) : base(rt) {}

        

    public override IClusterer<T> Build()
    {
      impl.buildClusterer(rt.Instances);
      return this;
    }

    public override int Classify(T row) { return impl.clusterInstance(rt.GetRowInstance(row)); }
  }
}