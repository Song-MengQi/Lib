namespace Lib.Json
{
    public static class FileExtends
    {
        public static T LoadJson<T>(string fileName)
        {
            return Jsons.Deserialize<T>(Lib.FileExtends.ReadText(fileName));
        }
        public static void SaveJson<T>(string fileName, T t)
        {
            Lib.FileExtends.WriteText(fileName, Jsons.Serialize(t));
        }
    }
}