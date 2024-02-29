using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public char words;
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texted = textBox1.Text;
            string answer = words.ToString();
            if (texted != answer)
                MessageBox.Show("Неправильно");
            else
                MessageBox.Show("Правильно");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            words = (char)random.Next('A', 'Z' + 1);
            textBox2.Text = words.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = words.ToString();
        }
    }
}
