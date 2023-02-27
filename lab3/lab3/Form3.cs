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
            if (textBox1.Text != null)
            {
                Class1.NewName = textBox1.Text;
                textBox1.Text = null;
                string exten = Path.GetExtension(Class1.SourceFile);
                Class1.NewName = string.Concat(Path.GetPathRoot(Class1.SourceFile), String.Concat(Class1.NewName, exten));
                File.Move(Class1.SourceFile, Class1.NewName);
                Close();
            }
        }
    }
}
