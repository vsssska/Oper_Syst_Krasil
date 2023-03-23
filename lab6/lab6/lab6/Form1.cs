using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public Form1()
        {
            InitializeComponent();
            Timer timer = new Timer();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string GetWindowText(IntPtr hWnd)
        {
            int len = GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(len);
            len = GetWindowText(hWnd, sb, len);
            return sb.ToString(0, len);
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindow(null, listBox1.SelectedItem.ToString());
            textBox1.Text = GetWindowText(hWnd);
            SetWindowText(hWnd, "asdasdasd");
        }
    }
}
