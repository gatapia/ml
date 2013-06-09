namespace Ml2.Tasks.Generator
{
  internal interface IMl2CodeGenerator
  {
    string TypeName { get; }
    string TransformText();
  }
}