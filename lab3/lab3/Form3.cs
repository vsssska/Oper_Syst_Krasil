using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Class1.SourceFile;
            textBox1.Focus();
            textBox1.Select(0, textBox1.TextLength);
            if (textBox1.Text != null)
            {
                Class1.NewName = textBox1.Text;
                textBox1.Text = null;
                if(File.Exists(Class1.SourceFile))
                {
                    string exten = Path.GetExtension(Class1.SourceFile);
                    Class1.NewName = string.Concat(Path.GetDirectoryName(Class1.SourceFile), @"\", String.Concat(Class1.NewName, exten));
                    File.Move(Class1.SourceFile, Class1.NewName);
                }
                else if(Directory.Exists(Class1.SourceFile))
                {
                    Class1.NewName = string.Concat(Path.GetDirectoryName(Class1.SourceFile), @"\", Class1.NewName);
                    Directory.Move(Class1.SourceFile, Class1.NewName);
                }    
                
                
                
                Close();
            }
        }
    }
}
