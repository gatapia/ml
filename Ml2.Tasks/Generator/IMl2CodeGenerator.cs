namespace Ml2.Tasks.Generator
{
  internal interface IMl2CodeGenerator
  {
    string TypeName { get; }
    bool IsSupported { get; }
    string TransformText();
  }
}