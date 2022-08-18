namespace Lib.Json
{
    public static class FileExtends
    {
        public static T LoadJson<T>(string fileName)
        {
            return JsonExtends.Deserialize<T>(Lib.FileExtends.ReadText(fileName));
        }
        public static void SaveJson<T>(string fileName, T t)
        {
            Lib.FileExtends.WriteText(fileName, JsonExtends.Serialize(t));
        }
    }
}