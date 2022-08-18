using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

namespace Lib.UI
{
    public static class ResourceExtends
    {
        public static ResourceSet GetResourceSet(Assembly assembly)
        {
            return new ResourceManager(assembly.GetName().Name + ".g", assembly)
                .GetResourceSet(CultureInfo.InvariantCulture, true, true);
        }
        public static Stream GetStream(Assembly assembly, string resourceName)
        {
            //return (UnmanagedMemoryStream)new ResourceManager(assembly.GetName().Name + ".g", assembly)
//            return (Stream)new ResourceManager(assembly.GetName().Name + ".g", assembly)
//#region 都行
//                //区别在于是否区分大小写，内部实现是一样的
//                //.GetStream("resource/image/logo.ico", CultureInfo.InvariantCulture);
//#endregion
//                .GetResourceSet(CultureInfo.InvariantCulture, true, true)
            return GetResourceSet(assembly).GetObject(resourceName, true) as Stream;
        }
        public static Stream GetStream(string fileName, string resourceName)
        {
            return GetStream(Assembly.Load(FileExtends.ReadBytes(fileName)), resourceName);
        }
    }
}