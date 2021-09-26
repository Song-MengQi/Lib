using System;
using System.IO;

namespace Lib
{
    public class PathManager
    {
        public static Action DirectoryChangedAction { get; set; }
        private static void DirectoryChanged()
        {
            ActionExtends.Invoke(DirectoryChangedAction);
            DirectoryChangedAction = default(Action);
        }

        public const string DataDirectoryDefault = "Data";
        private static string dataDirectory = DataDirectoryDefault;
        public static string DataDirectory
        {
            get { return dataDirectory; }
            set
            {
                if (value != dataDirectory)
                {
                    dataDirectory = value;
                    DirectoryChanged();
                }
            }
        }

        public const string SubDirectoryDefault = "Default";
        public static string subDirectory = SubDirectoryDefault;
        public static string SubDirectory
        {
            get { return subDirectory; }
            set
            {
                if (default(string) == value ||
                    string.IsNullOrWhiteSpace(value = value.Trim(Path.DirectorySeparatorChar)))
                    value = SubDirectoryDefault;
                if (value != subDirectory)
                {
                    subDirectory = value;
                    DirectoryChanged();
                }
            }
        }
        public static string DirectoryDefault { get { return Path.Combine(DataDirectory, SubDirectoryDefault); } }
        public static string Directory { get { return Path.Combine(DataDirectory, SubDirectory); } }
    }
}