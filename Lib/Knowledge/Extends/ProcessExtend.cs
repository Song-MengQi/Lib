using System.Diagnostics;

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
            //StreamWriter streamWriter = new StreamWriter(process.StandardInput.BaseStream, Encoding.UTF8);
            //streamWriter.WriteLine(cmd);
            //streamWriter.Close();
            #endregion
            //或者一开始就System.Console.InputEncoding = Encoding.UTF8;
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
    }
}