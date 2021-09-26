using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Lib.UI
{
    public static class WindowExtend
    {
        public static void RepairFullScreenBehavior(this Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
                window.Loaded += delegate { window.WindowState = WindowState.Maximized; };
            }
            window.SourceInitialized += delegate {
                HwndSource hwndSource = HwndSource.FromHwnd(new WindowInteropHelper(window).Handle);
                if (default(HwndSource) == hwndSource) return;
                hwndSource.AddHook(WindowProc);
            };
        }
        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WMGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }
            return default(IntPtr);
        }
        private static void WMGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            IntPtr monitor = NativeMethods.MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
            if (default(IntPtr) == monitor) return;

            MonitorInfo monitorInfo = new MonitorInfo();
            NativeMethods.GetMonitorInfo(monitor, monitorInfo);
            Rect workRect = monitorInfo.WorkRect;
            Rect monitorRect = monitorInfo.MonitorRect;

            MinMaxInfo mmInfo = (MinMaxInfo)Marshal.PtrToStructure(lParam, typeof(MinMaxInfo));
            mmInfo.MaxPosition.X = Math.Abs(monitorRect.Left - workRect.Left);
            mmInfo.MaxPosition.Y = Math.Abs(monitorRect.Top - workRect.Top);
            mmInfo.MaxSize.X = Math.Abs(workRect.Right - workRect.Left);
            mmInfo.MaxSize.Y = Math.Abs(workRect.Bottom - workRect.Top);
            Marshal.StructureToPtr(mmInfo, lParam, true);
        }
        #region internal
        internal static class NativeMethods
        {
            [DllImport("user32")]
            internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
            [DllImport("user32")]
            internal static extern bool GetMonitorInfo(IntPtr hMonitor, MonitorInfo lpmi);
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct MinMaxInfo
        {
            public Point Reserved;
            public Point MaxSize;
            public Point MaxPosition;
            public Point MinTrackSize;
            public Point MaxTrackSize;
        };
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class MonitorInfo
        {
            public int Size = Marshal.SizeOf(typeof(MonitorInfo));
            public Rect MonitorRect;
            public Rect WorkRect;
            public int Flags;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct Point
        {
            public int X;
            public int Y;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        internal struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        #endregion
    }
}
