using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace lab6
{
    public partial class Form1 : Form
    {
        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowText(IntPtr hWnd, string text);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetCursorPos(ref Point lpPoint);

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }



        public Form1()
        {
            InitializeComponent();
        }

        System.Timers.Timer timer1;
        System.Timers.Timer timer2;
        public delegate void InvokeDelegate();
        public string selitem;

        private void filler()
        {
            listBox1.Items.Clear();
            EnumWindows((hWnd, lParam) => {
                if (IsWindowVisible(hWnd) && GetWindowTextLength(hWnd) != 0)
                {
                    listBox1.Items.Add(GetWindowText(hWnd));
                }
                return true;
            }, IntPtr.Zero);
        }
        private void EventFill(object sender, EventArgs e)
        {
            listBox1.BeginInvoke(new InvokeDelegate(filler));
        }

        private void EventText(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindow(null, selitem);
            SetWindowText(hWnd, textBox1.Text);
            selitem = GetWindowText(hWnd);
        }

        int scale = 1;
        private void EventScale(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1 = new System.Timers.Timer();

            listBox1.Items.Clear();
            trackBar1.TickFrequency= 1;
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 5;

            timer1.Interval= 1000;

            timer1.Elapsed += EventFill;
            timer1.Elapsed += EventText;
            timer1.Elapsed += EventScale;

            timer1.Start();


        }

        string GetWindowText(IntPtr hWnd)
        {
            int len = GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(len);
            len = GetWindowText(hWnd, sb, len);
            return sb.ToString(0, len);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selitem = listBox1.SelectedItem.ToString();
                IntPtr hWnd = FindWindow(null, listBox1.SelectedItem.ToString());
                textBox1.Text = GetWindowText(hWnd);
            }
            catch 
            { 

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            const uint SWP_NOSIZE = 0x0001;
            IntPtr hwnd = FindWindow(null, selitem);
            RECT rc = new RECT();
            GetWindowRect(hwnd, ref rc);

            int width = rc.Right - rc.Left;
            int height = rc.Bottom - rc.Top;
            int x = rc.Left; 
            int y = rc.Top;

            int newWidth = width * trackBar1.Value;
            int newHeight = height * trackBar1.Value;
            SetWindowPos(hwnd, IntPtr.Zero, x, y, newWidth, newHeight, SWP_NOSIZE);


            Console.WriteLine($"{trackBar1.Value.ToString()}, {height}, {width}, {x}, {y}");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Point defPnt = new Point();
            GetCursorPos(ref defPnt);
            Console.WriteLine(defPnt.X+ " " + defPnt.Y);
        }


        private void EventMove(object sender, EventArgs e)
        {
            Point defPnt = new Point();
            IntPtr hwnd= FindWindow(null, selitem);
            GetCursorPos(ref defPnt);

            RECT rc = new RECT();
            GetWindowRect(hwnd, ref rc);

            const uint SWP_NOSIZE = 0x0001;
            int width = rc.Right - rc.Left;
            int height = rc.Bottom - rc.Top;
            int x = rc.Left;
            int y = rc.Top;

            SetWindowPos(hwnd, IntPtr.Zero, defPnt.X, defPnt.Y, width, height, SWP_NOSIZE);
            Console.WriteLine(defPnt.X + " " + defPnt.Y);
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            timer2 = new System.Timers.Timer();
            timer2.Interval= 100;
            timer2.Elapsed += EventMove;
            timer2.Start();
            pictureBox1.Tag= timer2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            timer2.Stop();
        }
    }
}
