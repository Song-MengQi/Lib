namespace Lib
{
    public interface IPathManager
    {
        string Directory { get; }
        string DirectoryDefault { get; }
        string ExtensionName { get; }
    }
}