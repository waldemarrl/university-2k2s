using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                FileStream fileStream = new FileStream("file.txt", FileMode.OpenOrCreate);
                fileStream.Close();
                
                StreamWriter streamWriter = new StreamWriter("file.txt");
                string sw = textBox1.Text;
                streamWriter.WriteLine(sw);
                streamWriter.Close();
            }
            else
            {
                MessageBox.Show("Введите текст");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader("file.txt");
            richTextBox1.Text = streamReader.ReadToEnd();
            streamReader.Close();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
