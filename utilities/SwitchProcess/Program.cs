using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Configuration;

namespace SwitchProcess
{
    class Program
    {

        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_MAXIMIZE = 3;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(int hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(int hWnd, StringBuilder title, int size);


        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        public static List<IntPtr> GetMainWindowHandle(string processname)
        {
            var list = Process.GetProcessesByName(processname);

            List<IntPtr> windowList = new List<IntPtr>();

            foreach (Process process in list)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                //windowList.Add(ThisProcess.MainWindowHandle);
                {
                    foreach (ProcessThread processThread in process.Threads)
                    {
                        EnumThreadWindows(processThread.Id,
                         (hWnd, lParam) =>
                         {
                     //Check if Window is Visible or not.
                     if (!IsWindowVisible((int)hWnd))
                                 return true;

                     //Get the Window's Title.
                     StringBuilder title = new StringBuilder(256);
                             GetWindowText((int)hWnd, title, 256);

                     //Check if Window has Title.
                     if (title.Length == 0)
                                 return true;

                             windowList.Add(hWnd);

                             return true;
                         }, IntPtr.Zero);
                    }
                }
            }

            return windowList;
        }


        static void Main(string[] args)
        {


            string processname = ConfigurationSettings.AppSettings["processname"].ToString();
            int interval = int.Parse(ConfigurationSettings.AppSettings["interval"].ToString());

            Console.WriteLine($"Starting SwitchProcess [{processname}] interval [{interval}]");

            Thread.Sleep(3000);
            
            while (true)
            {

                try
                {
                    var l = GetMainWindowHandle(processname).OrderBy(t => t.ToString());
                       
                    foreach (var w in l)
                    {
                        try
                        {
                            Console.WriteLine($"Switched to {w}");

                            ShowWindow(w, SW_MAXIMIZE);
                            SetForegroundWindow(w);
                            SwitchToThisWindow(w, true);

                            Thread.Sleep(interval);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fail Switched to {w} ex: {ex.Message}");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fail ex: {ex.Message}");
                }

                Thread.Sleep(5000);


            }


        }
    }
}
