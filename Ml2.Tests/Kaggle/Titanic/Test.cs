using NUnit.Framework;
using java.io;
using weka.core.converters;

namespace Ml2.Tests.Kaggle.Titanic
{
  [TestFixture] public class Test
  {
    [Test] public void Test1()
    {
      var rt = new Runtime();
      rt.Load<TitanicDataRow>(@"resources\kaggle\titanic\train.csv");

      const string outf = "out.arff";
      
      if (System.IO.File.Exists(outf))System.IO.File.Delete(outf);      
      var saver = new ArffSaver();
      saver.setInstances(rt.Instances);
      saver.setFile(new File(outf));
      saver.writeBatch();

    }
  }
}