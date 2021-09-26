using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lib
{
    public static class ProcessExtends
    {
        #region CMD
        public static Process StartCMD()
        {
            Process process = Process.Start(
                new ProcessStartInfo("cmd.exe") {
                    WindowStyle = ProcessWindowStyle.Hidden,//不显示窗口
                    UseShellExecute = false,//要重定向标准流
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    //StandardInputEncoding = Encoding.UTF8,//只有.Net Core支持
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                });
            //process.StandardInput.AutoFlush = true;//本来就是
            //当数据量过大的时候，必须在流上开始异步读取，否则进程将挂起
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return process;
        }
        public static Process ExecuteAsync(string cmd)
        {
            return StartCMD().ExecuteAsync(cmd);
        }
        public static void Execute(string cmd)
        {
            ExecuteAsync(cmd).Wait();
        }
        #endregion
        #region AsAdmin
        public static Process StartAsAdmin(string fileName, string arguments)
        {
            return Process.Start(
                new ProcessStartInfo(fileName, arguments) {
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    Verb = "RunAs"
                });
        }
        #endregion
        public static bool Exist(string name)
        {
            return Process.GetProcessesByName(name).Any();
        }
        public static void Kill(string name)
        {
            Process.GetProcessesByName(name)
                .Foreach(process=>{
                    process.Kill();
                    process.WaitForExit();
                });
        }
    }
}