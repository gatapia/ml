namespace Ml2.Clss
{
  public class Classifiers<T> where T : new()
  {
    private readonly Runtime<T> rt;

    public Classifiers(Runtime<T> rt) { this.rt = rt; }

    public ClassifiersBayes<T> Bayes { get { return new ClassifiersBayes<T>(rt); } }
    public ClassifiersBayesNet<T> BayesNet { get { return new ClassifiersBayesNet<T>(rt); } }
    public ClassifiersFunctions<T> Functions { get { return new ClassifiersFunctions<T>(rt); } }
    public ClassifiersLazy<T> Lazy { get { return new ClassifiersLazy<T>(rt); } }
    public ClassifiersMeta<T> Meta { get { return new ClassifiersMeta<T>(rt); } }
    public ClassifiersMisc<T> Misc { get { return new ClassifiersMisc<T>(rt); } }
    public ClassifiersRules<T> Rules { get { return new ClassifiersRules<T>(rt); } }
    public ClassifiersTrees<T> Trees { get { return new ClassifiersTrees<T>(rt); } }
    public ClassifiersTreesLmt<T> TreesLmt { get { return new ClassifiersTreesLmt<T>(rt); } }
  }
}