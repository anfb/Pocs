using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoGetForegroundWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static int processIDAux;
        [DllImport("user32.dll")]
        private static extern int GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(int windowHandle, out uint processID);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindow(int hWnd, uint wCmd);

        public delegate void Callback();

        // Identifies the window below the specified window in the Z order.
        const int GW_HWNDNEXT = 2;
        //Current HwndForegroundWindowProcessber to check
        private int HwndForegroundWindowProcess;

        private bool continueChecking = false;

        String appName;

        public MainWindow() : base()
        { 
            InitializeComponent();
            HwndForegroundWindowProcess = GetForegroundWindow();
            appName = GetProcessIDAndName(HwndForegroundWindowProcess);
            process.Text = appName;
        }

        private void StartOrStop(object sender, EventArgs e)
        {
            if (continueChecking)
            {
                continueChecking = false;
                startStopButton.Content = "Resume";
            }
            else
            {
                continueChecking = true;
                startStopButton.Content = "Stop";
                startStopButton.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Callback(CheckSwitchingApp));
            }
        }

        public void CheckSwitchingApp()
        {
            int processHwnd = GetForegroundWindow();
            process.Text = GetProcessIDAndName(processHwnd);
     
            if (continueChecking)
            {
                startStopButton.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.SystemIdle,
                    new Callback(this.CheckSwitchingApp));
            }
        }

        private string GetProcessIDAndName(int HwndFgWindowProc)
        {
            if(HwndFgWindowProc != HwndForegroundWindowProcess)
            {
                uint processID = 0;
                uint threadID = GetWindowThreadProcessId(HwndFgWindowProc, out processID);
                Process fgProc = Process.GetProcessById(Convert.ToInt32(processID));

                 uint processIDNextWnd = 0;
                 int hNextWnd = GetWindow(HwndFgWindowProc, GW_HWNDNEXT);
                 uint threadIDNextWnd = GetWindowThreadProcessId(hNextWnd, out processIDNextWnd);
                 Process nextFgProc = Process.GetProcessById(Convert.ToInt32(processIDNextWnd));
                 return "Process ID: " + fgProc.Id.ToString() + "\n Process Name: " + fgProc.ProcessName + "\n Wnd Title: " + fgProc.MainWindowTitle + "\n" + "\n Next Wnd ID: " + nextFgProc.Id.ToString() + "\n Next Wnd Proc Name: " + nextFgProc.ProcessName + "\n Next Wnd Title: " + nextFgProc.MainWindowTitle;
                 

                //return "Process ID: " + fgProc.Id + "\n Process Name: " + fgProc.ProcessName + "\n Wnd Title: " + fgProc.MainWindowTitle + "\n Main Wnd Handle: " + fgProc.MainWindowHandle;
            }

            return appName;
        }      

    }
}
