namespace Lib.Json
{
    public class ConfigPathManager : StoragePathManagerBase<ConfigPathManager>
    {
    }
    public abstract class ConfigBase<T> : StorageBase<T, ConfigPathManager>
        where T : ConfigBase<T>, new()
    {
    }
}