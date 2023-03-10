using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        
        

        private void Metod(object flags)
        {
            Class1 flg = flags as Class1;

            flg.counter = 0;
            while(flg.flag)
            {
              this.textBox3.BeginInvoke((MethodInvoker)(() => this.textBox3.Text = $"{flg.name}"));
              flg.counter++;
              if(flg.number == 1)
                {
                    this.textBox1.BeginInvoke((MethodInvoker)(() => this.textBox1.Text = $"{flg.counter}"));
                }
              else if (flg.number == 2)
                {
                    this.textBox2.BeginInvoke((MethodInvoker)(() => this.textBox2.Text = $"{flg.counter}"));
                }
              Thread.Sleep(100);    
            }
        }

        Class1 flag1 = new Class1();
        Class1 flag2 = new Class1();

        public void button1_Click(object sender, EventArgs e)
        {
            
            flag1.flag = true;
            flag1.name = "thread 1";
            flag1.number = 1;
            

            button1.Visible = false;
            button2.Visible = true;

            Thread thread1 = new Thread(Metod);
            thread1.Start(flag1);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            button2.Visible = false;
            button1.Visible = true;
            flag1.flag = false;
            textBox1.Text = flag1.counter.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag2.flag= true;
            flag2.name = "thread 2";
            flag2.number = 2;

            button3.Visible = false;
            button4.Visible = true;
            
            Thread thread2 = new Thread(Metod);
            thread2.Start(flag2);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flag2.flag = false;

            button4.Visible = false;
            button3.Visible = true;

            textBox2.Text = flag1.counter.ToString();
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }
}
