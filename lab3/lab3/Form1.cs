using System;
using System.IO;
using System.Collections;
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
            try
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
                else if (Directory.Exists(sourceFile))
                {
                    await Task.Run(() =>
                    {
                        
                        Directory.Move(sourceFile, Path.Combine(destFile, Path.GetFileName(sourceFile)));
                    });
                }
            }
            catch(Exception ex)
            {

            }
            
            disfile = null;
            sourceFile = null;
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);
            
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            
            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destinationDir);
            
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }
            
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        private async void copyEvent(string sourceFile, string destFile)
        {
            try
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
                                File.Copy(sourceFile, destFile, true);
                            });
                        }
                    }
                    else if (!File.Exists(destFile))
                    {
                        await Task.Run(() =>
                        {
                            File.Copy(sourceFile, destFile, true);
                        });
                    }

                }
                else if (Directory.Exists(sourceFile))
                {
                    CopyDirectory(sourceFile, destFile, true);
                }
            }
            catch (Exception ex)
            {

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
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    sourcePath = ofd.SafeFileName;
                    disfile = Path.GetFullPath(ofd.FileName);
                    textBox1.Text = disfile;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) 
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    despitePath = Path.GetFullPath(fbd.SelectedPath);
                    if (File.Exists(sourcePath))
                        despitePath = Path.Combine(despitePath, sourcePath);
                    textBox2.Text = despitePath;
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(disfile))
                moveEvent(disfile, despitePath);
            else if (Directory.Exists(disfile))
                moveEvent(disfile, despitePath);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists(disfile))
                copyEvent(disfile, despitePath);
            else if(Directory.Exists(disfile))
                copyEvent(disfile,despitePath);
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
            else if (Directory.Exists(disfile))
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
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    disfile = fbd.SelectedPath;
                    textBox1.Text = disfile;
                }
            }
        }
    }
}
