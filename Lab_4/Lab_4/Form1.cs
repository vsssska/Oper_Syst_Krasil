using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        Class1 flag1 = new Class1();
        Class1 flag2 = new Class1();

        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(ThreadPriority));
            comboBox2.DataSource = Enum.GetValues(typeof(ThreadPriority));
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
                    this.textBox4.BeginInvoke((MethodInvoker)(() => this.textBox4.Text = $"{Thread.CurrentThread.Priority}"));
                    Console.WriteLine($"{Thread.CurrentThread.Priority}");
                }
                else if (flg.number == 2)
                {
                    this.textBox2.BeginInvoke((MethodInvoker)(() => this.textBox2.Text = $"{flg.counter}"));
                    this.textBox5.BeginInvoke((MethodInvoker)(() => this.textBox5.Text = $"{Thread.CurrentThread.Priority}"));
                    Console.WriteLine($"{Thread.CurrentThread.Priority}");

                }

                Thread.Sleep(1000);
            }
        }


        public void button1_Click(object sender, EventArgs e)
        {
            flag1.flag = true;
            flag1.name = "thread 1";
            flag1.number = 1;
            flag1.priority = ThreadPriority.Highest;


            button1.Visible = false;
            button2.Visible = true;

            Thread thread1 = new Thread(Metod);
            thread1.Priority = ThreadPriority.Highest;
            thread1.Start(flag1);
            button5.Tag = thread1;
            button7.Tag = thread1;
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
            button6.Tag = thread2;
            button8.Tag = thread2;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            flag2.flag = false;

            button4.Visible = false;
            button3.Visible = true;

            textBox2.Text = flag1.counter.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread value = (Thread)button5.Tag;
            Console.WriteLine(value.ThreadState);
            if (value.ThreadState == System.Threading.ThreadState.Suspended)
                value.Resume();
            else
                value.Suspend();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Thread value = (Thread)button6.Tag;
            Console.WriteLine(value.ThreadState);
            if (value.ThreadState == System.Threading.ThreadState.Suspended)
            {

                value.Resume();

            }
            else
            {
                value.Suspend();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThreadPriority selectedState = (ThreadPriority)comboBox1.SelectedItem;
            flag1.priority = selectedState;
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThreadPriority selectedState = (ThreadPriority)comboBox2.SelectedItem;
            flag2.priority = selectedState;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread value = (Thread)button7.Tag;
            value.Priority = flag1.priority;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Thread value = (Thread)button8.Tag;
            value.Priority = flag2.priority;
        }
    }
}
