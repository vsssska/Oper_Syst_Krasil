using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

namespace lab7_v4
{
    public partial class Form1 : Form
    {

        private delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        static HookProc KeyboardHandle = new HookProc(KeyboardHookProc);

        private static IntPtr KHook = IntPtr.Zero;
        static HookProc hookProc = new HookProc(KeyboardHookProc);
        

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private static int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x101;
        const int VK_A = 0x41;
        const int VK_B = 0x42;
        static string output;
        static string[] _chars = {"j", "o", "p", "a", " "};
        static int char_flag = 0;

        private static IntPtr InstallHook(int ID, HookProc func)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
                return SetWindowsHookEx(ID, func, GetModuleHandle(curModule.ModuleName), 0);
        }

        
        private static int KeyboardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if(nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int KeyCode = Marshal.ReadInt32(lParam);
                output = $"keyboard[{DateTime.Now}]= {((Keys)KeyCode).ToString()}";
                Console.WriteLine($"{output}\n");

                UnhookWindowsHookEx(KHook);



                SendKeys.SendWait(_chars[char_flag%5]);
                char_flag++;
                start_hook();
                
                

                return 1;

            }

            return CallNextHookEx(KHook, nCode, wParam, lParam);
        }

        private static void start_hook()
        {
            KHook = InstallHook(WH_KEYBOARD_LL, KeyboardHandle);
        }
        private void end_hook()
        {
            UnhookWindowsHookEx(KHook);
            KHook = IntPtr.Zero;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            start_hook();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            end_hook();
        }
    }
}
