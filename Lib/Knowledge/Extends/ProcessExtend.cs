using System;
using System.Diagnostics;
using System.Threading;

namespace Lib
{
    public static class ProcessExtend
    {
        public static void Wait(this Process process)
        {
            process.WaitForExit();
            process.Dispose();
        }
        public static Process ExecuteAsync(this Process process, string cmd)
        {
            //ProcessStartInfo.StandardInputEncoding只有.Net Core支持
            #region 使用StreamWriter指定UTF8
            //StreamWriter streamWriter = new StreamWriter(process.StandardInput.BaseStream, Encodings.UTF8);
            //streamWriter.WriteLine(cmd);
            //streamWriter.Close();
            #endregion
            //或者一开始就System.Console.InputEncoding = Encodings.UTF8;
            process.StandardInput.WriteLine(cmd);
            //process.StandardInput.WriteLine("exit");
            //process.StandardInput.Flush();
            process.StandardInput.Close();
            return process;
        }
        public static void Execute(this Process process, string cmd)
        {
            process.ExecuteAsync(cmd).Wait();
        }

        #region GetParent
        private static string GetIndexedProcessName(int processId)
        {
            string processName = Process.GetProcessById(processId).ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);
            for (int i = 0; i < processes.Length; i++)
            {
                string processIndexdName = i == 0 ? processName : string.Join("#", processName, i);
                if ((int)new PerformanceCounter("Process", "ID Process", processIndexdName).NextValue() == processId)
                {
                    return processIndexdName;
                }
            }
            return default(string);
        }
        private static Process GetProcessByIndexedProcessName(string indexedProcessName)
        {
            return Process.GetProcessById((int)new PerformanceCounter("Process", "Creating Process ID", indexedProcessName).NextValue());
        }
        public static Process GetParent(this Process process)
        {
            //若父进程不是普通进程，则为explorer。
            return GetProcessByIndexedProcessName(GetIndexedProcessName(process.Id));
        }
        #endregion

        public static string CMDInteract(this Process process, string cmd, TimeSpan runTimeSpan, Func<string, bool> filterFunc = default(Func<string, bool>))
        {
            string result = default(string);
            string start = string.Format("{0}>{1}", process.StartInfo.WorkingDirectory.TrimEnd('\\'), cmd);
            bool isInputTrimmed = false;
            using (ManualResetEventSlim manualResetEventSlim = new ManualResetEventSlim(false))
            {
                process.OutputDataReceived+=(sender, e)=>{
                    string str = e.Data;
                    if (string.IsNullOrEmpty(str)) return;
                    if (false == isInputTrimmed && str.StartsWith(start))//第一句没用
                    {
                        isInputTrimmed = true;
                        str = str.TrimOnceStart(start);
                    }
                    str = str.Trim();
                    if (string.IsNullOrEmpty(str)) return;
                    if (default(Func<string, bool>) != filterFunc && false == filterFunc(str)) return;//如果不是想要的

                    result = str;
                    manualResetEventSlim.Set();
                };
                process.StandardInput.WriteLine(cmd);
                manualResetEventSlim.Wait(runTimeSpan);//等process执行，把要反馈的信息打完
            }
            return result;
        }
    }
}