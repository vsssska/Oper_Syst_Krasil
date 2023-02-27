using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Diagnostics;

namespace lab3
{
    public partial class Form1 : Form
    {
        public string sourcePath;
        public string despitePath;
        public string disfile;
        public string sourceDirect;
        private async void moveEvent(string sourceFile, string destFile)
        {
            if (File.Exists(sourceFile))
            {
                if (File.Exists(destFile))
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    if (Class1.Request == true)
                    {
                        await Task.Run(() =>
                        {
                            File.Move(sourceFile, destFile);
                        });
                    }
                }
                else
                {
                    await Task.Run(() =>
                    {
                        File.Move(sourceFile, destFile);
                    });
                }
            }
            disfile = null;
            sourceFile = null;
        }

        private async void copyEvent(string sourceFile, string destFile)
        {
            if(File.Exists(sourceFile))
            {
                if (File.Exists(destFile))
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    if (Class1.Request == true)
                    {
                        await Task.Run(() =>
                        {
                            File.Copy(sourceFile, destFile, true);
                        });
                    }
                }
                else
                {
                    await Task.Run(() =>
                    {
                        File.Copy(sourceFile, destFile);
                    });
                }
            }
            disfile = null;
            sourceFile = null;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            sourcePath = ofd.SafeFileName;
            disfile = Path.GetFullPath(ofd.FileName);
            textBox1.Text = disfile;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            despitePath = Path.GetFullPath(fbd.SelectedPath);
            despitePath = Path.Combine(despitePath, sourcePath);
            textBox2.Text = despitePath;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(disfile))
                moveEvent(disfile, despitePath);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists(disfile))
                copyEvent(disfile, despitePath);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (File.Exists(disfile))
            {
                Form3 form3 = new Form3();
                Class1.SourceFile = disfile;
                form3.Show();
                textBox1.Text = Class1.NewName;
                disfile = null;
            }

        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            sourceDirect = fbd.SelectedPath;
            textBox1.Text = sourceDirect;
        }
    }
}
