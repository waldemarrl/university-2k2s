using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            if (!string.IsNullOrWhiteSpace(text))
            {
                int length = text.Length;
                int halfLength = length / 2;

                string first = text.Substring(0, halfLength);
                string second = text.Substring(halfLength);

                textBox2.Text = first;
                textBox3.Text = second;
            }
        }
    }
}
