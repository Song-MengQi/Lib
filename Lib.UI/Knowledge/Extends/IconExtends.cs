using System.Collections;
using System.IO;
using System.Reflection;

namespace Lib.UI
{
    public static class IconExtends
    {
        #region Version1
        //图像太小，不清晰
        //public static Icon ExtractAssociatedIcon(string fileName)
        //{
        //    return Icon.ExtractAssociatedIcon(fileName);
        //}
        #endregion
        #region Version2
        //还是不清晰，跟Version1一样
        //private const uint SHGFI_ICON = 0x100;
        //private const uint SHGFI_LARGEICON = 0x0;//32*32
        //private const uint SHGFI_SMALLICON = 0x1;//16*16
        //[StructLayout(LayoutKind.Sequential)]
        //internal struct SHFileInfo
        //{
        //    public IntPtr hIcon;//文件的图标句柄
        //    public IntPtr iIcon;//图标的系统索引号
        //    public uint dwAttributes;//文件的属性值
        //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        //    public string szDisplayName;//文件的显示名
        //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        //    public string szTypeName;//文件的类型名
        //}
        //internal static class NativeMethods
        //{
        //    [DllImport("shell32.dll")]
        //    internal static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFileInfo psfi, uint cbSizeFileInfo, uint uFlags);
        //}
        //public static Icon ExtractAssociatedIcon(string fileName)
        //{
        //    SHFileInfo shinfo = new SHFileInfo();
        //    NativeMethods.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
        //    return Icon.FromHandle(shinfo.hIcon);
        //}
        #endregion
        #region Version3
        //不能确定ResourceName
        //public const string ResourceName = "Resource/Image/Logo.ico";
        //public static Stream GetStream(Assembly assembly)
        //{
        //    return ResourceExtends.GetResourceStream(assembly, ResourceName);
        //}
        //public static Stream GetStream(string fileName)
        //{
        //    return ResourceExtends.GetResourceStream(fileName, ResourceName);
        //}
        #endregion
        public const string ResourceNameSuffixDefault = "logo.ico";
        public static Stream GetStream(Assembly assembly, string resourceNameSuffix = default(string))
        {
            if (string.IsNullOrEmpty(resourceNameSuffix)) resourceNameSuffix = ResourceNameSuffixDefault;
            resourceNameSuffix = resourceNameSuffix.ToLower();
            foreach (DictionaryEntry kv in ResourceExtends.GetResourceSet(assembly))
            {
                if ((kv.Key as string).ToLower().EndsWith(resourceNameSuffix)) return kv.Value as Stream;
            }
            return default(Stream);
        }
        public static Stream GetStream(string fileName, string resourceNameSuffix = default(string))
        {
            return GetStream(Assembly.Load(FileExtends.ReadBytes(fileName)), resourceNameSuffix);
        }
    }
}