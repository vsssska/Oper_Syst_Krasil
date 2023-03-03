using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "Вошел1";
            button2.Text = "Вышел2";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "baton1";
            button2.Text = "baton2";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Text = "Вошел2";
            button1.Text = "Вышел1";
        }

        private void button2_DragLeave(object sender, EventArgs e)
        {
            
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "baton1";
            button2.Text = "baton2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num1 = textBox1.Text;
            double num2 = Convert.ToDouble(num1);
            num2 *= 2;
            num1 = Convert.ToString(num2);
            textBox1.Text = num1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string num3 = textBox1.Text;
            double num4 = Convert.ToDouble(num3);
            num4 /= 2;
            num3 = Convert.ToString(num4);
            textBox1.Text = num3;
        }
    }
}
