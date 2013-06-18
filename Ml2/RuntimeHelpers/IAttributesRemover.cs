namespace Ml2.RuntimeHelpers
{
  public interface IAttributesRemover<T> where T : new() {
    void RemoveAttributes(Runtime<T> rt, params object[] attributes);
  }
}