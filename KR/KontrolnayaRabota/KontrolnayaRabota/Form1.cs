using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KontrolnayaRabota
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int copCount = 0;

        async void CopyFileEvent(string sourceFile)
        {
            try
            {
                if (File.Exists(sourceFile))
                {
                    string destFile;
                    for (int i = 1; i <= copCount; i++)
                    {
                        destFile = string.Concat(Path.GetDirectoryName(sourceFile), "\\", Path.GetFileNameWithoutExtension(sourceFile), i.ToString(), Path.GetExtension(sourceFile));
                        await Task.Run(() =>
                        {
                            File.Copy(sourceFile, destFile, true);
                        });
                        
                    }
                }
            }
            catch 
            { 

            }
            button1.Visible = true;
            
        }


        string sourcefile;
        private void button1_Click(object sender, EventArgs e)
        {
            if(copCount > 0)
            {
                if (File.Exists(sourcefile))
                {
                    copCount = Convert.ToInt32(textBox1.Text);
                    CopyFileEvent(sourcefile);
                    button1.Visible = false;
                }
                
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if(!Char.IsDigit(number) )
            {
                e.Handled= true;
            }
        }

        private void fileselecter_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    sourcefile= ofd.FileName;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1";
        }
    }
}
