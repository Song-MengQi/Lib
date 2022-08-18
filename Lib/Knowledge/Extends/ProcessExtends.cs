using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Lib
{
    public static class ProcessExtends
    {
        #region CMD，注意它起的实际上是CMD进程
        public static Process StartCMD(string workingDirectory = "")
        {
            Process process = Process.Start(
                new ProcessStartInfo("cmd.exe") {
                    WorkingDirectory = workingDirectory,
                    WindowStyle = ProcessWindowStyle.Hidden,//不显示窗口
                    UseShellExecute = false,//要重定向标准流
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    //StandardInputEncoding = Encodings.UTF8,//只有.Net Core支持
                    StandardOutputEncoding = Encodings.UTF8,
                    StandardErrorEncoding = Encodings.UTF8
                });
            //process.StandardInput.AutoFlush = true;//本来就是
            //当数据量过大的时候，必须在流上开始异步读取，否则进程将挂起
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.StandardInput.WriteLine("chcp 65001");
            return process;
        }
        public static Process ExecuteAsync(string cmd, string workingDirectory = "")
        {
            return StartCMD(workingDirectory).ExecuteAsync(cmd);
        }
        public static void Execute(string cmd, string workingDirectory = "")
        {
            ExecuteAsync(cmd, workingDirectory).Wait();
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
        public static string CMDInteract(string cmd, TimeSpan runTimeSpan, Func<string, bool> filterFunc = default(Func<string, bool>))
        {
            Process process = ProcessExtends.StartCMD();//默认工作目录就是AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            Thread.Sleep(TimeSpan.FromSeconds(0.1d));//等process启起来，把没用的信息打完

            string result = process.CMDInteract(cmd, runTimeSpan, filterFunc);

            process.CancelOutputRead();//如果此刻不关闭，则下一步Close后，还会收到一句
            process.StandardInput.Close();
            process.WaitForExit();

            return result;
        }
    }
}